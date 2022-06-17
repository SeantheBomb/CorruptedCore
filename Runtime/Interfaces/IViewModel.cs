using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{
    public interface IViewModel
    {
        // Start is called before the first frame update
        public void OnStart(CorruptedBehaviour behaviour);

        public void Destroy(CorruptedBehaviour behaviour);

    }

    public interface IViewModelEnable
    {
        public void Enable(CorruptedBehaviour behaviour);

        public void Disable(CorruptedBehaviour behaviour);
    }

    public interface IViewModelUpdate
    {
        public void OnUpdate(CorruptedBehaviour behaviour);

    }

    public interface IViewModelLateUpdate
    {
        public void OnLateUpdate(CorruptedBehaviour behaviour);
    }

    public interface IViewModelFixedUpdate
    {
        public void OnFixedUpdate(CorruptedBehaviour behaviour);
    }

    public interface IViewModel<T> where T : CorruptedBehaviour
    {
        // Start is called before the first frame update
        public void OnStart(T behaviour);

        public void Destroy(T behaviour);

    }

    public interface IViewModelEnable<T> where T : CorruptedBehaviour
    {
        public void Enable(T behaviour);

        public void Disable(T behaviour);
    }

    public interface IViewModelUpdate<T> where T : CorruptedBehaviour
    {
        public void OnUpdate(T behaviour);

    }

    public interface IViewModelLateUpdate<T> where T : CorruptedBehaviour
    {
        public void OnLateUpdate(T behaviour);
    }

    public interface IViewModelFixedUpdate<T> where T : CorruptedBehaviour
    {
        public void OnFixedUpdate(T behaviour);
    }
}