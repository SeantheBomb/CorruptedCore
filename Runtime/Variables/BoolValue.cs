using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Corrupted/Variable/Bool", order = 0)]
    public class BoolValue : CorruptedValue<bool>
    {
    }

    [System.Serializable]
    public class BoolVariable : CorruptedVariable<bool> {
        public static implicit operator BoolVariable(bool value)
        {
            BoolVariable variable = new BoolVariable();
            if (variable.Variable == null)
                variable.ConstantValue = value;
            else
                variable.Value = value;
            return variable;
        }
    }
}
