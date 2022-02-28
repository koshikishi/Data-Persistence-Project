using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public float BallSpeed;
    public float PaddleSpeed;

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

        BallSpeed = 3f;
        PaddleSpeed = 2f;
        LoadSettings();
    }

    [Serializable]
    class SaveData
    {
        public float BallSpeed;
        public float PaddleSpeed;
    }

    public void SaveSettings()
    {
        SaveData data = new SaveData
        {
            BallSpeed = BallSpeed,
            PaddleSpeed = PaddleSpeed
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
    }

    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BallSpeed = data.BallSpeed;
            PaddleSpeed = data.PaddleSpeed;
        }
    }
}
