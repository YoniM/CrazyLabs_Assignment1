using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerScript : MonoBehaviour
{
    public AlcoholEffect alcoholeff;
    public GameObject alcoholeff_object;

    public float bouncing_amplitude = 1f; // [m]
    public float bouncing_frequency = 50f; // [Hz]
    public bool Animate = false;
    void Start()
    {
        alcoholeff_object = GameObject.Find("AlcoholEffect");
        alcoholeff = alcoholeff_object.GetComponent<AlcoholEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Animate)
        {
            transform.position += Vector3.up * bouncing_amplitude * Mathf.Cos(bouncing_frequency * Time.time) * Time.deltaTime;
        }
    }

    public void DestroyThisInstance()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        alcoholeff.BeerUp();
    }

}
