using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{

    [RequireComponent(typeof(AudioSource))]
    public class CorruptedAudioSource : CorruptedBehaviour
    {

        public CorruptedAudioEvent audioEvent;

        AudioSource source;

        public override void Start()
        {
            base.Start();
            source = GetComponent<AudioSource>();
        }

        public virtual void Play()
        {
            audioEvent.Play(source);
        }

    }
}
