using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlcoholEffect : MonoBehaviour
{
    
    private float actionTimeDelay;
    public float MaxActionTimeDelay = 0.45f;
    public float deltaTimeDelay = 0.15f;

    private int beercount;
    public Text beertext;

    public float ActionTimeDelay { get { return actionTimeDelay; } }
    public float BeerCount { get { return beercount; } }

    public AlcoholEffectTextScript EffectText;

    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
        beercount = 0;
        UpdateBeerText();
    }

    public void BeerUp()
    {
        beercount++;
        UpdateBeerText();
        actionTimeDelay += deltaTimeDelay;
        actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
        if (beercount>=3)
        {
            ProfileManager.Instance.ChangeProfile(1);
            EffectText.UpdateText("Alcohol Blurs Your Vision");
        }
    }

    void UpdateBeerText() { beertext.text = beercount.ToString(); }

}
