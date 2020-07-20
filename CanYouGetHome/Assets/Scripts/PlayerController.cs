using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public HealthSystem healthsys;
    public Level1Manager levelmanager;
    public AlcoholEffect alcoholeff;
    public float vmax0 = 18f; // [m/sec]
    private float vmax; // [m/sec]
    public float steering_streangth = 30f;
    public Transform WinArea;
    private Rigidbody rb;

    private float vel; // [m/sec]
    public float acce = 18f , dece = -18f; // [m/sec^2]
    private bool Accelerate;

    float rotation_factor, force_factor;
    private float moveX;

    int BeerCount;
    int prevmovedirection, movedirection;
    float rnd;

    //public SipScript SipSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //rb.velocity = transform.forward * v0;
        rotation_factor = steering_streangth * 0.1f * GameManager.Instance.SteeringFactor;
        force_factor = steering_streangth * 2.0f * GameManager.Instance.SteeringFactor;

        vel = 0f;
        vmax = vmax0 * GameManager.Instance.SpeedFactor;
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        Accelerate = Input.GetKey("space");
        if (Accelerate || (moveX != 0))
        {
            float force = force_factor * (vel * moveX) * Time.deltaTime;
            float rotation = rotation_factor * vel * moveX * Time.deltaTime;
            StartCoroutine(ApplyMovement(force, rotation, Accelerate, alcoholeff.ActionTimeDelay));
        }
    }

    private void Update()
    {
        transform.position += transform.forward * vel * Time.deltaTime; // moving forward at speed of vel
    }

    IEnumerator ApplyMovement(float force, float rotation, bool Accelerate, float timedelay)
    {
        yield return new WaitForSeconds(timedelay);

        if (Accelerate)
        {
            if (vel <= vmax)
                AccelerateCar(acce);
            else
                AccelerateCar(dece);
        }
        else if (vel > 0)
        {
            AccelerateCar(dece);
        }
        rb.AddForce(force * transform.right);
        transform.Rotate(0, rotation, 0);

        //SipSystem.ApplyForce(-force * transform.right);
    }


    private void OnCollisionEnter(Collision collision)
    {
        ObstacleScript obs;
        BeerScript beer;
        //StreetScript street;
        
        obs = collision.gameObject.GetComponent<ObstacleScript>();
        beer = collision.gameObject.GetComponent<BeerScript>();

        /*
        street = collision.gameObject.GetComponent<StreetScript>();
        if (street != null)
            vmax = vmax0 * street.IncreasedVelocityFactor;
        else
            vmax = vmax0;
        */

        if (beer != null)
        {
            alcoholeff.BeerUp();
            beer.DestroyThisInstance();
        }
        if (obs!=null)
        {
            StopCar(Mathf.Max((1 - obs.mass / rb.mass),0f));
            if (obs.crashable)
                //healthsys.AddCrash();
                levelmanager.GameOver();

            obs.ObstableWasHit();
        }
        
    }

    private void AccelerateCar(float acceleration)
    {
        vel += acceleration * Time.deltaTime;
        vel = Mathf.Max(Mathf.Min(vel, vmax),0);
        //SipSystem.ApplyForce(-acceleration * transform.forward);
    }

    private void StopCar(float fac)
    {
        vel = vel * fac;
    }

}
