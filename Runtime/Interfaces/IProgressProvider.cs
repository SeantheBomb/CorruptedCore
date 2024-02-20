using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    public interface IProgressProvider
    {
        
        public float Progress { get; }

    }

    public interface IProgressProviderEvent
    {
        public System.Action<IProgressProvider> OnProgressUpdate
        {
            get; set;
        }
    }
}
