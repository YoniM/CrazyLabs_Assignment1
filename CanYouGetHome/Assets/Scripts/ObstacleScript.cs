using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float mass = 100f;
    public bool crashable = true;
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
