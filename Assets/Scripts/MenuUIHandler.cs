using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance.BestScore.Name != null)
        {
            DataManager.Instance.UpdateBestScoreText(bestScoreText);
            bestScoreText.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load the main scene
    public void StartNew()
    {
        DataManager.Instance.CurrentPlayer = inputField.text == "" ? "Noname" : inputField.text;

        SceneManager.LoadScene(1);
    }

    // Exit the application
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
