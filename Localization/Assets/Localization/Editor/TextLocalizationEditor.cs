using System;
using UnityEngine;
using UnityEditor;

public class TextLocalizationEditWindow : EditorWindow
{
    [MenuItem("Window/Localization")]
    public static void Open()
    {
        LocalizationSystem.Init(); // ToDo: remove later
        GetWindow<TextLocalizationEditWindow>("Localization");
    }

    void OnGUI()
    {
        if (LocalizationSystem.FileExist(LocalizationSystem.CSVName))
        {
            OnGUILocalization();
        }
        else
        {
            OnGUICreation();
        }
    }

    void OnGUICreation()
    {
        // ToDo: show file creation tools
        if (GUILayout.Button("Create file"))
        {
            Debug.Log("Create a new file!");
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
