using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Corrupted
{

    [RequireComponent(typeof(ParticleSystem))]
    public class PooledParticleSystem : MonoBehaviour, ISpawnPool
    {
        ParticleSystem ps;
        Vector3 scale;

        public void Spawn()
        {
            if (ps == null)
                ps = GetComponent<ParticleSystem>();
            ps.Play();
            scale = transform.localScale;
        }

        void OnEnable()
        {
            if (ps == null)
                ps = GetComponent<ParticleSystem>();
            if (ps.main.loop == false)
                StartCoroutine(DisableAfterComplete());
        }

        IEnumerator DisableAfterComplete()
        {
            yield return new WaitForSeconds(ps.main.duration);
            CorruptedPooler.Destroy(gameObject);
        }


        public void Destroy()
        {
            if (ps == null)
                ps = GetComponent<ParticleSystem>();
            ps.Stop();
            transform.localScale = scale;
        }


    }
}