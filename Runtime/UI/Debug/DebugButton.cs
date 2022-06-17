using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

[RequireComponent(typeof(Button))]
public class DebugButton : MonoBehaviour
{

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    [Button]
    void PressButton()
    {
        button.onClick.Invoke();
    }

    public void DebugMessage(string message)
    {
        Debug.Log("Button: " + message);
    }
}
