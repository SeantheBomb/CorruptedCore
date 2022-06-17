using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XNode;
using Corrupted;



[NodeWidth(200), NodeTint(0, 70, 130), CreateNodeMenu("Data/Lock Task")]

public class LockTaskNode : GraphNode
{

    public ScoreTask[] tasks;
    public BoolVariable state;

    public override bool led => true;

    public override IEnumerator PlayNode(SequenceSystemManager view)
    {
        foreach(ScoreTask t in tasks)
        {
            t.SetLock(state);
        }
        yield return null;
        PlayNextInPath(view);
    }
}
