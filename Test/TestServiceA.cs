using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class TestServiceA : Service<TestServiceA>
{

    public static CorruptedBehaviour<TestData> TestBehaviourA = new CorruptedBehaviour<TestData>((td) =>
    {
        Debug.Log(td.text);
    }, new CorruptedAssertion<TestData>[]{
        new CorruptedAssertion<TestData>((td)=>string.IsNullOrWhiteSpace(td.text) == false, "TD index {0} has no text!")
        });


    public static CorruptedSynchronization<TestData> TestSyncA;





    public override void OnInitialize()
    {
        Debug.Log("Initialize Test Service A");
         TestSyncA = new CorruptedSynchronization<TestData>(
        TestBehaviourA,
        TestServiceB.TestBehaviourB
        );
    }
}



