using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerScript : MonoBehaviour
{
    public float bouncing_amplitude = 1f; // [m]
    public float bouncing_frequency = 50f; // [Hz]

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * bouncing_amplitude * Mathf.Cos(bouncing_frequency*Time.time) * Time.deltaTime;
    }
}
