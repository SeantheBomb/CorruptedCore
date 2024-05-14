using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public interface ICoroutineModel
        
    {


        public IEnumerator RunCoroutine(CoroutineRunner runner);

    }
}
