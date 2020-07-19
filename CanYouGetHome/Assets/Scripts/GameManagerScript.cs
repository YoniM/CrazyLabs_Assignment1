using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript Instance { get; private set; }

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
    }

    
    public GameObject StoryText;
    public GameObject ButtonsPanel;
    public GameObject SettingsPanel;

    public Slider SteeringSlider;
    public float SteeringFactor = 1f;

    public Slider SpeedSlider;
    public float SpeedFactor = 1f;

    private void Start()
    {
        StoryText.SetActive(true);
        ButtonsPanel.SetActive(true);
        SettingsPanel.SetActive(false);

        SteeringSlider.value = SteeringFactor;
        SpeedSlider.value = SpeedFactor;
    }

    #region Panel Interfaces
    public void OpenSettingsPanel()
    {
        StoryText.SetActive(false);
        ButtonsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        StoryText.SetActive(true);
        ButtonsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    #endregion Panel Interfaces


    #region Atributes
    public void SetSteeringFactor() { SteeringFactor = SteeringSlider.value; }
    public void SetSpeedFactor() { SpeedFactor = SpeedSlider.value; }

    #endregion Atributes

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
        Start();
    }

    public void QuitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
