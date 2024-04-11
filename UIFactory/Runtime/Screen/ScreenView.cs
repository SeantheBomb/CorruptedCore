using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class ScreenView : UIView<ScreenArgs>
{
    public override void ClearData()
    {
        foreach (Transform t in transform)
            Destroy(t);
    }

    public override void Setup(ScreenArgs args)
    {
        foreach(UIData d in args.data)
        {
            d.Build(transform);
        }
    }

}
