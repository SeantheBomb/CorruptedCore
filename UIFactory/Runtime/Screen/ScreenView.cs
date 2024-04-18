using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Canvas))]
public class ScreenView : UIView<ScreenArgs>
{

    Canvas canvas;

    public override void ClearData()
    {
        if (canvas == null)
            return;

        foreach (Transform t in canvas.transform)
            Destroy(t);
    }

    public override void Setup(ScreenArgs args)
    {
        canvas ??= GetComponentInChildren<Canvas>();
        if(canvas == null)
        {
            Debug.LogError($"ScreenView: Prefab {name} does not contain canvas in children!");
            return;
        }
            
        foreach(UIData d in args.data)
        {
            d.Build(canvas.transform);
        }
    }

}
