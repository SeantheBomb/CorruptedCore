using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class CloneListEditor : EditorWindow
{
    [TextArea]
    public string input;
    UnityEngine.Object prefab;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Tools/Clone List")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        CloneListEditor window = (CloneListEditor)EditorWindow.GetWindow(typeof(CloneListEditor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        input = GUILayout.TextArea(input);
        prefab = EditorGUILayout.ObjectField(prefab, typeof(UnityEngine.Object), false);
        if (GUILayout.Button("Go"))
        {
            Run(GetSaveLocation(prefab));
        }
    }

    public string GetSaveLocation(UnityEngine.Object o)
    {
        return RelativePath(EditorUtility.SaveFolderPanel($"Save Clone {o.GetType()}", Directory.GetCurrentDirectory(), o.GetType().ToString()));
    }

    public void Run(string saveFolder)
    {
        string[] data = input.Split(' ', ',', '\n', '\t');
        foreach(string s in data)
        {
            if (string.IsNullOrWhiteSpace(s))
                continue;
            UnityEngine.Object o = Instantiate(prefab);
            o.name = s;
            AssetDatabase.CreateAsset(o, saveFolder + o.name + ".asset");
        }
    }

    public void ListField<T>(T t)
    {
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);

        SerializedProperty property = so.FindProperty(GetPropertyName(t));
        EditorGUILayout.PropertyField(property, true);
        so.ApplyModifiedProperties();
    }

    public void ListField(string property)
    {
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);

        SerializedProperty p = so.FindProperty(property);
        EditorGUILayout.PropertyField(p, true);
        so.ApplyModifiedProperties();
    }

    public string GetPropertyName<T>(T t)
    {
        return GetPropertyName<T>(() => t);
    }

    public string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
    {
        var me = propertyLambda.Body as MemberExpression;

        if (me == null)
        {
            throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
        }

        return me.Member.Name;
    }

    private string RelativePath(string absolutePath)
    {
        string[] split = absolutePath.Split(new string[] { "Assets/" }, StringSplitOptions.RemoveEmptyEntries);
        string result = "Assets/" + split[split.Length - 1] + "/";
        Debug.Log("RelativePath returned: " + result);
        return result;
    }
}
