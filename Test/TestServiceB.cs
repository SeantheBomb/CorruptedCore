using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class TestServiceB : Service<TestServiceB>
{

    public static CorruptedBehaviour<TestData> TestBehaviourB = new CorruptedBehaviour<TestData>((td) =>
    {
        Debug.Log(td.index);
    }, new CorruptedAssertion<TestData>[]{
        new CorruptedAssertion<TestData>((td)=>td.index % 2 == 0, "TD index {0} has no text!")
        });


    //public override SynchronizationList OnSubscribeSynchronization()
    //{
    //    SynchronizationList syncList = new SynchronizationList();
    //    syncList.Add(new CorruptedSynchronization<TestData>(TestBehaviourA));
    //    return syncList;
    //}
}



