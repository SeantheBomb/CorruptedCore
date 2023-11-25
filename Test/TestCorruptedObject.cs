using Corrupted;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TestCorruptedObject", menuName = "Test/Object")]
public class TestCorruptedObject : CorruptedObject
{

    public int testInt = 0;
    public string testString = "Hello World";
    public TestStruct testStruct;


    protected override void Start()
    {
        Debug.Log("Start " + testString + " " + testInt + " " + testStruct.structInt);
        testInt++;
        testStruct.structInt += 10;
    }

    protected override void OnDestroy()
    {
        testInt -= 10;
        testString += "Destroyed";
        Debug.Log("End " + testString + " " + testInt + " " + testStruct.structInt);
    }
}


[Serializable]
public struct TestStruct
{
    public int structInt;
}
