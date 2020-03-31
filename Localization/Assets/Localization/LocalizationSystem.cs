using UnityEngine;

public class LocalizationSystem
{
    private static bool _isInit;
    private static FileManager _fileManager;
    private static LanguageManager _languageManager;
    private static CsvManager _csvManager;

    public static void Init()
    {
        _fileManager = new FileManager();
        _languageManager = new LanguageManager(_fileManager);
        _csvManager = new CsvManager(_fileManager, _languageManager);
        
        _isInit = true;
    }

    public static void Test()
    {
        if (!_isInit) { Init(); }
        Debug.Log("TestCompleted!");
    }
}
