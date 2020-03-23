using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvManager
{
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = { "\",\"" };
    
    public CsvManager()
    {
        
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
