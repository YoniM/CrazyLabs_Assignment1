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

    public void Start()
    {
        SettingsPanel.SetActive(false);
    }
    public void OpenSettingsPanel()
    {
        StoryText.SetActive(false);
        ButtonsPanel.SetActive(false);
        SettingsPanel.SetActive(true);


    }

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
