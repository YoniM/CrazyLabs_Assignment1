using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance { get; private set; }

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

    public PostProcessProfile[] profiles;
    PostProcessVolume postvol;
    //DepthOfField blur;

    void Start()
    {
        postvol = GetComponent<PostProcessVolume>();
        //blur = GetComponent<DepthOfField>();
        //blur = ScriptableObject.CreateInstance<DepthOfField>();

    }
    /*
    public void AddBlur()
    {
        blur.focalLength.value *= 2f; 
    }

    public float GetBlur()
    {
        return blur.focalLength.value;
    }
    */
    public void ChangeProfile(int profile_number)
    {
        postvol.profile = profiles[profile_number];
    }


    
}
