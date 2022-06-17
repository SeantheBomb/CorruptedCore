using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SequenceSystemManager))]
public abstract class SequenceBehaviour : CorruptedBehaviour<SequenceBehaviour>
{
    SequenceSystemManager _sequence;
    protected SequenceSystemManager sequence
    {
        get
        {
            if (_sequence == null) _sequence = GetComponent<SequenceSystemManager>();
            return _sequence;
        }
    }

    public bool isBusy => sequence.inProgress;
    

    protected virtual void OnValidate()
    {
        instanceKey = sequence.instanceKey;
    }

}
