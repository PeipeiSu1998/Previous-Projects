using System;
using UnityEngine;
using Photon.Pun;
using Player = Valve.VR.InteractionSystem.Player;

[Serializable]
public class PUNBattleManager : MonoBehaviourPunCallbacks
{
    public GameObject headPrefab;
    public GameObject userPrefab;

    private GameObject userInstance;
    
    private Player steamVRPlayer;
    
    private PlayerTracker playerTracker;
    
    void Awake()
    {
        playerTracker = GameObject.FindGameObjectWithTag("PlayerTracker").GetComponent<PlayerTracker>();
        
        Vector3 initialPlayerPosition = playerTracker.firstPlayerToJoin ? new Vector3(-8.0f, 0, 0) : new Vector3(8.0f, 0, 0);
        Quaternion initialPlayerRotation = playerTracker.firstPlayerToJoin ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
       
        userInstance = PhotonNetwork.Instantiate(userPrefab.name, initialPlayerPosition, initialPlayerRotation);
        GameObject head = PhotonNetwork.Instantiate(headPrefab.name, userInstance.transform.position, userInstance.transform.rotation);
        
        steamVRPlayer = userInstance.GetComponent<Player>();
        steamVRPlayer.headCollider = head.GetComponent<Collider>();
        steamVRPlayer.rig2DFallback = userInstance;
        
        head.GetComponent<Head>().camera = userInstance.GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        GameManager.Instance.loadingScreenController.camera = userInstance.GetComponentInChildren<Camera>();
    }
}
