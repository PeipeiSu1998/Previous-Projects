using Photon.Pun;
using UnityEngine;

public class Head : MonoBehaviourPunCallbacks
{
    public Camera camera { get; set; }

    public override void OnEnable()
    {
        base.OnEnable();
        
        if (photonView.IsMine)
        {
            GetComponent<SphereCollider>().enabled = false;
            
            if (GetComponentInChildren<CapsuleCollider>() != null)
            {
                GetComponentInChildren<CapsuleCollider>().enabled = false;
            }
                
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            transform.position = camera.transform.position;
            transform.rotation = camera.transform.rotation;
        }
    }
}
