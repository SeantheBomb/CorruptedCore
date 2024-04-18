using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIKit : ScriptableObject
{

    

    public abstract UIView[] prefabs
    {
        get;
    }

    public UIView GetView(UIData data)
    {
        return GetView(data.GetUIArgs(), data.style);
    }

    public UIView GetView(UIArgs args, string style = "")
    {
        return GetView(args.GetType(), style);
    }


    public UIView GetView(Type args, string style = "")
    {
        var type = prefabs.Where((v) => v.argType == args).ToList();
        var select = type.Where((v) => v.style == style).ToList();
        if (select.Count() > 0) return select[0];

        if (type.Count() > 0) return type[0];

        return null;
    }

    public UIView GetViewType(Type type, string style = "")
    {
        var views = prefabs.Where((v) => v.GetType() == type).ToList();
        var select = views.Where((v) => v.style == style).ToList();
        if (select.Count() > 0) return select[0];

        if (views.Count() > 0) return views[0];

        return null;
    }

}
