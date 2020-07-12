using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v0;
    private Rigidbody rb;
    float steering_streangth = 20f;
    float rotation_factor, force_factor;

    private float moveX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Color fullDark = new Color(32.0f / 255.0f, 28.0f / 255.0f, 46.0f / 255.0f);
        //RenderSettings.ambientLight = fullDark;
        rb.velocity = transform.forward * v0;
        rotation_factor = steering_streangth * 0.1f;
        force_factor = steering_streangth * 2.0f;
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        float force = force_factor * (v0 * moveX) * Time.deltaTime;
        rb.AddForce(force * transform.right);
    }

    private void Update()
    {
        //moveX = Input.GetAxis("Horizontal");
        float rotation = rotation_factor * v0 * moveX * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    

}
