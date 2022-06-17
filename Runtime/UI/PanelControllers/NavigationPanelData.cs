using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NavigationPanel", menuName = "UI/Panel/Navigation")]
public class NavigationPanelData : ScriptableObject
{
    public string header = "Header";

    [TextArea]
    public string body = "Body Text";

    public string yesOption = "Yes";
    public string noOption = "No";
}
