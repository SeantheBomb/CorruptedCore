using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgressData 
{

    public bool IsComplete
    {
        get;
    }

    public float Progress
    {
        get;
    }

    public void Complete();

    public void ResetProgress();

}
