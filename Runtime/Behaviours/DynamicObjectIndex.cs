using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corrupted;

public class DynamicObjectIndex : MonoBehaviour
{

    public KeyVariable objectKey;

    public bool startDisabled = false;


    static Dictionary<string, GameObject> dynamicObjects = new Dictionary<string, GameObject>();

    public static void AddGameObject(string key, GameObject go)
    {
        if (dynamicObjects.ContainsKey(key))
            dynamicObjects[key] = go;
        else
            dynamicObjects.Add(key, go);
    }

    public static void RemoveGameObject(string key)
    {
        dynamicObjects.Remove(key);
    }

    public static bool HasObject(string key)
    {
        return dynamicObjects.ContainsKey(key);
    }

    public static GameObject GetObject(string key)
    {
        return dynamicObjects[key];
    }


    // Start is called before the first frame update
    void Start()
    {
        AddGameObject(objectKey, gameObject);
        if (startDisabled)
            gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        RemoveGameObject(objectKey);
    }

    private void OnValidate()
    {
        if(string.IsNullOrWhiteSpace(objectKey)==false)
            name = objectKey;
    }

}
