using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavingName : MonoBehaviour
{
    public static SavingName Instance;

    public string name;
    public int bestScore;
    public string bestPlayerName;

    [System.Serializable]
    class SaveData
    {
        public int bestScoreSave;
        public string bestPlayerNameSave;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
        // SAFE and LOAD
        public void SaveBestPlayer()
        {
            SaveData data = new SaveData();
            data.bestScoreSave = bestScore;
            data.bestPlayerNameSave = bestPlayerName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        public void LoadBestPlayer()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                bestScore = data.bestScoreSave;
                bestPlayerName = data.bestPlayerNameSave;
            }
        }


    



}
