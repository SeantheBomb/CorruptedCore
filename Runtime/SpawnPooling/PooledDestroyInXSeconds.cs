using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public class PooledDestroyInXSeconds : MonoBehaviour, ISpawnPool
    {

        public float seconds;

        public void Destroy()
        {
        }

        public void Spawn()
        {
            StartCoroutine(StartTimer());
        }

        // Start is called before the first frame update
        IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(seconds);
            CorruptedPooler.Destroy(gameObject);
        }


    }
}