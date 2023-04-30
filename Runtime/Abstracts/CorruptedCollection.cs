using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public abstract class CorruptedCollection<K,T> : MonoBehaviour where T : CorruptedCollection<K,T>
    {

        protected static Dictionary<K, List<T>> instances = new Dictionary<K, List<T>>();
        [Header("Instance Key")]
        public K instanceKey;

        public virtual void Start()
        {
            if (instanceKey != null)
            {
                if (instances.ContainsKey(instanceKey) == false)
                {
                    instances.Add(instanceKey, new List<T>());
                }
                instances[instanceKey].Add(this as T);

                //DynamicObjectIndex.AddGameObject(instanceKey, gameObject);
            }
        }


        public virtual void OnDestroy()
        {
            if (instanceKey != null)
            {
                instances[instanceKey].Remove(this as T);
                //DynamicObjectIndex.RemoveGameObject(instanceKey);
            }
        }

        public static T GetInstance(K key, int index = 0)
        {
            if (instances.ContainsKey(key) == false)
            {
                Debug.LogError($"{typeof(T)}: Can not return instance of key \"{ key}\" becuse it does not exist!");
                return null;
            }
            if (index < 0 || index >= instances[key].Count)
                return null;
            return instances[key][index];
        }

        public static int GetInstanceCount(K key)
        {
            if (instances.ContainsKey(key) == false)
            {
                Debug.LogError($"{typeof(T)}: Can not return instance of key \"{ key}\" becuse it does not exist!");
                return 0;
            }
            return instances[key].Count;
        }
    }

    
}
