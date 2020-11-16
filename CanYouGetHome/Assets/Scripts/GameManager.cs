using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton Setup
    public static GameManager Instance { get; private set; }

    public bool gamestartsnow;

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

        gamestartsnow = true;

        InputType = 2; // 0 - mobile swipe ; 1 - mobile buttons; 2 - keyboard
}

    #endregion Singleton Setup

    public float SteeringFactor = 1f;
    public float SpeedFactor = 1f;
    public float BeerDensityMultiplier = 1f;
    public float ObstacleDensityMultiplier = 1f;
    public int InputType; // 0 - mobile swipe ; 1 - mobile buttons; 2 - keyboard
    private void Update()
    {
        if (gamestartsnow)
            gamestartsnow = false;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
        //ProfileManager.Instance.ChangeProfile(0);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}
