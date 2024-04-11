using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView : MonoBehaviour
{
    public string style;

    public abstract Type argType
    {
        get;
    }

    public abstract void ClearData();


}

public abstract class UIView<T> : UIView where T : UIArgs
{

    public override Type argType => typeof(T);

    public virtual void Setup(UIData<T> data)
    {
        Setup(data.GetArgs());
    }

    public abstract void Setup(T args);


}