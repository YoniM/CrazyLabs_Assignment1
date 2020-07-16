using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HealthSystem healthsys;
    public AlcoholEffect alcoholeff;
    public float vmax = 18f; // [m/sec]
    public float steering_streangth = 20f;
    private Rigidbody rb;

    private float vel; // [m/sec]
    public float acce = 18f , dece = -18f; // [m/sec^2]
    private bool Accelerate;

    float rotation_factor, force_factor;
    private float moveX;

    int BeerCount;
    int prevmovedirection, movedirection;
    float rnd;

    public SipScript SipSystem;

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
        //acce = vmax;
        //dece = -acce;
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

        if (Input.GetKey(KeyCode.Escape))
        {
            healthsys.GameOver();
        }
    }

    IEnumerator ApplyMovement(float force, float rotation, bool Accelerate, float timedelay)
    {
        yield return new WaitForSeconds(timedelay);

        if ((Accelerate) && (vel < vmax))
            AccelerateCar(acce);
        else if (vel > 0)
            AccelerateCar(dece);

        rb.AddForce(force * transform.right);
        transform.Rotate(0, rotation, 0);

        SipSystem.ApplyForce(-force * transform.right);
    }


    private void OnCollisionEnter(Collision collision)
    {
        ObstacleScript obs;
        BeerScript beer;
        obs = collision.gameObject.GetComponent<ObstacleScript>();
        beer = collision.gameObject.GetComponent<BeerScript>();

        if (beer != null)
        {
            alcoholeff.BeerUp();
        }
        if (obs!=null)
        {
            StopCar(Mathf.Max((1 - obs.mass / rb.mass),0f));
            if (obs.crashable)
                healthsys.AddCrash();

            obs.ObstableWasHit();
        }
        
    }

    private void AccelerateCar(float acceleration)
    {
        vel += acceleration * Time.deltaTime;
        vel = Mathf.Max(Mathf.Min(vel, vmax),0);
        SipSystem.ApplyForce(-acceleration * transform.forward);
    }

    private void StopCar(float fac)
    {
        vel = vel * fac;
    }

}
