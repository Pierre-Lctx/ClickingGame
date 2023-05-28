using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[SerializeField]
public class GameData
{
    public string gameMode;
    public int score;
}

public static class SaveLoadManager
{
    public static void SaveData(GameData data, string fileName)
    {
        string saveFolderPath = Path.Combine(Application.persistentDataPath, "Save");
        string filePath = Path.Combine(saveFolderPath, fileName);

        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(fileStream, data);
        fileStream.Close();

        Debug.Log("Data saved at: " + filePath);
    }

    public static GameData LoadData(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Save", fileName);

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            GameData data = formatter.Deserialize(fileStream) as GameData;
            fileStream.Close();

            Debug.Log("Data loaded from: " + filePath);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found at: " + filePath);
            return null;
        }
    }

    public static List<GameData> LoadAllData()
    {
        List<GameData> allData = new List<GameData>();

        string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.dat");

        foreach (string filePath in filePaths)
        {
            GameData data = LoadData(Path.GetFileName(filePath));
            if (data != null)
            {
                allData.Add(data);
            }
        }

        return allData;
    }
}
