using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeThings : MonoBehaviour
{
    
    public GameObject[] things;
    public int nmax;

    // Start is called before the first frame update
    void Start()
    {
        // Obtain parent positon:
        Transform trans;
        trans = this.gameObject.GetComponent<Transform>();
        Vector3 center;
        float shelflength;
        GameObject clone;

        center = trans.position;
        shelflength = trans.localScale.y;
        Vector3 forward = trans.forward;
        
        // Instanciate objects:
        //foreach (GameObject thing in things)
        int n , ii = 1 , jj = 0;
        //n = Random.Range(Mathf.FloorToInt(nmax/2), nmax);
        n = nmax;
        float dy = shelflength / n;
        float y = shelflength*(Random.Range(0.1f,0.5f) - 0.5f);
        float pchange = (float)1 / (float)n;
        while ((y< shelflength/2 - dy) && (ii<n) && (jj<things.Length-1) )
        {
            if (Random.Range(0f, 1f) < pchange)
                jj++; // next thing in list
            clone = Instantiate(things[jj], center + y*forward, Quaternion.identity);
            clone.transform.localScale *= 5f;
            y = y + dy;
            ii++;
        }



    }

    // Update is called once per frame
    void Update()
    {
    }
}
