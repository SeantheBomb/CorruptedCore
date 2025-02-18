using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    [RequireComponent(typeof(TrailRenderer))]
    public class PooledTrailRenderer : MonoBehaviour, ISpawnPool
    {

        TrailRenderer lr;

        public void Destroy()
        {
            if (lr == null)
                lr = GetComponent<TrailRenderer>();
            lr.Clear();
        }

        public void Spawn()
        {

        }
    }
}