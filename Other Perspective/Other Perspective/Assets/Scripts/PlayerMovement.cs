
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rb.position += transform.forward * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.S))
        {
            rb.position -= transform.forward * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(0f, -(10) * Time.deltaTime * 5, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(0f, 10 * Time.deltaTime * 5, 0f);
        }
    }
}

