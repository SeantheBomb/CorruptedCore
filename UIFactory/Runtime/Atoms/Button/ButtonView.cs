using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonView : UIView<ButtonArgs>
{

    Button _button;

    Button button => _button ??= GetComponent<Button>();

    TMP_Text _label;
    TMP_Text label => _label ??= GetComponentInChildren<TMP_Text>(); 

    public override void ClearData()
    {
        label.text = "";
        button.onClick.RemoveAllListeners();
    }

    public override void Setup(ButtonArgs args)
    {
        label.text = args.label;
        button.onClick.AddListener(() => args.invoke?.Invoke());
    }

}
