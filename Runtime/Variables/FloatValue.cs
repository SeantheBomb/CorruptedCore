using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Corrupted/Variable/Float", order = 0)]
    public class FloatValue : CorruptedValue<float>
    {
    }


    [System.Serializable]
    public class FloatVariable : CorruptedVariable<float> {

        public static implicit operator FloatVariable(float value)
        {
            FloatVariable variable = new FloatVariable();
            variable.ConstantValue = value;
            return variable;
        }
    }
}
