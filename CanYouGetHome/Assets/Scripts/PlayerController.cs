using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip sipclip;
    AudioSource audiosource;

    //public HealthSystem healthsys;
    public Level1Manager levelmanager;
    public AlcoholEffect alcoholeff;
    public float vmax0 = 18f; // [m/sec]
    private float vmax; // [m/sec]
    public float steering_streangth = 30f;
    public float MaxSteering = 1f;
    public float mincrashvelocity = 5.0f;
    public Transform WinArea;
    private Rigidbody rb;

    private float vel; // [m/sec]
    public float acce = 18f, dece = -18f; // [m/sec^2]
    private bool Accelerate;

    float rotation_factor, force_factor;
    private float moveX;

    int BeerCount;
    int prevmovedirection, movedirection;
    float rnd;

    int InputType;
    

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        //rb.velocity = transform.forward * v0;
        rotation_factor = steering_streangth * 0.1f * GameManager.Instance.SteeringFactor;
        force_factor = steering_streangth * 2.0f * GameManager.Instance.SteeringFactor;

        vel = 0f;
        vmax = vmax0 * GameManager.Instance.SpeedFactor;

        InputType = GameManager.Instance.InputType;
    }

    void FixedUpdate()
    {
        
        GetInputs();

        if (Accelerate || (moveX != 0))
        {
            float force = force_factor * (vel * moveX) * Time.deltaTime;
            float rotation = rotation_factor * vel * moveX * Time.deltaTime;
            StartCoroutine(ApplyMovement(force, rotation, Accelerate, alcoholeff.ActionTimeDelay));
        }
    }

    private void GetInputs()
    {
        switch (InputType)
        {
            case 0: // Swipe (Mobile)
                moveX = SwipeInput.Instance.Steer;
                Accelerate = SwipeInput.Instance.IsDraging;
                break;
            case 1: // Buttons (Mobile)
                moveX = levelmanager.moveRight;
                Accelerate = true;
                break;
            case 2: // Keyboard (Mobile)
                moveX = Input.GetAxis("Horizontal");
                Accelerate = Input.GetKey("space");
                break;
        }
        moveX = Mathf.Max(Mathf.Min(moveX, MaxSteering), -MaxSteering);


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

    private void OnTriggerEnter(Collider other)
    {
        BeerScript beer;
        beer = other.gameObject.GetComponent<BeerScript>();
        if (beer != null)
        {
            //    alcoholeff.BeerUp();
            beer.DestroyThisInstance();
            audiosource.PlayOneShot(sipclip, 2f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ObstacleScript obs;
        
        obs = collision.gameObject.GetComponent<ObstacleScript>();

        if (obs != null)
        {
            OtherCarScript othercar = obs.GetComponentInParent<OtherCarScript>();
            if (othercar != null || (obs.crashable && vel >= mincrashvelocity)) // ! I need to implement relative velocity instead of vel
            {
                StopCar(Mathf.Max((1 - obs.mass / rb.mass), 0f));
                levelmanager.GameOver();
            }
            else
            {
                StopCar(Mathf.Max((1 - obs.mass / rb.mass), 0f));
                obs.ObstableWasHit();
            }
            
        }

    }

    private void AccelerateCar(float acceleration)
    {
        vel += acceleration * Time.deltaTime;
        vel = Mathf.Max(Mathf.Min(vel, vmax), 0);
        //SipSystem.ApplyForce(-acceleration * transform.forward);
    }

    private void StopCar(float fac)
    {
        vel = vel * fac;
    }

}
