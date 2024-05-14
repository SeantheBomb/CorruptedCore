using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ServiceModel : ScriptableObject, IService
{
   

    private static void Initialize()
    {
        // Find all loaded objects of type ScriptableObject
        ScriptableObject[] allScriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

        foreach (var scriptableObject in allScriptableObjects)
        {
            // Check if the ScriptableObject implements the IService interface
            if (scriptableObject is IService s)
            {
                s.OnInitialize();
                s.StartService();
            }
        }
        Application.quitting += OnApplicationQuit;
    }

    private static void OnApplicationQuit()
    {
        // Find all loaded objects of type ScriptableObject
        ScriptableObject[] allScriptableObjects = Resources.FindObjectsOfTypeAll<ScriptableObject>();

        foreach (var scriptableObject in allScriptableObjects)
        {
            // Check if the ScriptableObject implements the IService interface
            if (scriptableObject is IService s)
            {
                s.StopService();
            }
        }
    }

    public virtual void OnInitialize()
    {

    }

    public virtual void StartService()
    {
    }

    public virtual void StopService()
    {

    }
}
