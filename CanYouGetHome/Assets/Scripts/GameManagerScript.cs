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

    #region Panel Interfaces
    public GameObject StoryText;
    public GameObject ButtonsPanel;
    public GameObject SettingsPanel;

    public void Start()
    {
        StoryText.SetActive(true);
        ButtonsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
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
    public Slider SteeringSlider;
    public float SteeringFactor;
    public void SetSteeringFactor()
    {
        SteeringFactor = SteeringSlider.value;
    }
    //public void SetSteeringFactor;
    #endregion Atributes

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
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
