using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LayoutData", menuName = "Corrupted/UIFactory/Data/Layout")]
public class LayoutData : UIData<LayoutArgs>
{

    public UIData[] data;

    public override LayoutArgs GetArgs()
    {
        return new LayoutArgs()
        {
            data = data
        };
    }
}
