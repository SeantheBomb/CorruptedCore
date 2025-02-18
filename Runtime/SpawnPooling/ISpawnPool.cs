using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public interface ISpawnPool
    {
        void Spawn();

        void Destroy();
    }
}