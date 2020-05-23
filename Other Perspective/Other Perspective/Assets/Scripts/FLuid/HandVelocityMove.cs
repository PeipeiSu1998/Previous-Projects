using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class HandVelocityMove : MonoBehaviour
{

    public SteamVR_Action_Boolean grabPinchAction;

    private Hand hand;
    private VelocityMove glass;
    
    void Start()
    {
        hand = GetComponent<Hand>();
    }

    void Update()
    {
        if (grabPinchAction.GetStateDown(hand.handType) && hand.hoveringInteractable != null && hand.hoveringInteractable.gameObject.tag == "Glass")
        {
            glass = hand.hoveringInteractable.GetComponent<VelocityMove>();
            glass.Grab(hand);
        }
        if (grabPinchAction.GetStateUp(hand.handType) && glass != null)
        {
            glass.Drop();
        } 
    }
}
