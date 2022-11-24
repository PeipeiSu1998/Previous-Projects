using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public byte maxPlayers;

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        StartCoroutine(ConnectAutomatically());
    }

    public void Play()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode,
                                            string message)
    {
        PhotonNetwork.CreateRoom(null,
                                 new RoomOptions
                                  {MaxPlayers = maxPlayers});
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }

    public override void OnConnectedToMaster()
    {
        Play();
    }

    private IEnumerator ConnectAutomatically()
    {
        PhotonNetwork.ConnectUsingSettings();
        yield return new WaitForSecondsRealtime(3);
    }
}
