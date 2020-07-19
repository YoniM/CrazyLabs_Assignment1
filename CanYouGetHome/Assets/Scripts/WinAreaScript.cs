using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinAreaScript : MonoBehaviour
{
    public LevelManagerScript levelmanager;
    public Text txttime, txtbeer;
    public AlcoholEffect alcoholeffect;
    public ClockScript clock;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player;
        player = other.gameObject.GetComponent<PlayerController>();
        int timeleft = Mathf.FloorToInt(clock.getRemainingTime());
        if (player != null)
        {
            levelmanager.WonGame();
            if (timeleft > 0)
            {
                txttime.text = "... Had just " + timeleft.ToString() + " seconds to spare!";
            } else if (timeleft == 0) {
                txttime.text = "... Just on time!";
            } else if (timeleft < 0) {
                txttime.text = "... But you were late " + (-timeleft).ToString() + " seconds. Boss is angry!";
            }

            txtbeer.text = "Drank " + alcoholeffect.BeerCount().ToString() + " Beers on the way!";
            

        }
    }
}
