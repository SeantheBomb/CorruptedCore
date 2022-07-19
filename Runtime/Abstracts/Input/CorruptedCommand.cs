using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{
    [System.Serializable]
    public abstract class CorruptedCommand : CorruptedModel
    {


        public abstract void StartExecute();

        public abstract void WhileExecute();

        public abstract void EndExecute();

        public virtual void OnStart() { }

        public virtual void Undo() { Debug.LogError($"{this.GetType()}: Command Undo is not implemented"); }

    }


    [System.Serializable]
    public abstract class CorruptedCommand<T> : CorruptedModel
    {


        public abstract void StartExecute(T t);

        public abstract void WhileExecute(T t);

        public abstract void EndExecute(T t);

        public virtual void OnStart(T t) { }

        public virtual void Undo(T t) { Debug.LogError($"{this.GetType()}: Command Undo is not implemented"); }

    }

}
