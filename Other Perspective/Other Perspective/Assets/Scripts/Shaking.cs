
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour {

    public Transform hand;

    public float shakeAmount = 0.7f;

    Vector3 originalPos;

    public Rigidbody rb;

    public static bool forefingerTouch;
    public static bool thumbTouch;

    public Rigidbody shpere;

    public Transform trigger1;

    void Awake()
    {
        if (hand == null)
        {
            hand = GetComponent(typeof(Transform)) as Transform;
        }
    }

    // Use this for initialization
    void Start ()
    {
        forefingerTouch = false;
        thumbTouch = false;
    }
	
	// Update is called once per frame
	void Update () {
        hand.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

        if (forefingerTouch && thumbTouch)
        {
            shpere.position = trigger1.position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.position += transform.forward  * Time.deltaTime;
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

    void OnEnable()
    {
        originalPos = hand.localPosition;

    }

    void SphereMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            shpere.position += transform.forward * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            shpere.transform.Rotate(0f, -(10) * Time.deltaTime * 5, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            shpere.transform.Rotate(0f, 10 * Time.deltaTime * 5, 0f);
        }
    }
}

