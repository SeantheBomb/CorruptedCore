using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;



[NodeWidth(200), NodeTint(100, 10, 10)]

public class FailModuleResultNode : GraphNode
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
        Debug.Log("Sequence: Failed - " + result);
        yield return null;
        PlayNextInPath(view);
    }

}
