using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class KeyManager : MonoBehaviour {

    public SteamVR_Action_Vibration vibration;
    public Hand rHand;
    public Hand lHand;
    private SteamVR_Behaviour_Pose rBehaviourHand;
    private SteamVR_Behaviour_Pose lBehaviourHand;
    private void Start()
    {
        lBehaviourHand = lHand.GetComponent<SteamVR_Behaviour_Pose>();
        rBehaviourHand = rHand.GetComponent<SteamVR_Behaviour_Pose>();
		KeyCollide.collided += Drop;
	}
    private void Drop(){
        if(rHand.AttachedObjects.Count > 0) {
            rHand.DetachObject(gameObject);
            vibration.Execute(0, 0.5f, 160, 0.5f, rBehaviourHand.inputSource);
        }
        else if (lHand.AttachedObjects.Count > 0){
            lHand.DetachObject(gameObject);
            vibration.Execute(0, 0.5f, 160, 0.5f, lBehaviourHand.inputSource);
        }
	}

}
