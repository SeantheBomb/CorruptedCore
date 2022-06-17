using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NaughtyAttributes;

public class ModuleProgressView : MonoBehaviour
{
    [Header("Data")]
    public ModuleProgress module;


    [Header("References")]
    public Slider slider;
    public TMP_Text header;
    public TMP_Text progress;

    private void OnEnable()
    {
        UpdateView();
    }

    [Button]
    public void UpdateView()
    {
        slider.value = module.Progress;
        header.text = module.Label;
        progress.text = $"{Mathf.Round(module.Progress * 100)}%";
    }
}
