using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;

public abstract class MenuPanel : CorruptedBehaviour<MenuPanel>
{


    public override void Start()
    {
        base.Start();
        MenuManager.panels.Add(this);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        MenuManager.panels.Remove(this);
    }
}
