using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BadVisionControl : MonoBehaviour {

    public PostProcessingProfile[] profiles;
    private PostProcessingBehaviour behaviour;

    private void Start()
    {
        behaviour = GetComponent<PostProcessingBehaviour>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeProfile(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeProfile(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeProfile(2);
        }
    }
    public void ChangeProfile(int number)
    {
        behaviour.profile = profiles[number-1];
    }
}
