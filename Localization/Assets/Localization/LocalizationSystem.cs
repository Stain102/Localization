using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    private static bool _isInit = false;
    private static FileManager _fileManager;
    private static CsvManager _csvManager;
    
    public const string CsvName = "localization";

    public static void Init()
    {
        _fileManager = new FileManager();
        _csvManager = new CsvManager();

        _isInit = true;
    }

    public static bool FileExist(string path)
    {
        if (!_isInit) { Init(); }
        return _fileManager.FileExist(path);
    }

    public static void CreateNewCsvFile()
    {
        if (!_isInit) { Init(); }
        _fileManager.SaveFile(GetCsvPath(), _csvManager.CreateNewFile());
    }

    private static string GetCsvPath()
    {
        return "Assets/Resources/" + CsvName + ".csv";
    }
}
