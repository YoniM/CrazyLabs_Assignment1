using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipScript : MonoBehaviour
{
    public Transform body;
    public Transform center;
    public float centeringforce = 1f;
    public Transform BeerIcon_prefab;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(-centeringforce * (body.position - center.position));
    }

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}
