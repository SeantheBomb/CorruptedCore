using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{


    /// <summary>
    /// Abstract class that stores a reference to either a constant or a Corrupted value, depending on designer's choice
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public abstract class CorruptedVariable<T> : CorruptedVariable
    {

        protected static T defaultValue;


        public T ConstantValue;
        public CorruptedValue<T> Variable;
        public T Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }

        public bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public override bool UseConstant
        {
            get
            {
                return Variable == null || _useConstant;
                //    _useConstant = true;
                //return _useConstant;
            }
            set
            {
                _useConstant = value;
            }
        }



        public static implicit operator T(CorruptedVariable<T> value)
        {
            return value != null ? value.Value : defaultValue;
        }      
        
    }

    [System.Serializable]
    public abstract class CorruptedVariable
    {
        [HideInInspector]
        public bool _useConstant = true;
        public abstract bool UseConstant
        {
            get; set;
        }
    }
}
