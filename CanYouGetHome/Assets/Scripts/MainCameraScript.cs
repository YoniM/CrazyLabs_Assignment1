using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public Transform maincamera;
    float ataxia_rate, delta_ataxia;
    bool taxing, finishtaxing;
    float t0;
    public float taxing_time = 2f; // [sec]

    float singleStep;
    public float taxingspeed = 0.3f;
    public float a = 0.2f; // taxingmagnitude
    Vector3 targetDirection, originaldirection;

    // Start is called before the first frame update
    void Start()
    {
        taxing = false;
        finishtaxing = false;
        ataxia_rate = 0f;
        delta_ataxia = 0.1f;
        t0 = 0f;
        originaldirection = transform.forward;
        targetDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!taxing && !finishtaxing && Random.Range(0f, 1f) < ataxia_rate)
        {
            taxing = true;
            finishtaxing = false;
            t0 = Time.time;
            targetDirection = transform.forward + new Vector3(Random.Range(-a, a), Random.Range(-a, a), Random.Range(-a, a));
        }
        if (taxing && !finishtaxing)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, taxingspeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            if (Time.time > t0 + taxing_time)
            {
                finishtaxing = true;
                taxing = false;
                t0 = Time.time;
            }
                
        }
        if (finishtaxing && !taxing)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, originaldirection, taxingspeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            if (Time.time > t0 + taxing_time)
            {
                finishtaxing = false;
                taxing = false;
                t0 = Time.time;
            }
        }
        


        
    }

    public void IncreaseAtaxia()
    {
        ataxia_rate += delta_ataxia;
    }
}
