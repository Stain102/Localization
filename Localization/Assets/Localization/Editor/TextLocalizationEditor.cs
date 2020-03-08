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
        if (GUILayout.Button("Hello"))
        {
            Debug.Log("Hello");
        }
    }
}
