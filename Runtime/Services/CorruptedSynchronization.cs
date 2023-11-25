using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//public abstract class CorruptedSynchronization
//{
//    public abstract void OnBehaviourInvoked<T>(BehaviourInvokeData<T> invoke) where T : IParameter;
//}

public class CorruptedSynchronization<T> /*: CorruptedSynchronization*/ where T : IParameter
{


    private CorruptedBehaviour<T>[] synchronize;

    private bool inProgress;
    
    public CorruptedSynchronization(params CorruptedBehaviour<T>[] synchronize)
    {
        this.synchronize = synchronize;
        CorruptedBehaviour<T>.OnBehaviourInvoked += OnBehaviourInvoked;
        Debug.Log($"CorruptedSynchronization: subscribed");
    }

    ~CorruptedSynchronization()
    {
        CorruptedBehaviour<T>.OnBehaviourInvoked -= OnBehaviourInvoked;
    }

    //public override void OnBehaviourInvoked<K>(BehaviourInvokeData<K> invoke)
    //{
        
    //}

    private void OnBehaviourInvoked(BehaviourInvokeData<T> invoke)
    {
        if (inProgress)
            return;
        if (synchronize.Any((s) => invoke.behaviour.Equals(s)) == false)
            return;

        inProgress = true;
        foreach(var s in synchronize)
        {
            if (s.Equals(invoke.behaviour))
                continue;

            s.Invoke(invoke.concept, invoke.parameter);
        }
        inProgress = false;
    }

}


//public class SynchronizationList
//{

//    private Dictionary<Type, List<object>> syncList = new Dictionary<Type, List<object>>();

//    public void Add<K>(K sync)
//    {
//        if (syncList.ContainsKey(typeof(K)) == false)
//        {
//            syncList.Add(typeof(K), new List<object>());
//        }


//        syncList[typeof(K)].Add(sync);

//    }


//    public void AddRange<K>(K[] syncRange) where K : CorruptedSynchronization<IParameter>
//    {
//        if (syncList.ContainsKey(typeof(K)) == false)
//        {
//            syncList.Add(typeof(K), new List<object>(syncRange));
//        }

//        syncList[typeof(K)].AddRange(syncRange);
//    }

//    public void AddRange(SynchronizationList syncRange)
//    {
//        foreach(Type type in syncRange.syncList.Keys)
//        {
//            AddRange(syncRange.syncList[type].ToArray());
//        }
//    }

//    public K[] GetList<K>() where K : CorruptedSynchronization<IParameter>
//    {

//        if(syncList.ContainsKey(typeof(K)) == false)
//        {
//            return null;
//        }

//        List<object> list = syncList[typeof(K)];

//        K[] newList = new K[list.Count];

//        for (int i = 0; i < list.Count; i++)
//        {
//            newList[i] = (K)list[i];
//        }
//        return newList;
//    }


//    public void Remove<K>(K sync) where K : CorruptedSynchronization<IParameter>
//    {
//        if (syncList.ContainsKey(typeof(K)) == false)
//        {
//            return;
//        }
//        if(syncList[typeof(K)].Contains(sync) == false)
//        {
//            return;
//        }

//        syncList[typeof(K)].Remove(sync);
//    }
    



//}
