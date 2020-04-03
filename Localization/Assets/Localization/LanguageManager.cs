using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{
    private TextAsset _asset;
    private readonly List<string> _langKeys;
    private CsvReader _csvReader;
    
    public LanguageManager(FileManager fileManager)
    {
        _csvReader = new CsvReader();
        _asset = fileManager.LoadFile("languages");
        _langKeys = new List<string>();
    }

    public void AddLanguage(string langKey)
    {
        if (_langKeys.Contains(langKey))
        {
            Debug.LogWarning("Language key '" + langKey + "' has already been selected!");
            return;
        }
        _langKeys.Add(langKey);
    }

    public void RemoveLanguage(string langKey)
    {
        _langKeys.Remove(langKey);
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
    
    public List<Language> GetSearchableLanguages()
    {
        List<Language> languageList = GetAllLanguages();

        for (int i = 0; i < _langKeys.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _langKeys[i]);
            languageList.RemoveAt(index);
        }
        
        return languageList;
    }

    public List<Language> GetAddedLanguages()
    {
        List<Language> languageList = GetAllLanguages();
        List<Language> languages = new List<Language>();

        for (int i = 0; i < _langKeys.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _langKeys[i]);
            languages.Add(languageList[index]);
        }
        
        return languages;
    }
}
