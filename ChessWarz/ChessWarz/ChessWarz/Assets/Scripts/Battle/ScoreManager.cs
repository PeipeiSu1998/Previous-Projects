using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class ScoreManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private int myScore;
    private int opponentsScore;

    public ScoreDisplayManager scoreDisplayManager;

    public void IncrementMyScore()
    {
        myScore++;
        scoreDisplayManager.ValidateScore(myScore, opponentsScore);
        int[] eventContent = {opponentsScore, myScore};
        PhotonNetwork.RaiseEvent(6,
                                 eventContent,
                                 new RaiseEventOptions
                                  {Receivers = ReceiverGroup.Others},
                                SendOptions.SendReliable);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 6)
        {
            IncrementOpponentsScore();
        }
    }

    private void IncrementOpponentsScore()
    {
        opponentsScore++;
    }
}