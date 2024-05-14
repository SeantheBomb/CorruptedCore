using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Corrupted
{
    public class CoroutineRunner : MonoBehaviour
    {

        Dictionary<ICoroutineModel, Coroutine> activeCoroutines = new Dictionary<ICoroutineModel, Coroutine>();


        public Coroutine StartTask(ICoroutineModel n)
        {
            if (activeCoroutines.ContainsKey(n))
            {
                StopTask(n);
            }
            Coroutine c = StartCoroutine(n.RunCoroutine(this));
            activeCoroutines.Add(n, c);
            return c;
        }

        public void StopTask(ICoroutineModel n)
        {
            if (activeCoroutines.ContainsKey(n) == false)
            {
                return;
            }
            StopCoroutine(activeCoroutines[n]);
            activeCoroutines.Remove(n);
        }


        public void StopAllTasks()
        {
            foreach(var n in activeCoroutines.Keys)
            {
                StopTask(n);
            }
        }

        public void StopOtherTasks(ICoroutineModel n)
        {
            foreach(var k in activeCoroutines.Keys)
            {
                if (n != k)
                    StopTask(k);
            }
        }

        


    }

}
