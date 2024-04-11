using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InputFieldData", menuName = "Corrupted/UIFactory/InputField")]
public class InputFieldData : UIData<InputFieldArgs>
{

    public InputFieldArgs args;

    public override InputFieldArgs GetArgs()
    {
        return args; 
    }
}
