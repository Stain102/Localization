using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class LanguageTest : MonoBehaviour
{
    private FileManager _fileManager;
    private TextAsset _asset;
    private Dictionary<string, string> _dictionary;
    
    private char lineSeperator = '\n';
    private char surround = '"';
    private Regex _csvParser;
    
    void Start()
    {
        _fileManager = new FileManager();
        _asset = _fileManager.LoadFile("languages");
        _csvParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        
        DetectDuplicates();
    }

    void DetectDuplicates()
    {
        _dictionary = new Dictionary<string, string>();

        string[] lines = _asset.text.Split(lineSeperator);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = _csvParser.Split(line);

            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimEnd(surround);
            }

            var key = fields[0];

            if (_dictionary.ContainsKey(key))
            {
                Debug.Log("Duplicate keys!!\n" +
                          "Key: " + key + ", value1: " + _dictionary[key] + "\n" +
                          "Key: " + key + ", value2: " + fields[1]);
            }
            else
            {
                var value = fields[1];
                _dictionary.Add(key, value);
            }
        }
        Debug.Log("Test ended!");
    }
}
