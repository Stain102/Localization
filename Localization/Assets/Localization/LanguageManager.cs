using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{
    private TextAsset _asset;
    private readonly List<string> _selectedLanguages;
    private CsvReader _csvReader;
    
    public LanguageManager(FileManager fileManager)
    {
        _csvReader = new CsvReader();
        _asset = fileManager.LoadFile("languages");
        _selectedLanguages = new List<string>();
    }

    public void SelectLanguage(string value)
    {
        if (_selectedLanguages.Contains(value))
        {
            Debug.LogWarning("Language key has already been selected!");
            return;
        }
        _selectedLanguages.Add(value);
    }

    public void DeSelectLanguage(string value)
    {
        _selectedLanguages.Remove(value);
    }

    public List<Language> GetAllLanguages()
    {
        List<Language> languageList = new List<Language>();

        string[] lines = _csvReader.SplitText(_asset.text);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = _csvReader.SplitLine(line);

            for (int j = 0; j < fields.Length; j++)
            {
                fields[j] = _csvReader.TrimValue(fields[j]);
            }
            
            Language language = new Language();
            language.Key = fields[0];
            language.Name = fields[1];
            languageList.Add(language);
        }
        return languageList;
    }
    
    public List<Language> GetAvailableLanguages()
    {
        List<Language> languageList = GetAllLanguages();

        for (int i = 0; i < _selectedLanguages.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _selectedLanguages[i]);
            languageList.RemoveAt(index);
        }
        
        return languageList;
    }

    public List<Language> GetSelectedLanguages()
    {
        List<Language> languageList = GetAllLanguages();
        List<Language> languages = new List<Language>();

        for (int i = 0; i < _selectedLanguages.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _selectedLanguages[i]);
            languages.Add(languageList[index]);
        }
        
        return languages;
    }
}
