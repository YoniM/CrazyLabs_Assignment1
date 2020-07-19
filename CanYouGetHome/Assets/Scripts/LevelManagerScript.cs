using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManagerScript : MonoBehaviour
{
    public Image CrashScreen;
    public Image WinScreen;

    public void GameOver()
    {
        CrashScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void WonGame()
    {
        WinScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
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
