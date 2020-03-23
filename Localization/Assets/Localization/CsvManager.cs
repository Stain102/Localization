using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CsvManager
{
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = { "\",\"" };
    private FileManager _fileManager;

    public CsvManager(FileManager fileManager)
    {
        _fileManager = fileManager;
    }
    
    public string CreateNewFile()
    {
        csvFile = new TextAsset("");
        return csvFile.text;
    }

    public void LoadCsvFile(TextAsset asset)
    {
        csvFile = asset;
    }
}
