using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Corrupted;

public class CorruptedBehaviour<T> where T : IParameter
{ 

    public static Action<BehaviourInvokeData<T>> OnBehaviourInvoked;

    public static Action<BehaviourAssertionData<T>> OnAssertionFailed;

    private Action<T> InvokeBehaviour;

    private CorruptedAssertion<T>[] assertions;

    public CorruptedBehaviour(Action<T> Behaviour, CorruptedAssertion<T>[] assert = null)
    {
        InvokeBehaviour = Behaviour;
        assertions = assert;
    }

    public void Invoke(IService concept, T t)
    {
        BehaviourInvokeData<T> invoke = new BehaviourInvokeData<T>() { concept = concept, behaviour = this, parameter = t };
        if(assertions != null)foreach (var a in assertions)
        {
            if(a.Assert(t, out string error) == false)
            {
                BehaviourAssertionData<T> assert = new BehaviourAssertionData<T>() { behaviour = invoke, assertion = a, errorMessage = error };
                OnAssertionFailed?.Invoke(assert);
                return;
            }
        }
        InvokeBehaviour?.Invoke(t);
        OnBehaviourInvoked?.Invoke(invoke);
    }

    public override bool Equals(object obj)
    {
        if(obj is CorruptedBehaviour<T> cb)
        {
            return InvokeBehaviour == cb.InvokeBehaviour;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }



}

public struct BehaviourInvokeData<T>  where T : IParameter
{
    public IService concept;
    public CorruptedBehaviour<T> behaviour;
    public T parameter;


}

public struct BehaviourAssertionData<T> where T : IParameter
{
    public BehaviourInvokeData<T> behaviour;
    public CorruptedAssertion<T> assertion;
    public string errorMessage;


}