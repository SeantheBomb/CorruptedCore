using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScreenData", menuName = "Corrupted/UIFactory/Data/Screen")]
public class ScreenData : UIData<ScreenArgs>
{

    public ScreenArgs args;

    public override ScreenArgs GetArgs()
    {
        return args;
    }
}
