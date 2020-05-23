using System;
using System.Collections;
using System.Collections.Generic;
using Obi;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DoneTest : MonoBehaviour
{
    public static UnityEvent onMixingDone;
    public string msg;

    private ObiEmitter emitter;
    private Color targetColor;
    private Color color = Color.black;
    private bool done = false;
    private bool stop = false;
	// Use this for initialization
	void Start ()
    {
        if (onMixingDone == null) onMixingDone = new UnityEvent();
        emitter = GetComponent<ObiEmitter>();
        targetColor = new Color(1.000f, 0.000f, 0.830f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (stop)
        {
            return;
        }
        if (done)
        {
            Debug.Log(msg + ": " + "Done!!" + color);
            onMixingDone.Invoke();
            stop = true;
            return;
        }

        if (Math.Abs(color.r - 1f) < 0.002 && Math.Abs(color.g - 0f) < 0.002 && Math.Abs(color.b - 0.830f) < 0.002)
        {
            done = true;
        }
        else if (color != emitter.colors[150])
        {
            color = emitter.colors[150];
        }
    }
}
