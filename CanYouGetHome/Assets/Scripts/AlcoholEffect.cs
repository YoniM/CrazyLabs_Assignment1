using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlcoholEffect : MonoBehaviour
{

    public MainCameraScript maincamera;

    private float actionTimeDelay;
    public float MaxActionTimeDelay = 0.45f;
    public float deltaTimeDelay = 0.15f;

    private int beercount;
    public Text beertext;

    public float ActionTimeDelay { get { return actionTimeDelay; } }
    public float BeerCount { get { return beercount; } }

    public AlcoholEffectTextScript EffectText;
    bool PresentedBlurText, PresentedResponseDelayText, PresentedAtaxiaText;

    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
        beercount = 0;
        UpdateBeerText();
        PresentedBlurText = false;
        PresentedResponseDelayText = false;
    }

    public void BeerUp()
    {
        
        beercount++;
        UpdateBeerText();
        actionTimeDelay += deltaTimeDelay;
        actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
        if (beercount >= 3 && !PresentedAtaxiaText)
        {
            maincamera.IncreaseAtaxia();
            EffectText.ShowText("Alcohol Onsets Ataxia");
            PresentedAtaxiaText = true;
        }

        if (beercount >= 2 && !PresentedResponseDelayText)
        {
            EffectText.ShowText("Alcohol Slows your Response Time");
            PresentedResponseDelayText = true;
        }
        if (beercount >= 4 && !PresentedBlurText)
            AddBlur();



    }

    void AddBlur()
    {
        ProfileManager.Instance.ChangeProfile(1);
        EffectText.ShowText("Alcohol Blurs Your Vision");
        PresentedBlurText = true;
    }
    void UpdateBeerText() { beertext.text = beercount.ToString(); }

}
