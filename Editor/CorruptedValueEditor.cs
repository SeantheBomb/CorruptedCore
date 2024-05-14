//using Corrupted;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEditor;
//using UnityEngine;


//[CustomEditor(typeof(CorruptedValue), true)]
//public class CorruptedValueEditor : Editor
//{
//    private SerializedProperty valueProp;
//    private Type[] derivedTypes;

//    private void OnEnable()
//    {
//        valueProp = serializedObject.FindProperty("ObjectValue");
//        derivedTypes = TypeUtility.GetDerivedTypes(valueProp.objectReferenceValue.GetType().GenericTypeArguments[0]);
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        EditorGUILayout.PropertyField(valueProp, true);

//        if (GUILayout.Button("Convert Value"))
//        {
//            CorruptedValue targetObject = (CorruptedValue)target;
//            //ConvertValue(targetObject);
//        }

//        EditorGUILayout.Space();
//        EditorGUILayout.LabelField("Derived Types:", EditorStyles.boldLabel);
//        DrawDerivedTypesDropdown();

//        serializedObject.ApplyModifiedProperties();

//        base.OnInspectorGUI();
//    }

//    private void DrawDerivedTypesDropdown()
//    {
//        int selectedIndex = -1;
//        string[] typeNames = new string[derivedTypes.Length + 1];
//        typeNames[0] = "None";

//        for (int i = 0; i < derivedTypes.Length; i++)
//        {
//            typeNames[i + 1] = derivedTypes[i].Name;

//            if (derivedTypes[i] == valueProp.objectReferenceValue?.GetType())
//            {
//                selectedIndex = i + 1;
//            }
//        }

//        int newSelectedIndex = EditorGUILayout.Popup("Select Type:", selectedIndex, typeNames);

//        if (newSelectedIndex != selectedIndex)
//        {
//            selectedIndex = newSelectedIndex;
//            Type selectedType = selectedIndex == 0 ? null : derivedTypes[selectedIndex - 1];
//            valueProp.objectReferenceValue = (UnityEngine.Object)(selectedType != null ? Activator.CreateInstance(selectedType) : null);
//        }
//    }

//    //private void ConvertValue(CorruptedValue targetObject)
//    //{
//    //     newValue = valueProp.objectReferenceValue;

//    //    if (newValue != null)
//    //    {
//    //        // Call your method to attempt conversion here
//    //        // For example:
//    //        // targetObject.value = ConversionUtility.Convert(targetObject.value, newValue);
//    //        Debug.Log("Value converted successfully.");
//    //    }
//    //    else
//    //    {
//    //        Debug.LogWarning("No new value selected for conversion.");
//    //    }
//    //}
//}

//// Utility class to get derived types of a given type
//public static class TypeUtility
//{
//    public static Type[] GetDerivedTypes(Type baseType)
//    {
//        return AppDomain.CurrentDomain.GetAssemblies()
//            .SelectMany(assembly => assembly.GetTypes())
//            .Where(type => type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
//            .ToArray();
//    }
//}
