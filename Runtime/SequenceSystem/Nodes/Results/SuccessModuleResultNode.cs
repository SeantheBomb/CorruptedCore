using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;



[NodeWidth(200), NodeTint(20, 100, 30)]

public class SuccessModuleResultNode : GraphNode
{

    [TextArea]
    public string result;


    public override bool led { get { return true; } }

    protected override void Init()
    {
        base.Init();
        //hasPlayed = false;
    }

    public override IEnumerator PlayNode(SequenceSystemManager view)
    {
        Debug.Log("Sequence: Success - " + result);
        yield return null;
        PlayNextInPath(view);
    }

}
