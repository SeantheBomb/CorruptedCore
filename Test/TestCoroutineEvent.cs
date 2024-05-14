using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutineEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoroutineEvent ce = new CoroutineEvent();

        Debug.Log("Test Begin");

        ce.Add(TestA());
        ce.Add(TestB());

        ce.Invoke(this, () => Debug.Log("Test completed"));
    }




    IEnumerator TestA()
    {
        Debug.Log("Start Test A");
        yield return new WaitForSeconds(5f);
        Debug.Log("End Test A");
    }


    IEnumerator TestB()
    {
        Debug.Log("Start Test B");
        yield return new WaitForSeconds(3f);
        Debug.Log("End Test B");
    }

}
