using System;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[Serializable]
public class PUNGameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public GameObject chessBoardPrefab;
    public GameObject headPrefab;
    public GameObject userPrefab;
    
    [HideInInspector] 
    public GameObject userInstance;

    private PlayerTracker playerTracker;

    void Awake()
    {
        playerTracker = GameObject.FindGameObjectWithTag("PlayerTracker").GetComponent<PlayerTracker>();

        Vector3 initialPlayerPosition = playerTracker.firstPlayerToJoin ? new Vector3(-3.0f, 1, 0) : new Vector3(3.0f, 1, 0);

        userInstance = PhotonNetwork.Instantiate(userPrefab.name, initialPlayerPosition, Quaternion.identity);
        GameObject head = PhotonNetwork.Instantiate(headPrefab.name, userInstance.transform.position, userInstance.transform.rotation);

        head.GetComponent<Head>().camera = userInstance.GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        GameManager.Instance.loadingScreenController.camera = userInstance.GetComponentInChildren<Camera>();

        if (!playerTracker.firstPlayerToJoin)
        {
            GameManager.Instance.userStateManager.user = userInstance.GetComponent<User>();
            
            GameManager.Instance.userStateManager.SetInitialUserState(false);
            
            StartCoroutine(ShareBoard());
        }
        else
        {
            GameManager.Instance.userStateManager.user = userInstance.GetComponent<User>();
            
            GameManager.Instance.userStateManager.SetInitialUserState(true);
            
            chessBoardPrefab = PhotonNetwork.Instantiate(chessBoardPrefab.name, Vector3.zero, Quaternion.Euler(0, -0.038f, 0));
            
            chessBoardPrefab.SetActive(true);
            
            GameManager.Instance.chessGameManager.board = chessBoardPrefab.GetComponent<Board>();
            
            GameManager.Instance.chessGameManager.SetPlayerColor("white");
            
        }
    }

    private IEnumerator ShareBoard()
    {
        yield return new WaitUntil(() => GameObject.FindWithTag("ChessBoard") != null);
        GameManager.Instance.chessGameManager.board = GameObject.FindWithTag("ChessBoard").GetComponent<Board>();
        GameManager.Instance.chessGameManager.SetPlayerColor("black");
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 4)
        {
            GameManager.Instance.chessGameManager.SaveCurrentLocation();
        }
    }
}