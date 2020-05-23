
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTips : MonoBehaviour
{
    public GameObject tip;

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter(Collider other)
    {
        tip.SetActive(true);
    }
}


