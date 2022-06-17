using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;


[CreateAssetMenu(fileName = "ModuleProgressData", menuName = "Corrupted/Progress Bar/Module")]
public class ModuleProgress : CorruptedModel, IProgressData
{

    public StringVariable Label;
    public Checkpoint[] checkpoints;

    public bool IsComplete
    {
        get
        {
            foreach (Checkpoint c in checkpoints)
                if (c.IsComplete == false)
                    return false;
            return true;
        }
    }

    public float Progress
    {
        get
        {
            float completed = 0;
            foreach (Checkpoint c in checkpoints)
                if (c.IsComplete)
                    completed++;
            return completed / checkpoints.Length;
        }
    }

    public void Complete()
    {
        foreach (Checkpoint c in checkpoints)
            c.Complete();
    }

    public void ResetProgress()
    {
        foreach (Checkpoint c in checkpoints)
            c.ResetProgress();
    }

    //public float 
}
