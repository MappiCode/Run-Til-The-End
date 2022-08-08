using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/score.data";
    public static void SaveScore(float score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ScoreData LoadScore()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(fileStream) as ScoreData;
            fileStream.Close();
            
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found in" + path);
            return new ScoreData(0);
        }
    }
}
