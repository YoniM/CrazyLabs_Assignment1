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
    public Text InputsText;
    bool DeactivatedInputsText;
    private void Start()
    {
        main_directional_light.intensity = 0.02f;
        RenderSettings.fog = true;

        #if UNITY_EDITOR
                InputsText.text = "Press SPACE to accelerate, and ARROWS to steer";
        #else
                InputsText.text = "Swipe fingers to accelerate and steer";
        #endif
        InputsText.gameObject.SetActive(true);
        DeactivatedInputsText = false;
        ProfileManager.Instance.ChangeProfile(0);
    }

    private void Update()
    {
        if (!DeactivatedInputsText && (Input.anyKey || SwipeInput.Instance.IsDraging))
        {
            InputsText.gameObject.SetActive(false);
            DeactivatedInputsText = true;
        }
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
