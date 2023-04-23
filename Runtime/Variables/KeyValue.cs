using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Corrupted
{
    [CreateAssetMenu(fileName = "KeyVariable", menuName = "Corrupted/Variable/StringKey", order = 0)]
    public class KeyValue : StringValue
    {

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Value != name)
            {
                Value = name;
                EditorUtility.SetDirty(this);
            }
        }
#endif

    }


    [System.Serializable]
    public class KeyVariable : StringVariable { }
}
