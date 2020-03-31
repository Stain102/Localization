using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CsvManager
{
    private TextAsset _asset;
    private readonly FileManager _fileManager;
    private readonly LanguageManager _languageManager;
    private readonly CsvReader _csvReader;
    private readonly CsvBuilder _csvBuilder;

    private const string CsvName = "localization";
    private const string DefaultLanguageKey = "en";
    private const string DefaultTranslation = "Translate me";
    
    public CsvManager(FileManager fileManager, LanguageManager languageManager)
    {
        _fileManager = fileManager;
        _languageManager = languageManager;
        _csvReader = new CsvReader();
        _csvBuilder = new CsvBuilder();

        if (!fileManager.FileExist(CsvName))
            CreateNewFile();
        
        LoadLocalization();
        
        // Set selected languages
        string[] lines = _csvReader.SplitText(_asset.text);
        string[] headers = _csvReader.SplitHeader(lines[0]);

        for (int i = 1; i < headers.Length; i++)
        {
            string langKey = _csvReader.TrimValue(headers[i]);
            languageManager.SelectLanguage(langKey);
        }
    }

    public void AddLanguage(string langKey)
    {
        _languageManager.SelectLanguage(langKey);
        
        // Update Csv file
        List<string[]> newLines = new List<string[]>();
        string[] lines = _csvReader.SplitText(_asset.text);
        List<string> headers = _csvReader.SplitHeader(lines[0]).ToList();
        headers.Add(langKey);
        TrimValues(headers);
        
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            List<string> fields = _csvReader.SplitLine(line).ToList();
            fields.Add(DefaultTranslation);
            TrimValues(fields);
            newLines.Add(fields.ToArray());
        }
        
        _fileManager.SaveFile(GetFilePath(), _csvBuilder.BuildCsv(headers.ToArray(), newLines));
        LoadLocalization();
    }

    public void RemoveLanguage(string langKey)
    {
        _languageManager.DeSelectLanguage(langKey);
        
        // Update Csv file
        List<string[]> newLines = new List<string[]>();
        string[] lines = _csvReader.SplitText(_asset.text);
        List<string> headers = _csvReader.SplitHeader(lines[0]).ToList();
        TrimValues(headers);

        int langIndex = headers.IndexOf(langKey);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            List<string> fields = _csvReader.SplitLine(line).ToList();
            TrimValues(fields);
            fields.RemoveAt(langIndex);
            newLines.Add(fields.ToArray());
        }
        
        _fileManager.SaveFile(GetFilePath(), _csvBuilder.BuildCsv(headers.ToArray(), newLines));
        LoadLocalization();
    }

    #region Private
    private List<string> TrimValues(List<string> values)
    {
        for (int i = 0; i < values.Count(); i++)
        {
            values[i] = _csvReader.TrimValue(values[i]);
        }
        return values;
    }
    
    private void LoadLocalization()
    {
        _asset = _fileManager.LoadFile(CsvName);
    }

    private void CreateNewFile()
    {
        string[] values = {"key", DefaultLanguageKey};
        _fileManager.SaveFile(GetFilePath(), _csvBuilder.BuildNewCsv(values));
    }

    private string GetFilePath()
    {
        return "Assets/Resources/" + CsvName + ".csv";
    }
    #endregion
}
