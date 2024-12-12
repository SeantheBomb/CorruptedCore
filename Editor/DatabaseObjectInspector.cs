using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Corrupted;

[CustomEditor(typeof(DatabaseObject))]
public class DatabaseObjectInspector : Editor
{
    private DatabaseObject databaseObject;
    private string selectedPageId;
    private Type selectedType;

    // Cache for available types with the DatabasePageTypeAttribute
    private List<Type> availableTypes;

    private void OnEnable()
    {
        databaseObject = (DatabaseObject)target;

        // Find all types marked with DatabasePageTypeAttribute
        availableTypes = GetAvailableDatabasePageTypes();
    }

    public override void OnInspectorGUI()
    {
        // Begin a horizontal layout to have buttons on the left and the selected page inspector on the right
        GUILayout.BeginHorizontal();

        // Left Column: List of buttons for each page
        GUILayout.BeginVertical(GUILayout.Width(200));
        DrawDatabasePageButtons();
        DrawAddNewPageButton();
        GUILayout.EndVertical();

        // Right Column: Draw the inspector for the selected page
        GUILayout.BeginVertical();
        DrawSelectedPageInspector();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void DrawDatabasePageButtons()
    {
        // Get all keys in the database's pages
        DatabasePage[] pages = databaseObject.storedDatabase.GetPages();

        // Draw a button for each key in the database
        foreach (var pageKey in pages)
        {
            //if(pageKey == null) continue;
            if (GUILayout.Button(pageKey.ID))
            {
                selectedPageId = pageKey.ID;
                Debug.Log($"Database: Select key {selectedPageId}");
            }
        }
    }

    private void DrawAddNewPageButton()
    {
        if (GUILayout.Button("Add New Page"))
        {
            ShowAddNewPageDialog();
        }
    }

    private void ShowAddNewPageDialog()
    {
        // Show a dropdown to select the page type (i.e., select from available types)
        GenericMenu menu = new GenericMenu();

        foreach (var type in availableTypes)
        {
            menu.AddItem(new GUIContent(type.Name), false, () => AddNewPage(type));
        }

        // Show the menu at the mouse position
        menu.ShowAsContext();
    }

    private void AddNewPage(Type selectedType)
    {
        if (selectedType == null)
        {
            Debug.LogError("No type selected.");
            return;
        }

        // Create a default value for the selected type
        var defaultValue = Activator.CreateInstance(selectedType);

        // Generate a unique ID for the new page (can be based on current time, GUID, etc.)
        string newPageId = Guid.NewGuid().ToString();

        // Add the new page to the database
        databaseObject.storedDatabase.AddPage(newPageId, defaultValue);

        // Select the newly added page
        selectedPageId = newPageId;
    }

    private void DrawSelectedPageInspector()
    {
        // Only draw the inspector for the selected page if it's valid
        if (string.IsNullOrEmpty(selectedPageId))
        {
            GUILayout.Label("Select a page to view its details.");
            return;
        }

        // Get the selected page from the database
        var page = databaseObject.storedDatabase.GetPage(selectedPageId);
        if (page != null)
        {
            // Use the Unity property drawer to show the inspector for the page's value
            EditorGUILayout.LabelField($"Selected Page: {page.Title}", EditorStyles.boldLabel);

            // Draw the editor for the selected page's value
            DrawPageValueInspector(page);
        }
        else
        {
            GUILayout.Label("Page not found.");
        }
    }

    private void DrawPageValueInspector(DatabasePage page)
    {
        //// Create a SerializedObject for the page's value
        //SerializedObject serializedPage = new SerializedObject(page);

        //// Iterate over all the fields of the serialized object and draw them
        //SerializedProperty property = serializedPage.GetIterator();

        //// Move to the first property
        //if (property.NextVisible(true))
        //{
        //    do
        //    {
        //        EditorGUILayout.PropertyField(property, true);
        //    } while (property.NextVisible(false));
        //}

        //// Apply any changes made in the inspector
        ////serializedPage.ApplyModifiedProperties();
    }


    private List<Type> GetAvailableDatabasePageTypes()
    {
        // Get all assemblies currently loaded in the application domain
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Find all types with the DatabasePageTypeAttribute across all assemblies
        var typesWithAttribute = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.GetCustomAttribute<DatabasePageTypeAttribute>() != null && t.IsSerializable)
            .ToList();

        return typesWithAttribute;
    }
}
