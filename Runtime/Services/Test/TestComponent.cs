using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TestModel", menuName = "Test/Service/TestModel")]
public class TestComponent : ServiceModel
{

    public TestData testNum;

    CorruptedSynchronization<TestData> sync;


    public override void OnInitialize()
    {
        Debug.Log($"{name} on initialize with number {testNum.index}");
    }

    // Start is called before the first frame update
    public override void StartService()
    {
        CorruptedBehaviour<TestData>.OnAssertionFailed += OnAssertionFailed;
        //sync = new CorruptedSynchronization<TestData>(TestServiceA.TestBehaviourA, TestServiceB.TestBehaviourB);
        //TestServiceA.TestBehaviourA.Invoke(this, new TestData { text = name, index = testNum });
    }

    public override void StopService()
    {
        CorruptedBehaviour<TestData>.OnAssertionFailed -= OnAssertionFailed;
    }

    




    public void OnAssertionFailed(BehaviourAssertionData<TestData> td)
    {
        Debug.LogError(td.errorMessage);
    }

}

[Serializable]
public struct TestData : IParameter
{
    public string text;
    public int index;

    public object[] GetValues()
    {
        return new object[] { text, index };
    }
}
