using System;
using UnityEngine;
using UnityEditor;

public class TextLocalizationEditWindow : EditorWindow
{
    [MenuItem("Window/Localization")]
    public static void Open()
    {
        GetWindow<TextLocalizationEditWindow>("Localization");
    }

    void OnGUI()
    {
        if (LocalizationSystem.FileExist(LocalizationSystem.CsvName))
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
        // ToDo: Show info box - no existing file (create (or load XML - FUTURE))
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
