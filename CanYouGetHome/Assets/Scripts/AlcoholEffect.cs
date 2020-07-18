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
    public int beers_per_effect = 1;
    int alcoholeffectcount;
    public int WhenMotionDelay = 1, WhenAtaxia = 2, WhenBlur = 3, WhenNarrowingVision = 4;

    public float ActionTimeDelay { get { return actionTimeDelay; } }
    public int BeerCount() {  return beercount;  }

    public AlcoholEffectTextScript EffectText;
    
    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
        beercount = 0;
        UpdateBeerText();
        alcoholeffectcount = 0;
    }

    public void BeerUp()
    {
        
        beercount++;
        UpdateBeerText();

        // Onset of effects:
        if (beercount % beers_per_effect == 0) 
        {
            alcoholeffectcount++;

            if (alcoholeffectcount == WhenMotionDelay) // motion delay
                EffectText.ShowText("Alcohol Slows your Response Time");
            if (alcoholeffectcount == WhenAtaxia) // Ataxia
                EffectText.ShowText("Alcohol Onsets Ataxia");
            if (alcoholeffectcount == WhenBlur)
            {
                ProfileManager.Instance.ChangeProfile(1);
                EffectText.ShowText("Alcohol Blurs your vision");
            }
            if (alcoholeffectcount == WhenNarrowingVision)
            {
                ProfileManager.Instance.ChangeProfile(2);
                EffectText.ShowText("Alcohol narrows your field of vision");
            }

        }

        #region Incremental increase of effects 
        if (alcoholeffectcount >= WhenMotionDelay) // increase motion delay each beer after onset of effect
        {
            actionTimeDelay += deltaTimeDelay;
            actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
        }
        if (alcoholeffectcount >= WhenAtaxia) // increase ataxia each beer after onset of effect
        {
            maincamera.IncreaseAtaxia();
        }
        #endregion Incremental increase of effects

        
    }

        
    
    void UpdateBeerText() { beertext.text = beercount.ToString(); }

}
