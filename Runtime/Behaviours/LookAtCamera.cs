using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public class LookAtCamera : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(Camera.main.transform);   
        }
    }
}
