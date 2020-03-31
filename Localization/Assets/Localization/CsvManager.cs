using UnityEngine;

public class CsvManager
{
    private TextAsset _asset;
    private readonly FileManager _fileManager;
    private readonly CsvReader _csvReader;
    private readonly CsvBuilder _csvBuilder;

    private const string CsvName = "localization";
    private const string DefaultLanguageKey = "en";
    
    public CsvManager(FileManager fileManager, LanguageManager languageManager)
    {
        _fileManager = fileManager;
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
}
