using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    public abstract class CorruptedAudioEvent : CorruptedModel
    {
        public abstract void Play(AudioSource source);
    }
}
