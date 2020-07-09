using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Transform playerbody;
    public float vel = 5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        rb.velocity = vel * player.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
