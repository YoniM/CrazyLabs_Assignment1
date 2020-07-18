using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinAreaScript : MonoBehaviour
{
    public HealthSystem healthsys;
    public Text txt;
    public AlcoholEffect alcoholeffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;
        player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            healthsys.WonGame();
            txt.text = "Drank " + alcoholeffect.BeerCount().ToString() + " Beers";
        }
    }
}
