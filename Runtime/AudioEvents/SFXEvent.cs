using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted {

    [CreateAssetMenu(fileName = "SFXEvent", menuName = "Corrupted/Audio/SFXEvent")]
    public class SFXEvent : CorruptedAudioEvent
    {

        public AudioClip[] clips;
        public RangedFloat volume = 1f;
        [MinMaxRange(0, 2)]
        public RangedFloat pitch = 1f;
        public bool loop;

        [Range(0f,1f)]
        public float spatialBlend = 1f;

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0) return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = RandomFloat.Range(volume);
            source.pitch = RandomFloat.Range(pitch);
            source.loop = loop;
            source.spatialBlend = spatialBlend;
            source.Play();
        }
    }
}