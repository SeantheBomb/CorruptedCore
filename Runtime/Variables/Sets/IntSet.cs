using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    [CreateAssetMenu(fileName = "IntSet", menuName = "Corrupted/Sets/Int", order = 0)]
    public class IntSet : CorruptedSet<int>
    {
    }

    [System.Serializable]
    public class IntSetRef : CorruptedSetRef<int> { }
}
