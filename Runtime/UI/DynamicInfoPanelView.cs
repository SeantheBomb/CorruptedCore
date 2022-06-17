using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using TMPro;
using NaughtyAttributes;

public class DynamicInfoPanelView : CorruptedBehaviour<DynamicInfoPanelView>
{


    [Header("Data")]
    public StringVariable output;

    [Header("References")]
    public TMP_Text view;

    public override void Start()
    {
        base.Start();
        UpdateText();
    }


    [Button]
    public void UpdateText()
    {
        if (view == null)
            view = GetComponentInChildren<TMP_Text>();
        view.text = output;
    }

    public void UpdateText(string s)
    {
        output.Value = s;
        UpdateText();
    }

    public void UpdateText(StringVariable s)
    {
        output = s;
        UpdateText();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
