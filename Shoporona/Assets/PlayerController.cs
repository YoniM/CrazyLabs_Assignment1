using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Transform playerbody;
    public float vel = 5f;
    private Rigidbody rb;

    public float SideSlideSpeed = 5f;
    public Transform RightSlideLoc;
    public Transform LeftSlideLoc;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        rb.velocity = vel * player.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float step = SideSlideSpeed * Time.deltaTime; // calculate distance to move
            
        if (Input.GetKey(KeyCode.P))
        {
            playerbody.position = Vector3.MoveTowards(playerbody.position, RightSlideLoc.position, step);
        }
        if (Input.GetKey(KeyCode.O))
        {
            playerbody.position = Vector3.MoveTowards(playerbody.position, LeftSlideLoc.position, step);
        }

    }
}
