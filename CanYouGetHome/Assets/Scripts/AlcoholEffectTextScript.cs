using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlcoholEffectTextScript : MonoBehaviour
{
    Text txt;
    public float time_present = 2f; // [sec]
    private void Start()
    {
        txt = GetComponent<Text>();
        gameObject.SetActive(false);
        
    }
    public void ShowText(string str)
    {
        if (txt!=null)
        {
            txt.text = str;
            gameObject.SetActive(true);
            Invoke("DontShowText", time_present);
        }
    }

    void DontShowText()
    {
        gameObject.SetActive(false);
    }
}
