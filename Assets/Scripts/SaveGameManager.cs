using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGameManager : MonoBehaviour
{

    public static SaveGameManager Instance;
    public string savePlayerName;
    public string dontShowPlayerName;
    public int savePlayerScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadDataOnClick();
    }

    [System.Serializable]

    class SaveData
    {
        public string savePlayerName;
        public int savePlayerScore;
    }

    public void SaveDataOnClick()
    {
        SaveData data = new SaveData();
        data.savePlayerName = savePlayerName;
        data.savePlayerScore = savePlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
     
    public void LoadDataOnClick()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savePlayerName = data.savePlayerName;
            savePlayerScore = data.savePlayerScore;

        }
    }

}
