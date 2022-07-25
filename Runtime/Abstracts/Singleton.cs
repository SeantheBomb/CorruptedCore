using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {

        [Header("Singleton")]
        public BoolVariable dontDestroy;

        static Singleton<T> _instance;
        public static T Instance => (T)_instance;

        public static System.Action<T> OnInstanceStart, OnInstanceDestroyed;

        // Start is called before the first frame update
        void Start()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                Debug.Log($"{typeof(T)}: Destroyed duplicate instance");
                return;
            }
            if (dontDestroy)
                DontDestroyOnLoad(gameObject);
            _instance = this;
            OnStart();
            OnInstanceStart?.Invoke(Instance);
        }

        private void OnDestroy()
        {
            OnInstanceDestroyed?.Invoke(Instance);
            OnDestroyed();
        }

        public virtual void OnStart() { }

        public virtual void OnDestroyed() { }

    }
}