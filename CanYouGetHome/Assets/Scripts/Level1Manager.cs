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
    public GameObject buttonLeft;
    public GameObject buttonRight;

    bool DeactivatedInputsText;

    public float moveRight;
    public float rateMoveChange = 30f; // % per Time.DeltaTime;

    public void MoveRight() { moveRight += rateMoveChange * Time.deltaTime; }
    public void MoveLeft() { moveRight -= rateMoveChange * Time.deltaTime; }
    public void MoveRelease() { moveRight = 0f; }

    private void Start()
    {
        main_directional_light.intensity = 0.02f;
        RenderSettings.fog = true;

//        #if UNITY_EDITOR
//                InputsText.text = "Press SPACE to accelerate, and ARROWS to steer";
//        #else
        if (GameManager.Instance.InputType == 0)
            InputsText.text = "Swipe fingers to accelerate and steer";
        else if (GameManager.Instance.InputType == 1)
            InputsText.text = "Use arrows to steer";
        else if (GameManager.Instance.InputType == 2)
            InputsText.text = "Press SPACE to accelerate, and ARROWS to steer";
//        #endif

            if (GameManager.Instance.InputType != 1)
        {
            buttonLeft.SetActive(false);
            buttonRight.SetActive(false);
        }
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
