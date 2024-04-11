using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputFieldArgs : UIArgs
{
    public string placeholderText;

    public string inputText;

    public System.Action<string> OnInputUpdate;
}
