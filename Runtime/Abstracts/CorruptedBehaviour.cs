using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public abstract class CorruptedBehaviour<K,T> : CorruptedBehaviour where T : CorruptedBehaviour<K,T>
    {

        static Dictionary<K, T> instances = new Dictionary<K, T>();
        [Header("Instance Key")]
        public K instanceKey;

        public override void Start()
        {
            base.Start();
            if (instanceKey != null)
            {
                if (instances.ContainsKey(instanceKey))
                    instances[instanceKey] = this as T;
                else
                    instances.Add(instanceKey, this as T);
                //DynamicObjectIndex.AddGameObject(instanceKey, gameObject);
            }
        }


        public override void OnDestroy()
        {
            base.OnDestroy();
            if (instanceKey != null)
            {
                instances.Remove(instanceKey);
                //DynamicObjectIndex.RemoveGameObject(instanceKey);
            }
        }

        public static T GetInstance(K key)
        {
            if (instances.ContainsKey(key) == false)
            {
                Debug.LogError($"{typeof(T)}: Can not return instance of key \"{ key}\" becuse it does not exist!");
                return null;
            }
            return instances[key];
        }
    }

    public abstract class CorruptedBehaviour<T> : CorruptedBehaviour where T : CorruptedBehaviour<T>
    {

        static Dictionary<string, T> instances = new Dictionary<string, T>();
        [Header("Instance Key")]
        public KeyVariable instanceKey;

        public override void Start()
        {
            base.Start();
            if (string.IsNullOrWhiteSpace(instanceKey) == false)
            {
                if (instances.ContainsKey(instanceKey))
                    instances[instanceKey] = this as T;
                else
                    instances.Add(instanceKey, this as T);
                DynamicObjectIndex.AddGameObject(instanceKey, gameObject);
            }
        }


        public override void OnDestroy()
        {
            base.OnDestroy();
            if (string.IsNullOrWhiteSpace(instanceKey))
            {
                instances.Remove(instanceKey);
                DynamicObjectIndex.RemoveGameObject(instanceKey);
            }
        }

        public static T GetInstance(string key)
        {
            if (instances.ContainsKey(key) == false)
            {
                Debug.LogError($"{typeof(T)}: Can not return instance of key \"{ key}\" becuse it does not exist!");
                return null;
            }
            return instances[key];
        }
    }

    public abstract class CorruptedBehaviour : MonoBehaviour
    {


        public virtual void Start()
        {

        }


        public virtual void OnDestroy()
        {

        }

        public T GetBehaviour<T>() where T : MonoBehaviour
        {
            T t = GetComponentInChildren<T>();
            if (t == null)
            {
                Debug.LogError($"{GetType()}: {name} can not get behaviour because it is missing component {typeof(T)}", gameObject);
                return null;
            }
            return t;
        }

        public bool DoBehaviour<T>(Action<T> action) where T : MonoBehaviour
        {
            T t = GetComponentInChildren<T>();
            if(t == null)
            {
                Debug.LogError($"{GetType()}: {name} can not run behaviour because it is missing component {typeof(T)}", gameObject);
                return false;
            }
            action?.Invoke(t);
            return true;
        }

        public bool DoBehaviour<T>(Action<T[]> action) where T : MonoBehaviour
        {
            T[] t = GetComponentsInChildren<T>();
            if (t == null)
            {
                Debug.LogError($"{GetType()}: {name} can not run behaviour because it is missing component {typeof(T)}", gameObject);
                return false;
            }
            action?.Invoke(t);
            return true;
        }
    }
}
