using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    public Transform obj_prefab;
    public float density;
    public float xmin, xmax, zmin, zmax;
    public float RandomScaleFactor = 0.3f;
    //public bool RandomRotationX, RandomRotationY, RandomRotationZ;

    private void Start()
    {
        if (xmax < xmin)
        {
            float temp = xmax;
            xmax = xmin; xmin = temp;
        }
        if (zmax < zmin)
        {
            float temp = zmax;
            zmax = zmin; zmin = temp;
        }

        Transform clone;
        int N = (int)(density * (xmax - xmin) * (zmax - zmin));
        for (int ii = 0; ii < N; ii++)
        {
            clone = Instantiate(obj_prefab, new Vector3(Random.Range(xmin, xmax), 0f, Random.Range(zmin, zmax)), obj_prefab.rotation, transform);
            clone.localScale = clone.localScale * (1 + RandomScaleFactor * Random.Range(-1f,1f));
            clone.gameObject.SetActive(true);
        }

    }

}
