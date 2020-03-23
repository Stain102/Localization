using System.IO;
using UnityEditor;
using UnityEngine;

public class FileManager
{
    public FileManager()
    {
        if (!Directory.Exists("Assets/Resources"))
        {
            Directory.CreateDirectory("Assets/Resources");
            AssetDatabase.Refresh();
        }   
    }
    
    /// <summary>
    /// Determines if a file exists.
    /// </summary>
    /// <param name="path">Name of the file in question</param>
    /// <returns>True, if it exists</returns>
    public bool FileExist(string path)
    {
        TextAsset asset = Resources.Load<TextAsset>(path);
        return asset != null;
    }
    
    /// <summary>
    /// Loads a specified file.
    /// </summary>
    /// <param name="path">Name of the file in question</param>
    /// <returns>Returns the file as a TextAsset</returns>
    public TextAsset LoadFile(string path)
    {
        return Resources.Load<TextAsset>(path);
    }

    /// <summary>
    /// Saves text to file.
    /// </summary>
    /// <param name="path">The absolute path</param>
    /// <param name="value">The text written to file</param>
    public void SaveFile(string path, string value)
    {
        File.WriteAllText(path, value);
        AssetDatabase.Refresh();
    }
    
    // ToDo: Add append function??
}
