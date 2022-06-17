using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Corrupted;


[NodeWidth(200), NodeTint(60, 60, 100), CreateNodeMenu("Data/ResetCheckpoints")]
public class ResetCheckPoints : GraphNode
{
    public override bool led => true;


    public Checkpoint[] checkpoints;





    public override IEnumerator PlayNode(SequenceSystemManager director)
    {
        foreach(Checkpoint t in checkpoints)
        {
            t.ResetProgress();
        }

        yield return null;

        PlayNextInPath(director);
    }

}