using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "Corrupted/Variable/GameObject", order = 0)]
    public class GameObjectValue : CorruptedValue<GameObject>
    {
    }


    [System.Serializable]
    public class GameObjectVariable : CorruptedVariable<GameObject> {

        public static implicit operator GameObjectVariable(GameObject value)
        {
            GameObjectVariable variable = new GameObjectVariable();
            variable.ConstantValue = value;
            return variable;
        }

    }
}
