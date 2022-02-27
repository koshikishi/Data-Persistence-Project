using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class SettingsUIHandler : MonoBehaviour
{
    public Slider ballSpeedSlider;
    public Slider paddleSpeedSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Load settings
        ballSpeedSlider.value = SettingsManager.Instance.BallSpeed;
        paddleSpeedSlider.value = SettingsManager.Instance.PaddleSpeed;
    }

    // Load the main menu scene
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Save settings
    public void SaveSettings()
    {
        SettingsManager.Instance.BallSpeed = ballSpeedSlider.value;
        SettingsManager.Instance.PaddleSpeed = paddleSpeedSlider.value;
        SettingsManager.Instance.SaveSettings();
    }
}
