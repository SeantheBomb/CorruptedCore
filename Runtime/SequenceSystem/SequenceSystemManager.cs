using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;

public class SequenceSystemManager : CorruptedBehaviour<SequenceSystemManager>
{

    public System.Action OnSequenceComplete;
    public static System.Action<SequenceSystemManager, GraphNode> OnSequenceUpdate;

    public SequenceGraph activeGraph;

    public bool inProgress
    {
        get
        {
            return current != null;
        }
    }
    public GraphNode current
    {
        get; protected set;
    }



    //Coroutine coroutine;
    Dictionary<GraphNode, Coroutine> innerCoroutines;



    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
        if(innerCoroutines == null)
        innerCoroutines = new Dictionary<GraphNode, Coroutine>();
        //DontDestroyOnLoad(gameObject);
        //yield return null;
        //ResetSequence();
    }

    public void UpdateSequence(GraphNode node)
    {
        if (node == null)
        {
            Debug.LogError("DialogueView: Null node received!", gameObject);
        }
        else
        {
            node.RunTask(this);
            OnSequenceUpdate?.Invoke(this, node);
        }

    }


    public void PlaySequence()
    {
        if (inProgress)
        {
            Resume();
            return;
        }
        UpdateSequence(activeGraph.GetEntry());
    }

    public void PlaySequence(SequenceGraph graph)
    {
        activeGraph = graph;
        PlaySequence();
    }

    public void StopSequence(SequenceGraph graph)
    {
        foreach(GraphNode n in graph.nodes)
        {
            InterruptTask(n);
        }
    }

    public void StopSequence()
    {
        StopSequence(activeGraph);
    }


    public void Resume()
    {
        UpdateSequence(current);
    }

    public void SkipCurrent()
    {
        if (current.link != null)
        {
            StopCoroutines();
            current = current.link;
            PlaySequence();
        }
    }

    public Coroutine StartTrack(GraphNode n, Coroutine cr)
    {
        //Debug.Log("Sequence: Start tracking node " + n.name, n);
        if (innerCoroutines == null)
            innerCoroutines = new Dictionary<GraphNode, Coroutine>();
        if (innerCoroutines.ContainsKey(n))
        {
            StopTrack(n);
        }
        innerCoroutines.Add(n, cr);
        return StartCoroutine(n.RunTaskCR(this));
        //yield return StartCoroutine(cr);
        //innerCoroutines.Remove(cr);
    }

    public void StopTrack(GraphNode n)
    {
        //Debug.Log("Sequence: Stop tracking node " + n.name, n);
        innerCoroutines.Remove(n);
        StopCoroutine(n.coroutine);
        n.coroutine = null;
    }

    public void InterruptTask(GraphNode n)
    {
        if (innerCoroutines.ContainsKey(n) == false)
        {
            //Debug.LogError("SequenceSystem: Interrupted coroutine is not running!");
            return;
        }
        n.StopTask(this);
        //StopCoroutine(innerCoroutines[n]);
    }

    public void StopCoroutines()
    {
        //StopCoroutine(coroutine);
        foreach (var cr in innerCoroutines)
        {
            StopCoroutine(cr.Value);
            cr.Key.coroutine = null;
        }
        innerCoroutines.Clear();
    }

    public void StopCoroutines(GraphNode g)
    {
        foreach (var cr in innerCoroutines)
        {
            if (cr.Key == g)
                continue;
            StopCoroutine(cr.Value);
            cr.Key.coroutine = null;
        }
        innerCoroutines.Clear();
    }

    //public void DoBehaviour<T>(System.Action<T> action) where T : MonoBehaviour
    //{
    //    T t = GetComponentInChildren<T>();
    //    if(t == null)
    //    {
    //        Debug.LogError($"SequenceSystem: {name} failed to do behaviour because it does not contain type {typeof(T)}!", gameObject);
    //        return;
    //    }
    //    action?.Invoke(t);
    //}


    public static GameObject GetDynamicObject(string objectKey)
    {
        return DynamicObjectIndex.GetObject(objectKey);
    }

   




}
