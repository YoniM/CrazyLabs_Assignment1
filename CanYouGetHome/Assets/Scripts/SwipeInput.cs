using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{

    #region Singleton Setup
    public static SwipeInput Instance { get; private set; }

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

    #endregion Singleton Setup

    [Header("Tweaks")]
    [SerializeField] private float deadzone = Screen.width * 0.05f;
    [SerializeField] private float vertical_release = Screen.height * 0.5f;
    [SerializeField] public float sensitivity = 0.005f;

    private bool tap, isDraging;
    private Vector2 startTouch, holdDelta;
    private float steer;

    public bool Tap { get { return tap;}}
    public bool IsDraging { get { return isDraging; } }
    public Vector2 HoldDelta { get { return holdDelta; } }
    public float Steer { get { return steer; } }
    


    private void Update()
    {
        tap = false;
        #if UNITY_EDITOR
            UpdateStandalone();
        #else
            UpdateMobile();
        #endif

        
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                holdDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                holdDelta = (Vector2)Input.mousePosition - startTouch;
        } else
        {
            holdDelta = Vector2.zero;
        }
            
        if (isDraging && Mathf.Abs(holdDelta.x) > deadzone)
        {
            steer = holdDelta.x * sensitivity;
        }

        if (isDraging && Mathf.Abs(holdDelta.y) > vertical_release)
        {
            Reset();
        }
            

    }

    private void UpdateStandalone()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
    }

    private void UpdateMobile()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        tap = isDraging = false;
        startTouch = holdDelta = Vector2.zero;
        steer = 0f;
    }

}
