using System;
using System.Collections;
using System.Collections.Generic;
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

}
