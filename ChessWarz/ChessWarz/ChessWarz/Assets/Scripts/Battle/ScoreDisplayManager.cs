using System.Collections;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public Text scoreDisplay;

    private int myScore;
    private int opponentsScore;

    public void ValidateScore(int _myScore, int _opponentsScore)
    {
        if (_myScore >= 5)
        {
            if (myScore == 0 && opponentsScore == 0)
            {
                myScore = _myScore;
                opponentsScore = _opponentsScore;
            }

            UpdateScoreDisplay(myScore, opponentsScore, true);
            SetWinningChessPiece(true);
            StartCoroutine(GoBackToChessScene());
        }
        
        else if (_opponentsScore >= 5)
        {
            if (myScore == 0 && opponentsScore == 0)
            {
                myScore = _myScore;
                opponentsScore = _opponentsScore;
            }

            UpdateScoreDisplay(myScore, opponentsScore, false);
            SetWinningChessPiece(false);
        }
        else
        {
            UpdateScoreDisplay(_myScore, _opponentsScore);
        }
    }

    private void UpdateScoreDisplay(int _myScore, int _opponentsScore)
    {
        scoreDisplay.text = "You hit: " + _myScore + " times" + "\nYou got hit: " + _opponentsScore + " times";
    }

    private void UpdateScoreDisplay(int _myScore, int _opponentsScore, bool won)
    {
        scoreDisplay.text = won ? "You won!" : "You lost.";
        scoreDisplay.text += " Your score: " + _myScore + " your opponent's score " + _opponentsScore;
    }

    private void SetWinningChessPiece(bool won)
    {
        FindObjectOfType<GameProcessSaver>().SetDidAttackingWin(won);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 6)
        {
            int[] eventContent = (int[]) photonEvent.CustomData;
            ValidateScore(eventContent[0], eventContent[1]);
        }

        if (photonEvent.Code == 5)
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

    private IEnumerator GoBackToChessScene()
    {
        yield return new WaitForSeconds(3);
        PhotonNetwork.RaiseEvent(5, "czesc", new RaiseEventOptions {Receivers = ReceiverGroup.All},
                                SendOptions.SendReliable);
    }
}