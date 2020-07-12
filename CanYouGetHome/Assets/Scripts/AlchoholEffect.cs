using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchoholEffect : MonoBehaviour
{
    public static AlchoholEffect Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private float actionTimeDelay;
    public float MaxActionTimeDelay = 0.45f;

    public float ActionTimeDelay { get { return actionTimeDelay; } }
    
    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
    }

    public void BeerUp()
    {
        actionTimeDelay += 0.15f;
        actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
    }


}
