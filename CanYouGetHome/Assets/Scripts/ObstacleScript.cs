using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float mass;
    public bool crashable = false;
    public float time_to_destruction = 0f;

    public void ObstableWasHit()
    {
        if (!crashable)
            Invoke("DestroyThisInstance", time_to_destruction);
    }

    void DestroyThisInstance()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        
    }




}
