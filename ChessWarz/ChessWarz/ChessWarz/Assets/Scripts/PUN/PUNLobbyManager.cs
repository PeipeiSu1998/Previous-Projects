using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class PUNLobbyManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public GameObject headPrefab;
    public GameObject userPrefab;

    private GameObject userInstance;

    void Awake()
    {
        userInstance = PhotonNetwork.Instantiate(userPrefab.name, new Vector3(Random.Range(-1.0f, 1.0f), 0, 0), Quaternion.identity);
        GameObject head = PhotonNetwork.Instantiate(headPrefab.name, userInstance.transform.position, userInstance.transform.rotation);
        
        head.GetComponent<Head>().camera = userInstance.GetComponentInChildren<Camera>();
    }

    private void Start()
    {
       PlayerTracker playerTracker =
       GameObject.FindGameObjectWithTag("PlayerTracker")
       .GetComponent<PlayerTracker>();
       
       GameManager.Instance.loadingScreenController.camera = 
       userInstance.GetComponentInChildren<Camera>();
        
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            playerTracker.firstPlayerToJoin = false;
            StartCoroutine(LoadChessScene());

        }
        
        else
        {
            playerTracker.firstPlayerToJoin = true;
        }
    }

    private IEnumerator LoadChessScene()
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.RaiseEvent(3,
                                 "Ahoj",
                                 new RaiseEventOptions 
                                  {Receivers = ReceiverGroup.All},
                                SendOptions.SendReliable);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 3)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }
}
