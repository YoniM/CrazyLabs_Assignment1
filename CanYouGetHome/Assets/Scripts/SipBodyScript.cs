using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipBodyScript : MonoBehaviour
{
    public AlcoholEffect alcoholeff;
    private void OnCollisionEnter(Collision collision)
    {
        BeerIconScript beer;
        beer = collision.gameObject.GetComponent<BeerIconScript>();
        
        if (beer != null)
        {
            alcoholeff.BeerUp();
            beer.gameObject.SetActive(false);
        }
    }
}
