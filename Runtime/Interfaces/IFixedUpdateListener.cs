using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public interface IFixedUpdateListener<T>
    {

        public void OnFixedUpdate(T t);

    }
}
