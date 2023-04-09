using System;
using System.IO;
using System.Text;
using UnityEngine;

public class DataSaver
{
    // Save Data
    public static void SaveData<T>(T dataToSave, string dataFileName)
    {
        var tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        // Convert To Json then to bytes
        var jsonData = JsonUtility.ToJson(dataToSave, true);
        var jsonByte = Encoding.ASCII.GetBytes(jsonData);

        // Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? throw new InvalidOperationException());
        }

        try
        {
            File.WriteAllBytes(tempPath, jsonByte);
            Debug.Log("Saved Data to: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }

    // Load Data
    public static T LoadData<T>(string dataFileName) where T: new()
    {
        var tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        // Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return new T();
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return new T();
        }

        // Load saved Json
        byte[] jsonByte = null;
        try
        {
            jsonByte = File.ReadAllBytes(tempPath);
            Debug.Log("Loaded Data from: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Load Data from: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }

        // Convert to json string
        var jsonData = Encoding.ASCII.GetString(jsonByte ?? throw new InvalidOperationException());

        // Convert to Object
        object resultValue = JsonUtility.FromJson<T>(jsonData);
        
        return (T)Convert.ChangeType(resultValue, typeof(T));
    }

    public static bool DeleteData(string dataFileName)
    {
        var success = false;

        // Load Data
        var tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        // Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return false;
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return false;
        }

        try
        {
            File.Delete(tempPath);
            Debug.Log("Data deleted from: " + tempPath.Replace("/", "\\"));
            success = true;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Delete Data: " + e.Message);
        }

        return success;
    }
}