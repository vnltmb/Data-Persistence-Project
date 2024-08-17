using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataMan : MonoBehaviour
{
    public static DataMan Instance;

    public string playerName = "";
    public string hiScoreName = "";
    public int hiScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {   
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string hiScoreName;
        public int hiScore;
    }

    public void SaveScore()
    {
        // create new SaveData object
        SaveData data = new SaveData();

        data.hiScore = hiScore;
        data.hiScoreName = hiScoreName;

        // convert to json format
        string json = JsonUtility.ToJson(data);
        // write to file
        File.WriteAllText(Application.persistentDataPath + "/hiscore.json", json);
        Debug.Log("score saved to file");
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/hiscore.json";

        if (File.Exists(path))
        {
            // read data from the file
            string json = File.ReadAllText(path);
            // convert to object
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.hiScore;
            hiScoreName = data.hiScoreName;
        }
    }
}
