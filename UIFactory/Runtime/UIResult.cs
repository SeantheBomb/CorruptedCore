using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UIResult<T> where T : UIResultArgs
{

    public System.Action<UIResult<T>, T> OnResultUpdate
    {
        get;set;
    }

    public T GetResult();

}


public interface UIResultArgs { }