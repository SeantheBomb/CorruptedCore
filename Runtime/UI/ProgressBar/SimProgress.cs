using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "SimProgressData", menuName = "Corrupted/Progress Bar/Simulation")]
public class SimProgress : CorruptedModel, IProgressData
{

    public StringVariable Label;

    public ModuleProgress[] modules;

    public bool IsComplete
    {
        get
        {
            foreach (ModuleProgress c in modules)
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
            foreach (ModuleProgress c in modules)
                completed += c.Progress;
            return completed / modules.Length;
        }
    }

    public void Complete()
    {
        foreach (ModuleProgress m in modules)
            m.Complete();
    }

    public void ResetProgress()
    {
        foreach (ModuleProgress m in modules)
            m.ResetProgress();
    }

    [Button]
    public void PrintProgress()
    {
        Debug.Log($"ProgressBar: Simulation progress = {(Progress * 100)}%");
        int i = 0;
        foreach(ModuleProgress m in modules)
        {
            Debug.Log($"ProgressBar: Module {i++} progress = {(m.Progress * 100)}%");
        }
    }
}
