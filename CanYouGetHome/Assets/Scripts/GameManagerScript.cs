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

    public GameObject storytext;
    public Transform ButtonsPanel;
    public void OpenSettingsPanel()
    {
        storytext.SetActive(false);

        foreach (Transform child in ButtonsPanel)
        {
            child.gameObject.SetActive(false);
        }
        ButtonsPanel.gameObject.SetActive(false);
        //SceneManager.LoadScene("SettingsPanel");
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
