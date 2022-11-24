using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class Waiting : UserState
{

    public Waiting(User user) : base(user)
    {
        
    }
    
    public override void OnInitialStateEnter()
    {
        DisableControllers();
    }

    public override void OnStateEnter()
    {
        DisableControllers();
        PhotonNetwork.RaiseEvent(1,
                                 "Hello",
                                 new RaiseEventOptions
                                  {Receivers = ReceiverGroup.Others},
                                 SendOptions.SendReliable);
    }

    private void DisableControllers()
    {
        user.DisableControllers();
    }

    public override void Next()
    {
        user.SetState(new ChoosingPiece(user));
    }
}
