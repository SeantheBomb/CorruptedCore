using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    /// <summary>
    /// A Corrupted model (scriptable object) that stores a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CorruptedValue<T> : CorruptedModel
    {
        public T Value;
    }
}
