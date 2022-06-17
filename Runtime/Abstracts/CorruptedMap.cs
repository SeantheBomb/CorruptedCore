using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public abstract class CorruptedMap<T,K> : CorruptedValue<List<KeyValue<T,K>>>
    {

        Dictionary<T, int> map;

        public virtual void OnEnable()
        {
            if(map == null)map =  new Dictionary<T, int>();
            Value = new List<KeyValue<T,K>>();
            for (int i = 0; i < map.Count; i++)
            {
                map.Add(Value[i].key.Value, i);
            }
        }

        public virtual void Add(CorruptedVariable<T> t, CorruptedVariable<K> k)
        {
            if (map == null)
                map = new Dictionary<T, int>();
            map.Add(t.Value, map.Count);
            Value.Add(new KeyValue<T,K>() { key = t, value = k });
        }

        public virtual K Get(CorruptedVariable<T> t)
        {
            return Value[map[t.Value]].value.Value;
        }

        public virtual void Remove(CorruptedVariable<T> t)
        {
            int index = map[t.Value];
            Value.RemoveAt(index);
            map.Remove(t.Value);
        }

        
    }

    [System.Serializable]
    public struct KeyValue<T, K>
    {
        public CorruptedVariable<T> key;
        public CorruptedVariable<K> value;
    }

    [System.Serializable]
    public abstract class CorruptedMapRef<T, K> : CorruptedVariable<List<KeyValue<T, K>>> { }
    
}
