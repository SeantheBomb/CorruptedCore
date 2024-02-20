using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Corrupted
{
    public class DebugHelper : Singleton<DebugHelper>
    {

#if UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod]
        static void SpawnSingleton()
        {
            DebugHelper helper = new GameObject("[Debug Helper]").AddComponent<DebugHelper>();
            DontDestroyOnLoad(helper);
        }
#endif


        static IEnumerator DoForXSecondsTask(Action action, float duration)
        {
            for (float i = 0; i < duration; i+= Time.deltaTime)
            {
                action?.Invoke();
                yield return null;
            }
        }

        static void DoForXSeconds(Action action, float duration)
        {
            Instance.StartCoroutine(DoForXSecondsTask(action, duration));
        }


        public static void DrawLine(Vector3 from, Vector3 to, Color color, float duration)
        {
            DoForXSeconds(() =>
            {
                Debug.DrawLine(from, to, color);
            }, duration);
        }

        public static void DrawRay(Vector3 from, Vector3 direction, float range, Color color, float duration)
        {
            DoForXSeconds(() =>
            {
                Debug.DrawLine(from, from + direction.normalized * range, color);
            }, duration);
        }

        public static void DrawRay(Vector3 from, Vector3 direction, Color color, float duration)
        {
            DoForXSeconds(() =>
            {
                Debug.DrawLine(from, from + direction, color);
            }, duration);
        }

        public static void DrawRay(Vector3 from, Vector3 direction, Color color)
        {
            Debug.DrawLine(from, from + direction, color);
        }



    }
}
