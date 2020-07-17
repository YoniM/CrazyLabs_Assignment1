using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipBodyScript : MonoBehaviour
{
    public AlcoholEffect alcoholeff;

    private void OnTriggerEnter(Collider other)
    {
        BeerIconScript beer;
        beer = other.gameObject.GetComponent<BeerIconScript>();
        
        if (beer != null)
        {
            alcoholeff.BeerUp();
            other.gameObject.SetActive(false);
        }
    }
}
