using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class UserStateManager : IOnEventCallback
{
    public User user { private get; set; }
    
    private static UserStateManager instance;

    private UserStateManager()
    {
        
    }

    public static UserStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserStateManager();
            }

            return instance;
        }
    }
    
    public void SetInitialUserState(bool white)
    {
        if (white)
        {
            user.SetState(new ChoosingPiece(user));
        }

        else
        {
            user.SetInitialStateToWaiting(new Waiting(user));
        }
        
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 1)
        {
            Next();
        }
    }
    
    public void Next()
    {
        user.NextState();
    }

    public void Previous()
    {
        user.PreviousState();
    }
}
