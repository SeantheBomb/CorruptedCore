using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public abstract class CorruptedKeyRegister<T> : CorruptedMap<string, T>
    {

    }

    [System.Serializable]
    public abstract class CorruptedKeyRegRef<T> : CorruptedMapRef<string, T> { }
}
