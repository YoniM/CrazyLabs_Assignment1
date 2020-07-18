using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarScript : MonoBehaviour
{

    public float v0 = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * v0 * Time.deltaTime;
    }
}
