using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    Camera cam;
    float ataxia_rate, delta_ataxia;
    bool taxing, finishtaxing;
    float t0;
    public float taxing_time = 2f; // [sec]
    public float taxingspeed = 0.05f;
    public float a = 0.2f; // taxingmagnitude
    Vector3 targetDirection, deltadirection;

    public float NarrowingViewFactor = 0.9f;
    public Transform car;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        taxing = false;
        finishtaxing = false;
        ataxia_rate = 0f;
        t0 = 0f;
        deltadirection = transform.forward - car.forward;
        targetDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!taxing && !finishtaxing)
        {
            if (Random.Range(0f, 1f) < ataxia_rate)
            {
                taxing = true; finishtaxing = false;
                t0 = Time.time;
                targetDirection = transform.forward + new Vector3(Random.Range(-a, a), Random.Range(-a, a), Random.Range(-a, a));
            }
        }
        if (taxing && !finishtaxing)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, taxingspeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            if (Time.time > t0 + taxing_time)
            {
                finishtaxing = true; taxing = false;
                t0 = Time.time;
            }
                
        }
        if (finishtaxing && !taxing)
        {
            Vector3 newDirection2 = Vector3.RotateTowards(transform.forward, car.forward + deltadirection, taxingspeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection2);
            if (Time.time > t0 + taxing_time)
            {
                finishtaxing = false; taxing = false;
                t0 = Time.time;
            }
        }
    }

    public void IncreaseAtaxia()
    {
        ataxia_rate += 0.05f;
        taxing_time += 0.1f;
        taxingspeed += 0.02f;
        a += 0.02f;
    }

}
