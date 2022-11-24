using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    private static GameManager instance;
    
    public UserStateManager userStateManager { get; private set; }

    public ChessGameManager chessGameManager;

    public PUNGameManager punGameManager;

    public LoadingScreenController loadingScreenController;


    public static GameManager Instance { get { return instance; } }
    void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } 
        else 
        {
            instance = this;
        }
        
        userStateManager = UserStateManager.Instance;
    }
}
