
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldTrigger : MonoBehaviour
{

    public GameObject passwordEnter;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            passwordEnter.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        passwordEnter.SetActive(true);
        

    }
}

