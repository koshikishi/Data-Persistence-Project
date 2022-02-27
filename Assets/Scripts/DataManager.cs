using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    [System.Serializable]
    public class ScoreEntry
    {
        public string Name;
        public int Value;
    }

    public string CurrentPlayer;
    public List<ScoreEntry> ScoreList;

    const int ScoreListMaxCount = 5;

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

        ScoreList = new List<ScoreEntry>();
        LoadScore();
    }

    public void UpdateScoreList(int value)
    {
        if (ScoreList.Exists(i => i.Name == CurrentPlayer))
        {
            int index = ScoreList.FindIndex(i => i.Name == CurrentPlayer);

            if (ScoreList[index].Value < value)
            {
                ScoreList[index].Value = value;
                ScoreListSort();
            }

            return;
        }

        ScoreEntry scoreEntry = new ScoreEntry
        {
            Name = CurrentPlayer,
            Value = value
        };

        if (ScoreList.Count < ScoreListMaxCount)
        {
            ScoreList.Add(scoreEntry);
            ScoreListSort();
        }
        else if (ScoreList[ScoreList.Count - 1].Value < value)
        {
            ScoreList[ScoreList.Count - 1] = scoreEntry;
            ScoreListSort();
        }
    }

    public void UpdateBestScore(Text text)
    {
        text.text = $"BEST SCORE : {ScoreList[0].Name} : {ScoreList[0].Value}";
    }

    [System.Serializable]
    class SaveData
    {
        public string LastPlayer;
        public List<ScoreEntry> ScoreList;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData
        {
            LastPlayer = CurrentPlayer,
            ScoreList = ScoreList
        };

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
            ScoreList = data.ScoreList;
        }
    }

    void ScoreListSort()
    {
        ScoreList.Sort(delegate (ScoreEntry x, ScoreEntry y)
        {
            return y.Value.CompareTo(x.Value);
        });
    }
}
