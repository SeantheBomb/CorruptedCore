using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Corrupted;

public class NavigationPanelController : MenuPanel
{

    //public static Dictionary<string, NavigationPanelController> instances = new Dictionary<string, NavigationPanelController>();

    public System.Action OnYesButtonPressed, OnNoButtonPressed;

    [Header("Data")]
    public NavigationPanelData data;

    [Header("References")]
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text body;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    TMP_Text yesText;
    TMP_Text noText;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        yesButton.onClick.AddListener(() => OnYesButtonPressed());
        noButton.onClick.AddListener(() => OnNoButtonPressed());
        yesText = yesButton.GetComponentInChildren<TMP_Text>();
        noText = noButton.GetComponentInChildren<TMP_Text>();
        if (data != null)
            SetupPanel(data);
        gameObject.SetActive(false);
    }

    public void SetupPanel(string header, string body, string yesText = null, string noText = null)
    {
        this.header.text = header;
        this.body.text = body;
        this.yesText.text = yesText;
        this.noText.text = noText;
    }

    public void SetupPanel(NavigationPanelData data)
    {
        SetupPanel(data.header, data.body, data.yesOption, data.noOption);
    }

    public void ShowYesButton(bool value)
    {
        yesButton.gameObject.SetActive(value);
    }

    public void ShowNoButton(bool value)
    {
        noButton.gameObject.SetActive(value);
    }
}
