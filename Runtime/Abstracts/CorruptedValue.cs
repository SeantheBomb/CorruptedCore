using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Corrupted
{
    /// <summary>
    /// A Corrupted model (scriptable object) that stores a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CorruptedValue<T> : CorruptedModel
    {


        [FormerlySerializedAs("Value")]
        public T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                OnValueChanged?.Invoke(_value, value);
                _value = value;
            }
        }

        /// <summary>
        /// T1 = old, T2 = new
        /// </summary>
        public System.Action<T, T> OnValueChanged;

        public void SetValue(T t)
        {
            Value = t;
        }
    }
}
