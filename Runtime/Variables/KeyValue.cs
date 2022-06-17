using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "KeyVariable", menuName = "Corrupted/Variable/StringKey", order = 0)]
    public class KeyValue : StringValue
    {

        //private void OnValidate()
        //{
        //    Value = name;
        //}

    }


    [System.Serializable]
    public class KeyVariable : StringVariable { }
}
