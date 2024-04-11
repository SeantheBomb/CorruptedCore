using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutView : UIView<LayoutArgs>
{
    public override void ClearData()
    {
        foreach(Transform t in transform)
        {
            Destroy(t);
        }
    }

    public override void Setup(LayoutArgs args)
    {
        foreach(var a in args.data)
        {
            a.Build(transform);
        }
    }
}
