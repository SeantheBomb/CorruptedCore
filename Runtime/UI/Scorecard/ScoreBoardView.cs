using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NaughtyAttributes;
using Corrupted;

public class ScoreBoardView : MenuPanel
{

    public System.Action OnNextButtonPressed, OnBackButtonPressed;


    [Header("Data")]
    public ScoreBoardData data;
    public StringVariable perfectScenarioText;

    [Header("References")]
    public Transform taskViewBody;
    public TMP_Text header;
    public TMP_Text whatWentWrongText;
    [SerializeField] Button nextButton;
    [SerializeField] Button backButton;
    TMP_Text nextText;
    TMP_Text backText;

    [Header("View")]
    public ScoreTaskView taskPrefab;

    ScoreTaskView[] taskViews;





    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        nextButton.onClick.AddListener(() => OnNextButtonPressed());
        backButton.onClick.AddListener(() => OnBackButtonPressed());
        GetButtonText();
        if (data != null)
            SetupPanel();
        gameObject.SetActive(false);
    }

    public void SetupPanel(string header, ScoreTask[] tasks, string nextText, string backText)
    {
        GetButtonText();
        ClearBoard();
        this.header.text = header;
        this.nextText.text = nextText;
        this.backText.text = backText;
        whatWentWrongText.text = CompileFailureResult(tasks);
        whatWentWrongText.enabled = false;
        whatWentWrongText.enabled = true;
        PopulateScoreTasks(tasks);
    }

    public void SetupPanel(ScoreBoardData data)
    {
        SetupPanel(data.header, data.tasks, data.nextOption, data.backOption);
    }

    [Button]
    public void SetupPanel()
    {
        SetupPanel(data);
    }

    [Button]
    public void ClearBoard()
    {
        DeleteTaskViews();
        whatWentWrongText.text = "";
    }

    void DeleteTaskViews()
    {
        if (taskViews == null)
            return;
        foreach(ScoreTaskView task in taskViews)
        {
            //if(task!=null)
            //CorruptedHelper.RemoveObject(task.gameObject);
        }
        taskViews = null;
    }

    void GetButtonText()
    {
        if(nextText == null)
            nextText = nextButton.GetComponentInChildren<TMP_Text>();
        if(backText == null)
            backText = backButton.GetComponentInChildren<TMP_Text>();
    }

    protected void PopulateScoreTasks(ScoreTask[] tasks)
    {
        taskViews = new ScoreTaskView[tasks.Length];
        for (int i = 0; i < tasks.Length; i++)
        {
            taskViews[i] = Instantiate(taskPrefab, taskViewBody);
            taskViews[i].UpdateView(tasks[i]);
        }
    }

    protected string CompileFailureResult(ScoreTask[] tasks)
    {
        string result = "";
        foreach (ScoreTask task in tasks)
        {
            //Debug.Log("ScoreboardView: Check result " + task.name + " has result " + task.result, task);
            if(task.passed == false)
            {
                result += task.GetFailedDescription() + "\n\n";
            }
        }
        if(string.IsNullOrWhiteSpace(result))
        {
            result = perfectScenarioText;
        }
        return result;
    }
}
