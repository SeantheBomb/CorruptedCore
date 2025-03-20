using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corrupted
{
    public static class CorruptedPooler
    {
        static Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();
        static Dictionary<GameObject, GameObject> activeObjects = new Dictionary<GameObject, GameObject>();

        [RuntimeInitializeOnLoadMethod]
        public static void SubscribeEvents()
        {
            SceneManager.sceneUnloaded += OnSceneUnload;
        }

        private static void OnSceneUnload(Scene unloaded)
        {
            pools.Clear();
            activeObjects.Clear();
        }

        public static GameObject Spawn(GameObject prefab, Transform parent = null)
        {
            if (parent == null)
            {
                return Spawn(prefab, Vector3.zero, Quaternion.identity, null);
            }
            else
            {
                return Spawn(prefab, parent.position, parent.rotation, parent);
            }
        }


        public static GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent = null)
        {
            if (pools.ContainsKey(prefab) == false)
            {
                pools.Add(prefab, new ObjectPool(prefab));
            }
            GameObject obj = pools[prefab].Spawn(pos, rot, parent);
            activeObjects.Add(obj, prefab);
            return obj;
        }

        public static T Spawn<T>(T prefab, Transform parent = null) where T : MonoBehaviour, ISpawnPool
        {
            if (parent == null)
            {
                return Spawn(prefab, Vector3.zero, Quaternion.identity, null);
            }
            else
            {
                return Spawn(prefab, parent.position, parent.rotation, parent);
            }
        }

        public static T Spawn<T>(T prefab, Vector3 pos, Quaternion rot, Transform parent = null) where T : MonoBehaviour, ISpawnPool
        {

            if (pools.ContainsKey(prefab.gameObject) == false)
            {
                pools.Add(prefab.gameObject, new ObjectPool(prefab.gameObject));
            }
            GameObject obj = pools[prefab.gameObject].Spawn(pos, rot, parent);
            activeObjects.Add(obj, prefab.gameObject);
            return obj.GetComponent<T>();
        }

        public static void Destroy(GameObject obj)
        {
            if (activeObjects.ContainsKey(obj) == false)
            {
                Debug.LogError($"CorruptedPooler: Object {obj.name} was completely destroyed because it is not pooled!");
                GameObject.Destroy(obj);
                return;
            }

            GameObject prefab = activeObjects[obj];
            pools[prefab].Destroy(obj);
            activeObjects.Remove(obj);
        }

        public static void Destroy<T>(T obj) where T : MonoBehaviour, ISpawnPool
        {
            if (activeObjects.ContainsKey(obj.gameObject) == false)
            {
                Debug.LogError($"CorruptedPooler: Object {obj.name} was completely destroyed because it is not pooled!");
                GameObject.Destroy(obj);
                return;
            }

            GameObject prefab = activeObjects[obj.gameObject];
            pools[prefab].Destroy(obj.gameObject);
            activeObjects.Remove(obj.gameObject);
        }

        static void CallObjectSpawn(GameObject obj, Vector3 pos, Quaternion rot, Transform parent)
        {
            if (obj == null)
            {
                Debug.LogError($"CorruptedPooler: Can not call object spawn because it has been destroyed externally");
                return;
            }
            Debug.Log($"CorruptedPooler: Spawn {obj.name} at time {Time.time}");
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.transform.parent = parent;
            obj.gameObject.SetActive(true);
            foreach (ISpawnPool child in obj.GetComponentsInChildren<ISpawnPool>())
            {
                //Debug.Log($"CorruptedPooler: Call Spawn On {obj.name} behaviour {child.GetType()}");
                child.Spawn();
            }
        }

        static void CallObjectDestroy(GameObject obj)
        {
            if (obj == null)
            {
                Debug.LogError($"CorruptedPooler: Can not disable object because it has been destroyed externally");
                return;
            }
            foreach (ISpawnPool child in obj.GetComponentsInChildren<ISpawnPool>())
            {
                child.Destroy();
            }
            obj.gameObject.SetActive(false);
        }


        class ObjectPool
        {
            GameObject prefab;
            List<GameObject> activeObjects;
            Queue<GameObject> pooledObjects;

            public ObjectPool(GameObject prefab)
            {
                this.prefab = prefab;
                activeObjects = new List<GameObject>();
                pooledObjects = new Queue<GameObject>();
            }

            public GameObject Spawn(Vector3 pos, Quaternion rot, Transform parent)
            {
                GameObject spawned;
                if (pooledObjects.Count > 0)
                {
                    spawned = pooledObjects.Dequeue();
                }
                else
                {
                    spawned = GameObject.Instantiate(prefab, pos, rot, parent);
                }
                activeObjects.Add(spawned);
                CallObjectSpawn(spawned, pos, rot, parent);
                return spawned;
            }

            public void Destroy(GameObject obj)
            {
                if (activeObjects.Contains(obj) == false)
                {
                    Debug.LogError($"CorruptedPooler: Can not destroy {obj} because it is not active!");
                    return;
                }
                activeObjects.Remove(obj);
                CallObjectDestroy(obj);
                if (obj != null)
                    pooledObjects.Enqueue(obj);
            }
        }
    }
}