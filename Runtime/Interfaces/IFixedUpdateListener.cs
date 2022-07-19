using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public interface IFixedUpdateListener
    {

        public void OnFixedUpdate(Rigidbody rb);

    }
}
