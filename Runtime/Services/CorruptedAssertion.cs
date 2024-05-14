using Corrupted;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CorruptedAssertion<T> where T : IParameter
{

    

    private Func<T, bool> Assertion;

    public string errorMessage;

    public CorruptedAssertion(Func<T, bool> assertion, string error = "Assertion Failed")
    {
        Assertion = assertion;
        errorMessage = error;
    }

    public bool Assert(T t, out string errorOutput)
    {
        errorOutput = "";
        if(Assertion(t) == false)
        {
            errorOutput = String.Format(errorMessage, t.GetValues());
            return false;
        }
        return true;
    }

}
