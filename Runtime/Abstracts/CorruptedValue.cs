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

        public override object ObjectValue => Value;

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


        public void SetValue(T value)
        {
            Value = value;
        }
    }

    public abstract class CorruptedValue : CorruptedModel
    {
        public abstract object ObjectValue
        {
            get;
        }
    }
}
