using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DebugButtonData", menuName = "Corrupted/UIFactory/Data/Button/Debug")]
public class DebugHelloWorldButton : UIData<ButtonArgs>
{

    public string label;
    public string message;

    //public override UIView<ButtonArgs> Build(UIView<ButtonArgs> newView)
    //{
    //    newView.Setup(this);
    //    return newView;
    //}

    public override ButtonArgs GetArgs()
    {
        return new ButtonArgs()
        {
            label = label,
            invoke = () => Debug.Log(message)
        };
    }
}
