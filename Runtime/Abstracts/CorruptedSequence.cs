using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{


    public abstract class CorruptedSequence : CorruptedModel
    {
        public abstract IEnumerator Sequence(CorruptedBehaviour behaviour);
    }


    public abstract class CorruptedSequence<T> : CorruptedModel where T : CorruptedBehaviour
    {
        public abstract IEnumerator Seuence(T behaviour);
    }
}
