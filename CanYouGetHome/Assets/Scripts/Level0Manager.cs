using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Manager : MonoBehaviour
{
    public Text Maintitle, Subtitle;

    public GameObject GameTitle;
    public GameObject StoryText;
    public GameObject ButtonsPanel;
    public GameObject SettingsPanel;

    bool beforefadeout, afterfadeout;
    public float fadetime = 1f;
    FadeScript fadeawayMaintitle, fadeawaySubtitle;
    float t0;

    public Slider SteeringSlider;
    public Slider SpeedSlider;
    public Slider BeersSlider;
    public Slider ObstaclesSlider;
    public Dropdown InputTypeDropDown;

    private void Start()
    {
        fadeawayMaintitle = Maintitle.GetComponent<FadeScript>();
        fadeawaySubtitle = Subtitle.GetComponent<FadeScript>();

        bool gamestartsnow = GameManager.Instance.gamestartsnow;

        GameTitle.gameObject.SetActive(gamestartsnow);
        Maintitle.gameObject.SetActive(gamestartsnow);
        Subtitle.gameObject.SetActive(gamestartsnow);
        StoryText.SetActive(!gamestartsnow);
        ButtonsPanel.SetActive(!gamestartsnow);
        SettingsPanel.SetActive(false);
        

        beforefadeout = gamestartsnow;
        afterfadeout = !gamestartsnow;
        t0 = Time.time;

        SteeringSlider.value = GameManager.Instance.SteeringFactor;
        SpeedSlider.value = GameManager.Instance.SpeedFactor;
        BeersSlider.value = GameManager.Instance.BeerDensityMultiplier;
        ObstaclesSlider.value = GameManager.Instance.ObstacleDensityMultiplier;
        InputTypeDropDown.value = GameManager.Instance.InputType;
    }

    private void Update()
    {
        if (beforefadeout && (Input.anyKey || Time.time - t0 > fadetime))
        {
            beforefadeout = false;
            fadeawayMaintitle.FadeAwayText();
            fadeawaySubtitle.FadeAwayText();
        }
        if (!afterfadeout && !Maintitle.IsActive())
        {
            afterfadeout = true;
            Maintitle.gameObject.SetActive(false);
            Subtitle.gameObject.SetActive(false);
            
            StoryText.SetActive(true);
            ButtonsPanel.SetActive(true);
        }


        if (Input.GetKey(KeyCode.Escape))
            if (afterfadeout)
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
    public void SetInputType() { GameManager.Instance.InputType = InputTypeDropDown.value;}
    public void SetSteeringFactor() { GameManager.Instance.SteeringFactor = SteeringSlider.value; }
    public void SetSpeedFactor() { GameManager.Instance.SpeedFactor = SpeedSlider.value; }
    public void SetBeerDensityMultiplier() { GameManager.Instance.BeerDensityMultiplier = BeersSlider.value; }
    public void SetObstacleDensityMultiplier() { GameManager.Instance.ObstacleDensityMultiplier = ObstaclesSlider.value; }

    #endregion Atributes

    public void LoadLevel1() { GameManager.Instance.LoadLevel1(); }

    public void RestartGame() { GameManager.Instance.RestartGame(); }

    public void QuitGame() { GameManager.Instance.QuitGame(); }

}
