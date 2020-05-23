using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform playerTransform;
    private Vector3 offset;
    [SerializeField]
    private float xOffset, yOffset, zOffset;
	// Use this for initialization
	void Awake () {
        //playerTransform = GameObject.Find("Player/NoSteamVRFallbackObjects").transform; /*GameObject.Find("Player /SteamVRObjects/VRCamera").transform;*/
        offset = new Vector3(xOffset, yOffset, zOffset);
        
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = playerTransform.position + offset;
        
	}
}
