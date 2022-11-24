using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public GameObject panel;

    private IEnumerator TheEnd()
    {
        panel.SetActive(true);
        yield return new WaitUntil(() => GameManager.Instance.chessGameManager.pieces != null);
        GameObject[,] pieces = GameManager.Instance.chessGameManager.pieces;
        
        foreach (GameObject piece in pieces)
        {
            if (piece != null)
            {
                piece.SetActive(false);
            }
        }
    }

    public void YouLost()
    {
        StartCoroutine(TheEnd());
        panel.GetComponentInChildren<Text>().text = "You lost";
        
        PhotonNetwork.RaiseEvent(8, null, new RaiseEventOptions {Receivers = ReceiverGroup.Others},
                                SendOptions.SendReliable);
    }

    public void YouWon()
    {
        StartCoroutine(TheEnd());
        panel.GetComponentInChildren<Text>().text = "Congratulations, you won!";
    }
    
    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 8)
        {
            YouWon();
        }
    }
}