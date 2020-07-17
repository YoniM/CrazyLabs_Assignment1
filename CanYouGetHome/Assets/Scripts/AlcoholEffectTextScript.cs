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
    public void UpdateText(string str)
    {
        txt.text = str;
        Invoke("SetNotActive", time_present);
    }

    void SetNotActive()
    {
        gameObject.SetActive(false);
    }
}
