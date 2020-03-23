using System;
using UnityEngine;
using UnityEditor;

public class TextLocalizationEditWindow : EditorWindow
{
    private static TextLocalizationEditWindow _window;
    
    [MenuItem("Window/Localization")]
    public static void Open()
    {
        _window = GetWindow<TextLocalizationEditWindow>("Localization");
        _window.ShowUtility();
    }

    void OnGUI()
    {
        if (LocalizationSystem.FileExist(LocalizationSystem.CsvName))
        {
            // Set window size (Float mode)
            _window.minSize = new Vector2(500, 300);
            _window.maxSize = new Vector2(1000, 500);
            
            OnGUILocalization();
        }
        else
        {
            // Set window size (Float mode)
            _window.minSize = new Vector2(250, 58);
            _window.maxSize = minSize;
            
            OnGUICreation();
        }
    }

    void OnGUICreation()
    {
        EditorGUILayout.HelpBox("No file was found. Create a new file to begin!", MessageType.Info);
        if (GUILayout.Button("Create new file"))
        {
            LocalizationSystem.CreateNewCsvFile();
        }
    }

    void OnGUILocalization()
    {
        // ToDo: show tool for editing current localization file.
        if (GUILayout.Button("Edit file"))
        {
            Debug.Log("Let's start editing!");
        }
    }
}
