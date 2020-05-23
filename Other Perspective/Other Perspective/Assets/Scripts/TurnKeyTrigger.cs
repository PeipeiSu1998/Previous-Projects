using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TurnKeyTrigger : MonoBehaviour {

    public Animator anim;
    public Hand rHand;
    public Hand lHand;
    public GameObject teleportationPlane4, teleportationPlane1;




    private void OnTriggerEnter(Collider other)
    {
        
       if(other.name == "PadLock")
        {
            if (rHand.AttachedObjects.Count > 0)
            {
                rHand.DetachObject(gameObject);
            }
            else if (lHand.AttachedObjects.Count > 0)
            {
                lHand.DetachObject(gameObject);
            }
            
            gameObject.SetActive(false);
            anim.SetBool("OpenNow", true);
            //anim.Play("DoorOpen");
            teleportationPlane4.SetActive(true);
            teleportationPlane4.SetActive(true);
        }
        
    }
}
