using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    /// <summary>
    /// A Corrupted model (scriptable object) that stores a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CorruptedValue<T> : CorruptedValue
    {
        public T Value;

        public override object ObjectValue => Value;
    }

    public abstract class CorruptedValue : CorruptedModel
    {
        public abstract object ObjectValue
        {
            get;
        }
    }
}
