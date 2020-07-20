using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Manager : MonoBehaviour
{
    public GameObject StoryText;
    public GameObject ButtonsPanel;
    public GameObject SettingsPanel;

    public Slider SteeringSlider;
    public Slider SpeedSlider;
    public Slider BeersSlider;
    public Slider ObstaclesSlider;

    private void Start()
    {
        StoryText.SetActive(true);
        ButtonsPanel.SetActive(true);
        SettingsPanel.SetActive(false);

        SteeringSlider.value = GameManager.Instance.SteeringFactor;
        SpeedSlider.value = GameManager.Instance.SpeedFactor;
        BeersSlider.value = GameManager.Instance.BeerDensityMultiplier;
        ObstaclesSlider.value = GameManager.Instance.ObstacleDensityMultiplier;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            CloseSettingsPanel();
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
    public void SetSteeringFactor() { GameManager.Instance.SteeringFactor = SteeringSlider.value; }
    public void SetSpeedFactor() { GameManager.Instance.SpeedFactor = SpeedSlider.value; }
    public void SetBeerDensityMultiplier() { GameManager.Instance.BeerDensityMultiplier = BeersSlider.value; }
    public void SetObstacleDensityMultiplier() { GameManager.Instance.ObstacleDensityMultiplier = ObstaclesSlider.value; }

    #endregion Atributes

    public void LoadLevel1() { GameManager.Instance.LoadLevel1(); }

    public void RestartGame() { GameManager.Instance.RestartGame(); }

    public void QuitGame() { GameManager.Instance.QuitGame(); }

}
