using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{
    private TextAsset _asset;
    private readonly List<string> _languages;
    private CsvReader _csvReader;
    
    public LanguageManager(FileManager fileManager)
    {
        _csvReader = new CsvReader();
        _asset = fileManager.LoadFile("languages");
        _languages = new List<string>();
    }

    #region RunTime
    public List<string> GetAvailableLanguages()
    {
        return _languages;
    }
    #endregion

    #region Editor
    public void AddLanguage(string langKey)
    {
        if (_languages.Contains(langKey))
        {
            Debug.LogWarning("Language key '" + langKey + "' has already been selected!");
            return;
        }
        _languages.Add(langKey);
    }

    public void RemoveLanguage(string langKey)
    {
        _languages.Remove(langKey);
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

        for (int i = 0; i < _languages.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _languages[i]);
            languageList.RemoveAt(index);
        }
        
        return languageList;
    }

    public List<Language> GetAddedLanguages()
    {
        List<Language> languageList = GetAllLanguages();
        List<Language> languages = new List<Language>();

        for (int i = 0; i < _languages.Count; i++)
        {
            int index = languageList.FindIndex(language => language.Key == _languages[i]);
            languages.Add(languageList[index]);
        }
        
        return languages;
    }
    #endregion
}
