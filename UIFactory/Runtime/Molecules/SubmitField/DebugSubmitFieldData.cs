using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DebugSubmitFieldData", menuName = "Corrupted/UIFactory/Molecule/DebugSubmitField")]
public class DebugSubmitFieldData : UIMoleculeData<SubmitFieldArgs>
{

    public string placeholderName;
    public string submitText;

    protected override SubmitFieldArgs args => new SubmitFieldArgs()
    {
        inputField = new UIAtom
        {
            name = "Input Field",
            type = typeof(InputFieldView),
            style = ""
        },
        button = new UIAtom
        {
            name = "Button",
            type = typeof(ButtonView),
            style = ""
        },
        layout = new UIAtom
        {
            name = "Layout",
            type = typeof(LayoutView),
            style = "horizontal"
        }
    };

    protected override UIMolecule molecule => new UIMolecule()
    {
        molecule = args.layout,
        atoms = new UIAtom[]
            {
                args.inputField,
                args.button
            }
    };




    public override void OnBuild(Dictionary<UIAtom, UIView> build)
    {
        InputFieldView inputField = build[args.inputField] as InputFieldView;
        ButtonView button = build[args.button] as ButtonView;

        inputField.Setup(new InputFieldArgs
        {
            placeholderText = placeholderName
        });

        button.Setup(new ButtonArgs
        {
            label = submitText,
            invoke = ()=>Debug.Log(inputField.GetText())
        });
    }

}
