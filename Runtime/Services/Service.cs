using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public abstract class Service<T> : IService where T : Service<T>, new()
{

    private static T instance;
    private static bool IsInitialized = false;

    //private static SynchronizationList synchronizations;


    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Debug.Log("Sevice Initialize");
        if (IsInitialized)
            return;
        instance = new T();
        //synchronizations = new SynchronizationList();
        instance.OnInitialize();
        //if(sync != null)
        //    synchronizations.AddRange(sync);
        instance.StartService();
        IsInitialized = true;
    }

    public static T GetService()
    {
        return instance;
    }

    ~Service()
    {
        StopService();
        //synchronizations = null;
        IsInitialized = false;
    }



    public virtual void OnInitialize() { }


    public virtual void StartService() { }

    public virtual void StopService() { }


}


public static class ServiceRunner
{


    [RuntimeInitializeOnLoadMethod]
    public static void RunServices()
    {

        Debug.Log("Run all services");
        // Get all types in the current assembly.
        //var types = Assembly.GetExecutingAssembly().GetTypes();
        Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany((ass) => ass.GetTypes()).ToArray();

        

        // Find all types that inherit from Service<T>.
        var serviceTypes = types
            .Where(type => type.BaseType != null && type.GetInterfaces().Contains(typeof(IService)))
            .ToList();

        Debug.Log($"{serviceTypes.Count} services out of {types.Length} types found");

        // Iterate through each service type and call Initialize method.
        foreach (var serviceType in serviceTypes)
        {
            Type baseType = serviceType.BaseType;
            if (baseType != null)
            {
                MethodInfo initializeMethod = baseType.GetMethod("Initialize", BindingFlags.Static | BindingFlags.NonPublic);
                if (initializeMethod != null)
                {
                    initializeMethod.Invoke(null, null);
                }
            }
        }
    }

}