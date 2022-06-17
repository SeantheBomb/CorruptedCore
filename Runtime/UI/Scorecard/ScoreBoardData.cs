using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "ScoreboardData", menuName = "Corrupted/Scoreboard/Board")]
public class ScoreBoardData : CorruptedModel
{

    public StringVariable header;

    public ScoreTask[] tasks;

    public StringVariable nextOption, backOption;

    [Button]
    public void CompleteAllTasks()
    {
        foreach(ScoreTask task in tasks)
        {
            task.CompleteTask();
        }
    }

    [Button]
    public void ResetAllTasks()
    {
        foreach(ScoreTask task in tasks)
        {
            task.ResetTask();
        }
    }

    public float CalculateProgress()
    {
        int complete = 0;
        foreach(ScoreTask task in tasks)
        {
            if (task.completed)
                complete++;
        }
        return complete / (float)tasks.Length;
    }
}
