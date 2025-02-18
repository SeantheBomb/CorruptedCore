using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    [RequireComponent(typeof(Rigidbody))]
    public class PooledRigidbody : MonoBehaviour, ISpawnPool
    {

        Rigidbody rb;
        public void Destroy()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        public void Spawn()
        {

        }
    }
}