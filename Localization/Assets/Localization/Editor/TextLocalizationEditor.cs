using UnityEngine;
using UnityEditor;

public class TextLocalizationEditWindow : EditorWindow
{
    private static TextLocalizationEditWindow _window;
    private int _tabIndex;
    private readonly string[] _tabStrings = {"Translations", "Languages"};
    
    [MenuItem("Window/Localization")]
    public static void Open()
    {
        _window = GetWindow<TextLocalizationEditWindow>("Localization");
        _window.ShowUtility();
    }

    void OnGUI()
    {
        // Set window size (Float mode)
        _window.minSize = new Vector2(500, 300);
        _window.maxSize = new Vector2(1000, 500);
            
        GUILayout.BeginHorizontal();
        _tabIndex = GUILayout.Toolbar(_tabIndex, _tabStrings, GUILayout.Width(250));
        GUILayout.EndHorizontal();
        switch (_tabIndex)
        {
            case 0:
                OnGUITranslations();
                break;
            case 1:
                OnGUILanguages();
                break;
        }
    }

    void OnGUILanguages()
    {
        GUILayout.Label("Show available languages!");
    }
    
    void OnGUITranslations()
    {
        GUILayout.Label("Show available translations!");
        if (GUILayout.Button("Test"))
        {
            LocalizationSystem.Test();
        }
    }
}
