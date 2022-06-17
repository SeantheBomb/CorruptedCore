using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(200), NodeTint(100, 20, 20), CreateNodeMenu("Data/Checkpoint")]
public class CheckpointNode : GraphNode
{
    public override bool led => true;

    public Checkpoint checkpoint;

    public override IEnumerator PlayNode(SequenceSystemManager director)
    {
        checkpoint.Complete();
        Debug.Log($"Sequence: Checkpint {checkpoint.name} completed!!");
        yield return null;
        PlayNextInPath(director);
    }
}