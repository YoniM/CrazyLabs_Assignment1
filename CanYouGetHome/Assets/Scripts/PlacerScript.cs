using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    public Transform obj_prefab;
    public float density;
    public float xmin, xmax, zmin, zmax;
    //public bool RandomRotationX, RandomRotationY, RandomRotationZ;
    
    void Start()
    {
   //     bool placed = false;
        int N = (int)(density * (xmax - xmin) * (zmax - zmin));
        Transform instance;
        Debug.LogError(N);
        //int tries = 0;
        for (int ii = 0; ii<N; ii++)
        {
            //            while (!placed && tries<3)
            //           {
            //             tries++;
            instance = Instantiate(obj_prefab, transform.position, obj_prefab.rotation, transform);
                instance.position = new Vector3(Random.Range(xmin, xmax), 0f, Random.Range(zmin, zmax));

            //Instantiate(obj_prefab, parent);
            //           
            //           placed = true;
            //     }
        }
    }

}
