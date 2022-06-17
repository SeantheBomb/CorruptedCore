using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Corrupted/Variable/String", order = 0)]
    public class StringValue : CorruptedValue<string>
    {
        [TextArea]
        new string Value;

    }


    [System.Serializable]
    public class StringVariable : CorruptedVariable<string> { }
}
