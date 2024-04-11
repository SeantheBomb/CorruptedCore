using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UIMolecule
{
    public UIAtom molecule;
    public UIAtom[] atoms;

    public System.Action<Dictionary<UIAtom, UIView>> OnBuild;

    public UIView Build(Transform parent, UIKit kit = null)
    {
        Dictionary<UIAtom, UIView> build = new Dictionary<UIAtom, UIView>();
        UIView container = UIFactory.InstantiateFromType(molecule.type, parent);
        build.Add(molecule, container);
        foreach(var a in atoms)
        {
            UIView view = UIFactory.InstantiateFromType(a.type, container.transform, a.style);
            build.Add(a, view);
        }
        OnBuild?.Invoke(build);
        return container;
    }

    public UIView Build(Transform parent, System.Action<Dictionary<UIAtom, UIView>> subscribe, UIKit kit = null)
    {
        OnBuild += subscribe;
        UIView view = Build(parent);
        OnBuild -= subscribe;
        return view;
    }

}

public struct UIAtom
{
    public string name;
    public Type type;
    public string style;
}
