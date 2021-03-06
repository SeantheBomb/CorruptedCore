using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public static class CorruptedEditorLayout {



    public static void ListField<T>(EditorWindow window, T t)
    {
        ScriptableObject target = window;
        SerializedObject so = new SerializedObject(target);

        SerializedProperty property = so.FindProperty(GetPropertyName(t));
        EditorGUILayout.PropertyField(property, true);
        so.ApplyModifiedProperties();
    }

    public static void ListField(EditorWindow window, string property)
    {
        ScriptableObject target = window;
        SerializedObject so = new SerializedObject(target);

        SerializedProperty p = so.FindProperty(property);
        EditorGUILayout.PropertyField(p, true);
        so.ApplyModifiedProperties();
    }

    public static string GetPropertyName<T>(T t)
    {
        return GetPropertyName<T>(() => t);
    }

    public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
    {
        var me = propertyLambda.Body as MemberExpression;

        if (me == null)
        {
            throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
        }

        return me.Member.Name;
    }

    public static string GetSaveLocation(UnityEngine.Object o, string message = "Save")
    {
        return RelativePath(EditorUtility.SaveFolderPanel(message, Directory.GetCurrentDirectory(), o.GetType().ToString()));
    }

    public static  string RelativePath(string absolutePath)
    {
        string[] split = absolutePath.Split(new string[] { "Assets/" }, StringSplitOptions.RemoveEmptyEntries);
        string result = "Assets/" + split[split.Length - 1] + "/";
        Debug.Log("RelativePath returned: " + result);
        return result;
    }

    public static Dictionary<string, string[]> ReadCSV(string path)
    {
        Dictionary<string, string[]> result = new Dictionary<string, string[]>();
        StreamReader reader = new StreamReader(path);
        string input = reader.ReadToEnd();
        string[] rows = input.Split('\n');
        string[] headers = rows[0].Split(',');
        foreach (string s in headers)
        {
            result.Add(s, new string[rows.Length - 1]);
        }
        for (int i = 1; i < rows.Length - 1; i++)
        {
            string[] row = rows[i].Split(',');
            for (int j = 0; j < headers.Length; j++)
            {
                result[headers[j]][i] = row[j];
            }
        }
        return result;

    }

}
