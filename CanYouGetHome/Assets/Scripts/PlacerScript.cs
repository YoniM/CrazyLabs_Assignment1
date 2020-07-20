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
    public float probRandomRotation = 0f; 

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

        BeerScript beer;
        beer = obj_prefab.GetComponent<BeerScript>();
        if (beer != null)
        {
            density *= GameManager.Instance.BeerDensityMultiplier;
        }

        Transform clone;
        int N = (int)(density * (xmax - xmin) * (zmax - zmin));
        for (int ii = 0; ii < N; ii++)
        {
            clone = Instantiate(obj_prefab, transform.position + new Vector3(Random.Range(xmin, xmax), obj_prefab.position.y, Random.Range(zmin, zmax)), obj_prefab.rotation, transform);
            clone.localScale = clone.localScale * (1 + RandomScaleFactor * Random.Range(-1f,1f));
            if (Random.Range(0f, 1f) < probRandomRotation)
                clone.Rotate(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
            clone.gameObject.SetActive(true);
        }

    }

}
