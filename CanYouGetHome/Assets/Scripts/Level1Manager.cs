using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level1Manager : MonoBehaviour
{
    public Image CrashScreen;
    public Image WinScreen;
    public Light main_directional_light;

    private void Start()
    {
        main_directional_light.intensity = 0.02f;
        RenderSettings.fog = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            GameOver();
    }

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
        GameManager.Instance.RestartGame();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

}
