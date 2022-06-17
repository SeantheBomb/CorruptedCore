using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;


[CreateAssetMenu(fileName = "CheckpointData", menuName = "Corrupted/Progress Bar/Checkpoint")]
public class Checkpoint : CorruptedModel, IProgressData
{

    public static System.Action<Checkpoint> OnCheckpointReached;

    public StringVariable Label;
    //public CorruptedEvent eventTrigger;
    [SerializeField] BoolVariable isCompleted;

    public bool IsComplete
    {
        get
        {
            return isCompleted;
        }
    }


    public float Progress => IsComplete ? 1f : 0f;

    public void Complete()
    {
        isCompleted = true;
        //eventTrigger?.Raise();
        OnCheckpointReached?.Invoke(this);
    }

    public void ResetProgress()
    {
        isCompleted = false;
        OnCheckpointReached?.Invoke(this);
    }
}
