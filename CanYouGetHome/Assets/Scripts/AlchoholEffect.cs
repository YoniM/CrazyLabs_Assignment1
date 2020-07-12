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
    public float deltaTimeDelay = 0.15f;

    private int beercount;

    public float ActionTimeDelay { get { return actionTimeDelay; } }
    public float BeerCount { get { return beercount; } }


    // Start is called before the first frame update
    void Start()
    {
        actionTimeDelay = 0f;
        beercount = 0;
    }

    public void BeerUp()
    {
        beercount++;
        actionTimeDelay += deltaTimeDelay;
        actionTimeDelay = Mathf.Min(actionTimeDelay, MaxActionTimeDelay);
    }

}
