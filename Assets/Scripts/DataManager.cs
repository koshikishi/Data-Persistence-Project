using System.Collections;
using System.Collections.Generic;
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
}
