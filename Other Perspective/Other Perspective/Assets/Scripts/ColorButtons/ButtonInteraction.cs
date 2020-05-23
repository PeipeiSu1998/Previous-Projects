using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class ButtonInteraction : MonoBehaviour {

	public SteamVR_Action_Boolean grabPinchAction;

    private Hand hand;
    
    void Start()
    {
        hand = GetComponent<Hand>();
    }

    void Update()
    {
        if (grabPinchAction.GetStateDown(hand.handType) && hand.hoveringInteractable != null && hand.hoveringInteractable.gameObject.tag == "Button")
        {
            hand.hoveringInteractable.GetComponent<ButtonAction>().Click(hand.hoveringInteractable.gameObject);
        }
        if (grabPinchAction.GetStateDown(hand.handType) && hand.hoveringInteractable != null && hand.hoveringInteractable.gameObject.tag == "ResetButton")
        {
            hand.hoveringInteractable.GetComponent<ButtonAction>().Restart();
        }
        if (grabPinchAction.GetStateDown(hand.handType) && hand.hoveringInteractable != null && hand.hoveringInteractable.gameObject.tag == "DeleteButton")
        {
            hand.hoveringInteractable.GetComponent<ButtonAction>().DeleteLast();
        }
    }
}
