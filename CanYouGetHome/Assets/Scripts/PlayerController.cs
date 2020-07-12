using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vmax = 18f; // [m/sec]
    public float steering_streangth = 20f;
    private Rigidbody rb;

    private float vel; // [m/sec]
    float acce; // [m/sec^2]

    float rotation_factor, force_factor;
    private float moveX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Color fullDark = new Color(32.0f / 255.0f, 28.0f / 255.0f, 46.0f / 255.0f);
        //RenderSettings.ambientLight = fullDark;
        //rb.velocity = transform.forward * v0;
        rotation_factor = steering_streangth * 0.1f;
        force_factor = steering_streangth * 2.0f;

        vel = 0f;
        acce = vmax;
        
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        float force = force_factor * (vel * moveX) * Time.deltaTime;
        rb.AddForce(force * transform.right);
    }

    private void Update()
    {
        if (vel < vmax)
            AccelerateCar(acce);

        //moveX = Input.GetAxis("Horizontal");
        float rotation = rotation_factor * vel * moveX * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        transform.position += transform.forward * vel * Time.deltaTime; // moving forward at speed of vel
        //Debug.Log(transform.rotation);

        if (Input.GetKeyDown("space"))
            StopCar(0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ObstacleScript obs;
        obs = collision.gameObject.GetComponent<ObstacleScript>();
        if (obs!=null)
        {
            StopCar(Mathf.Max((1 - obs.mass / rb.mass),0f));
            HealthSystem.Instance.AddCrash();
            obs.ObstableWasHit();
        }
        
    }

    private void AccelerateCar(float acceleration)
    {
        vel += acceleration * Time.deltaTime;
        vel = Mathf.Min(vel, vmax);
    }

    private void StopCar(float fac)
    {
        vel = vel * fac;
    }

}
