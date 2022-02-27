using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string CurrentPlayer;

    [System.Serializable]
    public class ScoreEntry
    {
        public string Name;
        public int Value;
    }

    public ScoreEntry BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        BestScore = new ScoreEntry();
        LoadScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBestScore(int value)
    {
        BestScore.Name = CurrentPlayer;
        BestScore.Value = value;
    }

    public void UpdateBestScoreText(Text text)
    {
        text.text = $"BEST SCORE : {BestScore.Name} : {BestScore.Value}";
    }

    [System.Serializable]
    class SaveData
    {
        public string LastPlayer;
        public ScoreEntry BestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.LastPlayer = CurrentPlayer;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayer = data.LastPlayer;
            BestScore = data.BestScore;
        }
    }
}
