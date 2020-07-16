using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public Image RedScreen;
    public Image crash1 , crash2 , crash3;
    private int crashes;
    private int maxcrashes = 3;

    public int Crashes { get { return crashes; } }
    public int MaxCrashes { get { return maxcrashes; } }

private void Start()
    {
        RedScreen.gameObject.SetActive(false);
        crashes = 0;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        crash1.enabled = crash2.enabled = crash3.enabled = false;
        if (crashes >= 1)
            crash1.enabled = true;
        if (crashes >= 2)
            crash2.enabled = true;
        if (crashes >= 3)
            crash3.enabled = true;
    }
    public void AddCrash()
    {
        crashes++;
        if (crashes >= maxcrashes)
        {
            GameOver();
        } else
        {
            UpdateVisual();
        }
    }

    public void GameOver()
    {
        RedScreen.gameObject.SetActive(true);
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
