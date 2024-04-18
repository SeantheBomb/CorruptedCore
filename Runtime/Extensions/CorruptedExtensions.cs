using System;
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

        public static T[] GetFromList<T,K>(this K[] input, Func<K,T> func)
        {
            List<T> list = new List<T>();
            foreach(K k in input)
            {
                T t = func(k);
                if (t != null)
                    list.Add(t);
            }
            return list.ToArray();
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

        public static RayHit<T>[] GetSphereCast<T>(this Vector3 pos, Vector3 direction, float radius, float distance = Mathf.Infinity, int layer = ~0) where T : MonoBehaviour
        {
            List<RayHit<T>> tList = new List<RayHit<T>>();
            RaycastHit[] hits = Physics.SphereCastAll(pos, radius, direction, distance, layer);
            foreach (RaycastHit c in hits)
            {
                T t = c.transform.GetComponentInParent<T>();
                if (t != null)
                    tList.Add(new RayHit<T>(t, c));
            }
            //if (tList.Count == 0)
            //    return null;
            return tList.ToArray();
        }

        public static RayHit<T>[] GetRaycastList<T>(this Vector3 pos, Vector3 direction, float distance = Mathf.Infinity, int layer = ~0) where T : MonoBehaviour
        {
            List<RayHit<T>> tList = new List<RayHit<T>>();
            RaycastHit[] hits = Physics.RaycastAll(pos, direction, distance, layer);
            foreach (RaycastHit c in hits)
            {
                T t = c.transform.GetComponentInParent<T>();
                if (t != null)
                    tList.Add(new RayHit<T>(t, c));
            }
            //if (tList.Count == 0)
            //    return null;
            return tList.ToArray();
        }

        public static bool IfRaycast(this Vector3 pos, Vector3 direction, float distance, System.Action<RaycastHit> action = null, int layer = ~0)
        {
            RaycastHit hit;
            if(Physics.Raycast(pos, direction, out hit, distance, layer))
            {
                action?.Invoke(hit);
                return true;
            }
            return false;
        }


        public static K[] ConvertArray<T,K>(this T[] array, Func<T,K> convert)
        {
            K[] newArray = new K[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = convert(array[i]);
            }
            return newArray;
        }

        public static T[] GetObjectList<T>(this RayHit<T>[] array)
        {
            return array.ConvertArray<RayHit<T>, T>((a) => a);
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

        public static bool TryGetComponentInParent<T>(this Component mb, out T result) where T : Component
        {
            result = mb.GetComponentInParent<T>();
            return result != null;
        }

        public static bool ContainsLayers(this LayerMask group, LayerMask search)
        {
            return (group & (1 << search)) != 0;
        }

    }

    public class RayHit<T>
    {

        public T value
        {
            get; protected set;
        }
        public RaycastHit hit
        {
            get; protected set;
        }

        public Transform transform => hit.transform;

        public RayHit(T value, RaycastHit hit)
        {
            this.value = value;
            this.hit = hit;
        }

        public static implicit operator T(RayHit<T> value)
        {
            return value;
        }

    }

}
