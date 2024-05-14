using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Corrupted
{
    public class CoroutineEvent 
    {
        List<IEnumerator> coroutines = new List<IEnumerator>();


        public CoroutineEvent(params IEnumerator[] tasks)
        {
            foreach(var t in tasks)
            {
                Add(t);
            }
        }

        public void Add(IEnumerator coroutine)
        {
            coroutines.Add(coroutine);
        }

        public void Remove(IEnumerator coroutine)
        {
            coroutines.Remove(coroutine);
        }

        public void Invoke(MonoBehaviour component, Action onComplete = null)
        {
            Task t = new Task() { coroutine = Play(component, onComplete) };
            component.StartCoroutine(t.Play());
        }

        public IEnumerator Play(MonoBehaviour component, Action onComplete = null)
        {
            List<Task> tasks = new List<Task>();
            foreach(var c in coroutines)
            {
                Task t = new Task() { coroutine = c };
                component.StartCoroutine(t.Play());
                tasks.Add(t);
            }
            yield return null;
            yield return new WaitUntil(() => tasks.Where((t) => t.isRunning).Count() == 0);
            onComplete?.Invoke();
        }

        
        public class Task
        {
            public bool isRunning;

            public IEnumerator coroutine;

            public IEnumerator Play()
            {
                isRunning = true;
                yield return coroutine;
                isRunning = false;
            }
        }
    }



    public class CoroutineEvent<T>
    {
        List<Func<T, IEnumerator>> coroutines = new List<Func<T, IEnumerator>>();


        public CoroutineEvent(params Func<T, IEnumerator>[] tasks)
        {
            foreach (var t in tasks)
            {
                Add(t);
            }
        }

        public void Add(Func<T, IEnumerator> coroutine)
        {
            coroutines.Add(coroutine);
        }

        public void Remove(Func<T, IEnumerator> coroutine)
        {
            coroutines.Remove(coroutine);
        }

        public void Invoke(MonoBehaviour component, T arg, Action onComplete = null)
        {
            Task t = new Task() { coroutine = (arg)=>Play(component, arg, onComplete) };
            component.StartCoroutine(t.Play(arg));
        }

        public IEnumerator Play(MonoBehaviour component, T arg, Action onComplete = null)
        {
            List<Task> tasks = new List<Task>();
            foreach (var c in coroutines)
            {
                Task t = new Task() { coroutine = c };
                component.StartCoroutine(t.Play(arg));
                tasks.Add(t);
            }
            yield return null;
            yield return new WaitUntil(() => tasks.Where((t) => t.isRunning).Count() == 0);
            onComplete?.Invoke();
        }


        public class Task
        {
            public bool isRunning;

            public Func<T, IEnumerator> coroutine;

            public IEnumerator Play(T arg)
            {
                isRunning = true;
                yield return coroutine(arg);
                isRunning = false;
            }
        }
    }
}
