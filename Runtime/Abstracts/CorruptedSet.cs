using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public abstract class CorruptedSet<T> : CorruptedValue<List<T>>
    {
        public virtual void Add(T t)
        {
            if (Value == null)
                Value = new List<T>();
            Value.Add(t);
        }

        public virtual void Remove(T t)
        {
            Value.Remove(t);
        }

    }

    [System.Serializable]
    public abstract class CorruptedSetRef<T> : CorruptedVariable<List<T>> { }
}
