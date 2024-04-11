using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnUI : MonoBehaviour
{

    public UIData data;
    public UIKit kit;

    // Start is called before the first frame update
    void Start()
    {
        UIFactory.DefaultUIKit = kit;
        UIFactory.BuildUI(data, transform); 
    }


}
