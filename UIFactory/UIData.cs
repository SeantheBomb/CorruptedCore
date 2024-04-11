using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIData : ScriptableObject 
{

    public string style;

    public abstract Type argType
    {
        get;
    }

    public abstract UIArgs GetUIArgs();

    public abstract UIView Build(UIView newView);

    public virtual UIView Build(Transform target, UIKit kit = null)
    {
        if (kit == null) kit = UIFactory.DefaultUIKit;

        UIView viewPrefab = kit.GetView(this);

        UIView clone = GameObject.Instantiate(viewPrefab, target);

        return Build(clone);
    }

}

public abstract class UIData<T> : UIData where T : UIArgs
{
    public override Type argType => typeof(T);


    //public abstract UIView<T> Build(UIView<T> newView);

    public abstract T GetArgs();

    public override UIArgs GetUIArgs()
    {
        return GetArgs();
    }

    public override UIView Build(UIView newView)
    {
        if (newView is UIView<T> typedPrefab)
        {
            typedPrefab.Setup(this);
            return typedPrefab;
        }
        return null;
    }

}
