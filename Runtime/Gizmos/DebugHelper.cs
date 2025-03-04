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
#if UNITY_EDITOR
            Instance.StartCoroutine(DoForXSecondsTask(action, duration));
#endif
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

        public static void DrawSphereCast(Vector3 from, Vector3 direction, float radius, Color color)
        {
            Vector3 cross = Vector3.Cross(direction.normalized, Vector3.up);

            Vector3 to = from + direction;

            Debug.DrawLine(from + Vector3.up * radius, to + Vector3.up * radius, color);
            Debug.DrawLine(from - Vector3.up * radius, to - Vector3.up * radius, color);
            Debug.DrawLine(from + cross * radius, to + cross * radius, color);
            Debug.DrawLine(from - cross * radius, to - cross * radius, color);
        }

        public static void DrawWireSphere(Vector3 position, float radius, Color color, int segments = 24)
        {
            float angleStep = 360f / segments;

            // Draw circles in the XY, XZ, and YZ planes
            DrawCircle(position, radius, color, segments, Vector3.right, Vector3.up);  // XY plane
            DrawCircle(position, radius, color, segments, Vector3.right, Vector3.forward); // XZ plane
            DrawCircle(position, radius, color, segments, Vector3.up, Vector3.forward); // YZ plane
        }

        public static void DrawWireSphere(Vector3 position, float radius, Color color, float duration, int segments = 24)
        {
            float angleStep = 360f / segments;

            // Draw circles in the XY, XZ, and YZ planes
            DrawCircle(position, radius, color, segments, Vector3.right, Vector3.up, duration);  // XY plane
            DrawCircle(position, radius, color, segments, Vector3.right, Vector3.forward, duration); // XZ plane
            DrawCircle(position, radius, color, segments, Vector3.up, Vector3.forward, duration); // YZ plane
        }

        private static void DrawCircle(Vector3 center, float radius, Color color, int segments, Vector3 axis1, Vector3 axis2, float duration = 0)
        {
            float angleStep = 360f / segments;
            Vector3 prevPoint = center + (axis1 * radius);

            for (int i = 1; i <= segments; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector3 newPoint = center + (axis1 * Mathf.Cos(angle) * radius) + (axis2 * Mathf.Sin(angle) * radius);
                if (duration <= 0)
                    Debug.DrawLine(prevPoint, newPoint, color);
                else
                    Debug.DrawLine(prevPoint, newPoint, color, duration);
                prevPoint = newPoint;
            }
        }



    }
}
