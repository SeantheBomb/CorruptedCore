using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Corrupted;


[NodeWidth(200), NodeTint(60, 60, 100), CreateNodeMenu("Data/ResetScoreTask")]
public class ResetScoreTask : GraphNode
{
    public override bool led => true;


    public ScoreTask[] tasks;





    public override IEnumerator PlayNode(SequenceSystemManager director)
    {
        foreach(ScoreTask t in tasks)
        {
            t.ResetTask();
        }
        yield return null;
        PlayNextInPath(director);
    }

}