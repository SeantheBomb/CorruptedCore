using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.UI;

public class SimProgressView : MonoBehaviour
{
    [Header("Data")]
    public SimProgress simProgress;


    [Header("References")]
    public TMP_Text header;
    public TMP_Text overallProgress;
    public Slider overallSlider;
    public ModuleProgressView[] modules;

    // Start is called before the first frame update
    private void OnEnable()
    {
        UpdateView();
        Checkpoint.OnCheckpointReached += OnCheckpoint;
    }

    private void OnDisable()
    {
        Checkpoint.OnCheckpointReached -= OnCheckpoint;
    }

    [Button]
    public void UpdateView()
    {
        header.text = simProgress.Label;
        overallProgress.text = $"Overall Progress: {(Mathf.Round(simProgress.Progress * 100))}%";
        overallSlider.value = simProgress.Progress * overallSlider.maxValue;
        foreach(ModuleProgressView m in modules)
        {
            m.UpdateView();
        }
    }

    void OnCheckpoint(Checkpoint c)
    {
        UpdateView();
        Debug.Log($"Progress: Update progress bar to add {c.name} as completed!");
    }
}
