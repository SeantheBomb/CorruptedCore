using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_InputField))]
public class InputFieldView : UIView<InputFieldArgs>
{

    private TMP_InputField _field;
    private TMP_InputField field => _field ??= GetComponent<TMP_InputField>();

    public override void ClearData()
    {
        field.text = "";
    }

    public override void Setup(InputFieldArgs args)
    {
        if (field.placeholder is TMP_Text text)
            text.text = args.placeholderText;
    }

    public string GetText()
    {
        return field.text;
    }
}
