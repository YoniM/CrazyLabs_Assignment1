using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float mass;


    public void ObstableWasHit()
    {
        Invoke("DestroyThisInstance", 1.0f);
    }

    void DestroyThisInstance()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        Debug.LogError("Destroyed this sucker!");
    }




}
