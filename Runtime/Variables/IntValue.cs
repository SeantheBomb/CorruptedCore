using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Corrupted/Variable/Int", order = 0)]
    public class IntValue : CorruptedValue<int>
    {

        [Button]
        public void IndexUp()
        {
            Value++;
        }

        [Button]
        public void IndexDown()
        {
            Value--;
        }

    }


    [System.Serializable]
    public class IntVariable : CorruptedVariable<int>
    {

        public static implicit operator IntVariable(int value)
        {
            IntVariable variable = new IntVariable();
            variable.ConstantValue = value;
            return variable;
        }
    }
}
