using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public interface IConvert<T>
    {

        public K ConvertTo<K>() where K : T;

    }
}
