using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIFactory
{

    public static UIKit DefaultUIKit;

    public static UIView BuildUI(UIData data, Transform target, UIKit kit = null)
    {
        return data.Build(target, kit);
    }

    public static UIView BuildUI(UIArgs args, Transform target, string style = "", UIKit kit = null)
    {

        UIView clone = InstantiateFromArgs(args.GetType(), target, style, kit);

        if(clone is UIView<UIArgs> c)
        {
            c.Setup(args);
        }

        return clone;
    }

    public static UIView InstantiateFromArgs(Type args, Transform target, string style = "", UIKit kit = null)
    {
        UIView viewPrefab = GetPrefabFromArgs(args, style, kit);

        return GameObject.Instantiate(viewPrefab, target);
    }

    public static UIView InstantiateFromType(Type type, Transform target, string style = "", UIKit kit = null) 
    {
        UIView viewPrefab = GetPrefabFromType(type, style, kit);

        return GameObject.Instantiate(viewPrefab, target);
    }

    public static UIView GetPrefabFromArgs(Type args, string style = "", UIKit kit = null)
    {
        if (kit == null) kit = DefaultUIKit;

        return kit.GetView(args, style);
    }

    public static UIView GetPrefabFromType(Type type, string style = "", UIKit kit = null)
    {
        if (kit == null) kit = DefaultUIKit;

        return kit.GetViewType(type, style);
    }

    public static void SetDefaultUIKit(UIKit kit)
    {
        DefaultUIKit = kit;
    }

}
