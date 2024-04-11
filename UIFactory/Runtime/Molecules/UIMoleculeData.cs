using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIMoleculeData<T> : UIData<T> where T : UIArgs
{


    protected abstract T args
    {
        get;
    }

    protected abstract UIMolecule molecule
    {
        get;
    }


    public override T GetArgs()
    {
        return args;
    }


    public override UIView Build(Transform parent, UIKit kit = null)
    {
        return molecule.Build(parent, OnBuild);
    }

    public abstract void OnBuild(Dictionary<UIAtom, UIView> build);
}
