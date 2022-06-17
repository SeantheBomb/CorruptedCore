using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;



[NodeWidth(200), NodeTint(20, 100, 30)]
public class SetTaskResultNode : GraphNode
{

    public ScoreTask task;
    //public ScoreResult result;


    public override bool led { get { return true; } }

    protected override void Init()
    {
        base.Init();
        //hasPlayed = false;
    }

    public override IEnumerator PlayNode(SequenceSystemManager view)
    {
        //Debug.Log("Sequence: Set task result - " + result, task);
        //task.SetResult(result);
        yield return null;
        PlayNextInPath(view);
    }

}
