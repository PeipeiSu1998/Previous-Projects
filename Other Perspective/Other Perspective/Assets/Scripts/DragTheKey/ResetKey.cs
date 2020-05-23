using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ResetKey : MonoBehaviour
{
    public Vector3 originalPosition;
    public GameObject key;
    public Hand rHand;
    public Hand lHand;
    // Use this for initialization
    void Start()
    {
        //originalPosition = key.transform;
        originalPosition = new Vector3(3.5f, 2, 18);
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        key.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        if (rHand.AttachedObjects.Count > 0)
        {
            rHand.DetachObject(key);
        }
        else if (lHand.AttachedObjects.Count > 0)
        {
            lHand.DetachObject(key);
        }
        key.transform.position = originalPosition;
    }
    
}