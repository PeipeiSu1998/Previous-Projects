using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class VelocityMove : MonoBehaviour {
    
    public float speed;

    private Hand hand;
    private Rigidbody rb;
    private bool _grab;
    private Quaternion startRotation, startRotationHand;


    void Start() {
        rb = GetComponent<Rigidbody>();
        _grab = false;
    }

    public void Grab(Hand hand)
    {
        this.hand = hand;
        startRotation = transform.rotation;
        startRotationHand = hand.transform.rotation;
        _grab = true;
    }

    public void Drop()
    {
        _grab = false;
    }
    
    void LateUpdate()
    {
        if (_grab && hand != null)
        {
            rb.velocity = (hand.transform.position - transform.position) * speed;            
            rb.MoveRotation((hand.transform.rotation  * startRotationHand) * startRotation);
        }
    }
    

}
