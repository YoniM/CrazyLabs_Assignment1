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
    bool PresentedBlurText, PresentedResponseDelayText, PresentedAtaxiaText, PresentedNarrowVisionText;

    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
        beercount = 0;
        UpdateBeerText();
        PresentedBlurText = false;
        PresentedResponseDelayText = false;
        PresentedAtaxiaText = false;
        PresentedNarrowVisionText = false;
    }

    public void BeerUp()
    {
        
        beercount++;
        UpdateBeerText();
        if (beercount >= 1) //3
        {
            maincamera.IncreaseAtaxia();
            if (!PresentedAtaxiaText)
            {
                EffectText.ShowText("Alcohol Onsets Ataxia");
                PresentedAtaxiaText = true;
            }
        }

        if (beercount >= 4)
        {
            maincamera.DecreaseFieldVision();
            if (!PresentedNarrowVisionText)
            {
                EffectText.ShowText("Alcohol narrows your field of vision");
                PresentedNarrowVisionText = true;
            }
        }

        if (beercount >= 2)
        {
            actionTimeDelay += deltaTimeDelay;
            actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
            if (!PresentedResponseDelayText)
            {
                EffectText.ShowText("Alcohol Slows your Response Time");
                PresentedResponseDelayText = true;
            }
        }
        if (beercount >= 5 && !PresentedBlurText)
            AddBlur();
    }

    void AddBlur()
    {
        ProfileManager.Instance.ChangeProfile(1);
        //ProfileManager.Instance.AddBlur();
        //if (ProfileManager.Instance.GetBlur()>20f)
        //{
            EffectText.ShowText("Alcohol Blurs Your Vision");
            PresentedBlurText = true;
        //}
        
    }
    void UpdateBeerText() { beertext.text = beercount.ToString(); }

}
