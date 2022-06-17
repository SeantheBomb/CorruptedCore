using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NaughtyAttributes;
using Corrupted;

public class ScoreTaskView : MonoBehaviour
{


    [Header("Data")]
    public ScoreTask task;
    public ScoreResultData passResult;

    [Header("References")]
    public Image resultImage;

    public TMP_Text taskName, taskResult, failureMessage;

    public Image[] backgrounds;


    //[Header("View")]
    //public Sprite passImage;
    //public Sprite failImage;
    //public StringVariable passText, failText;


    public void UpdateView(string taskName, string result, string failure, Sprite image, Color color)
    {
        if (this.taskName != null)
        {
            this.taskName.text = taskName;
        }
        //this.taskName.color = color;
        if (this.taskResult != null)
        {
            this.taskResult.text = result;
            this.taskResult.color = color;
        }
        if (this.resultImage != null)
        {
            this.resultImage.sprite = image;
        }
        if (this.failureMessage != null)
        {
            this.failureMessage.text = failure;
        }
        foreach(Image i in backgrounds)
        {
            i.color = color;
        }
    }

    public void UpdateView(ScoreTask task)
    {
        gameObject.SetActive(true);//task.completed);
        ScoreResultData result = task.passed ? passResult : task.GetResultData();
        UpdateView(task.task, result.label, task.GetFailedDescription(), result.icon, result.color);
    }

    [Button]
    public void UpdateView()
    {
        UpdateView(task);
    }

    [Button]
    public void ClearView()
    {
        UpdateView("NULL", "NULL", "NULL", null, Color.white);
    }
}
