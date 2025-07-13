using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static DataManager Instance;
    public int BestScore;
    public string PlayerName;
    public string TopPlayer;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [System.Serializable]
    class SaveData
    {
        public string TopPlayer;
        public int BestScore;
    }


    // These codes are used to to save BestScore between sessions
    //public void SaveBestScore()
    //{
    //    SaveData data = new SaveData();
    //    data.BestScore = BestScore;
    //    string json = JsonUtility.ToJson(data);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadBestScore()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);
    //        BestScore = data.BestScore;
    //    }
    //}

    // These codes are used to save TopPlayer betweem sessions
    //public void SaveTopPlayer()
    //{
    //    SaveData data = new SaveData();
    //    TopPlayer = PlayerName;
    //    data.TopPlayer = TopPlayer;
    //    string json = JsonUtility.ToJson(data);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadTopPlayer()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);
    //        TopPlayer = data.TopPlayer;
    //    }
    //}


    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        TopPlayer = PlayerName;
        data.TopPlayer = TopPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);



    }
    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScore = data.BestScore;
            TopPlayer = data.TopPlayer;
        }
    }
}
