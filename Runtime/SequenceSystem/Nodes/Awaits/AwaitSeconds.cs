using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Corrupted;



[NodeWidth(200), NodeTint(102, 0, 70), CreateNodeMenu("Awaits/Seconds")]

public class AwaitSeconds : GraphNode
{

    public FloatVariable seconds;
    //public bool invert = false;


    public override bool led { get { return true; } }

    protected override void Init()
    {
        base.Init();
        //hasPlayed = false;
    }

    public override IEnumerator PlayNode(SequenceSystemManager view)
    {
        //Debug.Log("Sequence: Awaiting flag " + flagKey);
        Debug.Log($"Sequence: Wait {seconds.Value} seconds");
        yield return new WaitForSeconds(seconds.Value);
        //Debug.Log("Sequence: Awaiting flag complete " + flagKey);
        PlayNextInPath(view);
    }

}
