using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem
{
    private static bool _isInit = false;
    private static FileManager _fileManager;

    public const string CSVName = "localization";

    public static void Init()
    {
        if (_isInit) return; // ToDo: remove later
        
        _fileManager = new FileManager();

        _isInit = true;
    }

    public static bool FileExist(string path)
    {
        if (!_isInit) { Init(); }
        return _fileManager.FileExist(path);
    }
}
