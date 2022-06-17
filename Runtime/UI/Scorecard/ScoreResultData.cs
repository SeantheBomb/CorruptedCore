using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using System;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Score Result", menuName = "Corrupted/Scoreboard/Result")]
public class ScoreResultData : CorruptedModel
{

    public string label;
    public Sprite icon;
    public Color color;
    public FloatVariable priority;

}



