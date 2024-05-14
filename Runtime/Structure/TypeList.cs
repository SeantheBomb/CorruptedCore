using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    [System.Serializable]
    public class TypeList 
    {
        Dictionary<Type, object> list;

        public TypeList()
        {
            list = new Dictionary<Type, object>();
        }

        public void Set(object o)
        {
            if (list.ContainsKey(o.GetType()))
            {
                list[o.GetType()] = o;
            }
            else
            {
                list.Add(o.GetType(), o);
            }
        }

        public T Get<T>()
        {
            if (TryGet(out T t) == false)
            {
                Set(t);
            }
            return t;
        }

        public bool TryGet<T>(out T result)
        {
            if (list.TryGetValue(typeof(T), out object t) == false)
            {
                result = default(T);
                return false;
            }
            result = (T)t;
            return true;
        }
    }

    [System.Serializable]
    public class TypeList<K> : IEnumerable
    {
        Dictionary<Type, K> list;

        public TypeList()
        {
            list = new Dictionary<Type, K>();
        }

        public void Set(K o)
        {
            if (list.ContainsKey(o.GetType()))
            {
                list[o.GetType()] = o;
            }
            else
            {
                list.Add(o.GetType(), o);
            }
        }

        public T Get<T>() where T : K
        {
            if (TryGet(out T t) == false)
            {
                Set(t);
            }
            return t;
        }

        public bool TryGet<T>(out T result) where T : K
        {
            if (list.TryGetValue(typeof(T), out K t) == false)
            {
                result = default(T);
                return false;
            }
            result = (T)t;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return list.Values.GetEnumerator();
        }
    }
}
