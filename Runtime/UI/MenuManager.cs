using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager 
{

    public static List<MenuPanel> panels = new List<MenuPanel>();

    public static void SetMenuActive(string key)
    {
        foreach(MenuPanel panel in panels)
        {
            panel.gameObject.SetActive(panel.instanceKey == key);
        }
    }

}
