using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseLightRotator : MonoBehaviour {

    public GameObject light;
    public int RotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        light.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));

    }
}
