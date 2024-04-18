using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public class CoroutineRunner : Singleton<CoroutineRunner>
    {
        
        public static Coroutine Start(IEnumerator coroutine)
        {
            return Instance.StartCoroutine(coroutine);
        }

        public static void Stop(Coroutine coroutine)
        {
            Instance.StopCoroutine(coroutine);
        }



        [RuntimeInitializeOnLoadMethod]
        public static void SpawnRunner()
        {
            if(Instance == null)
            {
                GameObject runner = new GameObject("[Coroutine Runner]");
                runner.AddComponent<CoroutineRunner>();
                DontDestroyOnLoad(runner);
            }
        }

    }
}
