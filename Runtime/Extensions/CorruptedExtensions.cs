using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public static class CorruptedExtensions
    {

        public static Vector3 PercentageAlongAxis(this Vector3 vector, Vector3 axis)
        {
            return axis * (Vector3.Dot(axis.normalized, vector.normalized) * vector.magnitude);
        }

        public static bool IsGenericList(this object o)
        {
            var oType = o.GetType();
            return oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        public static T[] GetOverlapSphere<T>(this Vector3 pos, float radius, int layer = ~0) where T : MonoBehaviour
        {
            List<T> tList = new List<T>();
            Collider[] hits = Physics.OverlapSphere(pos, radius, layer);
            foreach(Collider c in hits)
            {
                T t = c.GetComponentInParent<T>();
                if (t != null)
                    tList.Add(t);
            }
            //if (tList.Count == 0)
            //    return null;
            return tList.ToArray();
        }

        public static Vector3 Multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static bool IfHasComponent<T>(this GameObject mb, System.Action<T> action) where T : MonoBehaviour
        {
            T t = mb.GetComponent<T>();
            if (t != null)
                action?.Invoke(t);
            return t != null;
        }

    }
}