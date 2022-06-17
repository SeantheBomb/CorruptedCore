using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;
using System;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Score Task", menuName = "Corrupted/Scoreboard/Task")]
public class ScoreTask : CorruptedModel
{
    public string task;

    

    [SerializeField]TaskRequirement[] requirements;
    
    //public ScoreResult result;

    public bool completed => GetCompleted();

    public bool passed => GetResult();

    public bool locked { get; protected set; }


    //private void OnValidate()
    //{
    //    if (task != null) name = task;
    //}

    private void OnEnable()
    {
       foreach(TaskRequirement tr in requirements)
        {
            tr.OnEnable();
        } 
    }

    private void OnDisable()
    {
        foreach (TaskRequirement tr in requirements)
        {
            tr.OnDisable();
        }
    }

    public void SetResult(bool passed)
    {
        foreach (TaskRequirement r in requirements)
        {
            r.SetPass(passed);
        }
    }

    public bool GetResult()
    {
        foreach(TaskRequirement r in requirements)
        {
            if (r.passed == false)
                return false;
        }
        return true;
    }

    public ScoreResultData GetResultData()
    {
        ScoreResultData highestData = null;
        float highestPriority = 0f;
        foreach(TaskRequirement fail in GetFailedRequirements())
        {
            if(fail.result.priority > highestPriority || highestData == null)
            {
                highestData = fail.result;
                highestPriority = fail.result.priority;
            }
        }
        return highestData;
    }

    public TaskRequirement[] GetFailedRequirements()
    {
        List<TaskRequirement> fails = new List<TaskRequirement>();
        foreach(TaskRequirement tr in requirements)
        {
            if (tr.passed == false)
                fails.Add(tr);
        }
        return fails.ToArray();
    }

    public string GetFailedDescription()
    {
        string result = "";
        foreach(TaskRequirement fail in GetFailedRequirements())
        {
            result += fail.FailureDescription + "\n\n";
        }
        return result;
    }

    public void SetCompleted(bool completed)
    {
        foreach (TaskRequirement r in requirements)
        {
            if (completed)
                r.Complete();
            else
                r.Reset();
        }
    }

    public void SetLock(bool state)
    {
        foreach(TaskRequirement r in requirements)
        {
            r.SetLock(state);
        }
    }

    public bool GetCompleted()
    {
        foreach (TaskRequirement r in requirements)
        {
            if (r.hasCompleted == false)
                return false;
        }
        Debug.Log(this);
        return true;
    }

    [Button]
    public void CompleteTask()
    {
        foreach (TaskRequirement r in requirements)
        {
            r.Complete();
        }
    }

    [Button]
    public void ResetTask()
    {
        foreach (TaskRequirement r in requirements)
        {
            r.Reset();
            r.SetLock(false);
        }
    }

    [Button]
    public void LockTask()
    {
        SetLock(true);
    }

    [Button]
    public void UnlockTask()
    {
        SetLock(false);
    }

}

[Serializable]
public class TaskRequirement
{

    [Header("Output")]
    [TextArea]
    public string FailureDescription;
    public ScoreResultData result;


    [Header("Flags")]
    public TaskFlag[] flags;
    public bool hasCompleted => IsComplete();
    protected bool initialValue;
    public bool RequirementIsSuccessfulIfAnyFlagSuccededs;

    public bool passed => GetPassed();
    //public bool value => flag.Value;


    public void OnEnable()
    {
        foreach(TaskFlag tf in flags)
        {
            tf.OnEnable();
        }
    }

    public void OnDisable()
    {
        foreach (TaskFlag tf in flags)
        {
            tf.OnDisable();
        }
    }
    


    public void Reset()
    {
        foreach (TaskFlag flag in flags)
        {
            flag.Reset();
        }
    }

    public void Complete()
    {
        foreach (TaskFlag flag in flags)
        {
            flag.Complete();
        }
    }

    public bool IsComplete()
    {
        foreach(TaskFlag flag in flags)
        {
            if (flag.completed == false)
                return false;
        }
        return true;
    }


    public void SetPass(bool value)
    {
        foreach(TaskFlag flag in flags)
        {
            flag.SetPass(value);
        }
    }

    public void SetLock(bool state)
    {
        foreach(TaskFlag flag in flags)
        {
            flag.SetLock(state);
        }
    }

    public bool GetPassed()
    {
        foreach (TaskFlag flag in flags)
        {
            if (!RequirementIsSuccessfulIfAnyFlagSuccededs)
            {
                if (flag.passed == false)
                    return false;
            }
            else
            {
                if (flag.passed)
                    return true;
            }
        }
        return true;
    }


    [Serializable]
    public class TaskFlag
    {
        public FlagValue flag;
        public bool expectedValue = true;
        [HideInInspector]public bool completed = false;

        protected bool initialValue;

        public bool passed => value == expectedValue;
        public bool value => GetValue();

        //Lock the state of this flag, and it will no longer be affected by the source
        bool isLocked = false;
        bool lockedValue = false;

        public void OnEnable()
        {
            if(flag)flag.OnUpdated += Complete;
            initialValue = value;
        }

        public void OnDisable()
        {
            if (flag) flag.OnUpdated -= Complete;
        }


        public void Reset()
        {
            //flag.SetValue(initialValue);
            completed = false;
        }

        public void Complete()
        {
            //SetPass(true);
            completed = true;
        }

        void Complete(bool value)
        {
            Complete();
        }

        bool GetValue()
        {
            if (isLocked)
                return lockedValue;
            if (flag != null)
                return flag.Value;
            return false;
        }

        public void SetPass(bool value)
        {
            flag.SetValue( expectedValue == value);
        }

        public void SetLock(bool state)
        {
            if (state)
            {
                lockedValue = value;
            }
            isLocked = state;
        }
    }
}



