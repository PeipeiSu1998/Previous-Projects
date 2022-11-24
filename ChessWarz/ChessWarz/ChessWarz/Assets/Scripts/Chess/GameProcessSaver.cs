using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameProcessSaver : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private ChessPiece[,] piecesCoordinates;

    private Vector2Int attackingPieceCoordinates;
    private Vector2Int attackedPieceCoordinates;

    [HideInInspector]
    public bool attackingWon;
    [HideInInspector]
    public bool playerWon;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveLocations()
    {
        piecesCoordinates = new ChessPiece[8, 8];
        GameObject[,] piecesFromChessGameManager = GameManager.Instance.chessGameManager.pieces;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (piecesFromChessGameManager[i, j] == null)
                {
                    piecesCoordinates[i, j] = ChessPiece.None;
                }
                
                else if (piecesFromChessGameManager[i, j].GetComponent<Piece>() != null)
                {
                    switch (piecesFromChessGameManager[i, j].name)
                    {
                        case string a when a.Contains("Rook"):
                            piecesCoordinates[i, j] = ChessPiece.Rook;
                            break;

                        case string b when b.Contains("Knight"):
                            piecesCoordinates[i, j] = ChessPiece.Knight;
                            break;

                        case string c when c.Contains("Bishop"):
                            piecesCoordinates[i, j] = ChessPiece.Bishop;
                            break;

                        case string d when d.Contains("King"):
                            piecesCoordinates[i, j] = ChessPiece.King;
                            break;

                        case string e when e.Contains("Queen"):
                            piecesCoordinates[i, j] = ChessPiece.Queen;
                            break;

                        case string f when f.Contains("Pawn"):
                            piecesCoordinates[i, j] = ChessPiece.Pawn;
                            break;
                    }
                }
                
                else if (piecesFromChessGameManager[i, j].GetComponent<Piece>() == null)
                {
                    piecesCoordinates[i, j] = ChessPiece.Opponent;
                }
            }
        }

        PhotonNetwork.LoadLevel(3);
    }
    
    public ChessPiece[,] GetPiecesCoordinates()
    {
        if (piecesCoordinates != null)
        {
            if (piecesCoordinates[attackingPieceCoordinates[0], attackingPieceCoordinates[1]] == ChessPiece.King && !attackingWon 
                ||
                piecesCoordinates[attackedPieceCoordinates[0], attackedPieceCoordinates[1]] == ChessPiece.King && attackingWon)
            {
                FindObjectOfType<EndGameManager>().YouLost();
            }

            if (attackingWon)
            {
                piecesCoordinates[attackedPieceCoordinates[0], attackedPieceCoordinates[1]] = 
                    piecesCoordinates[attackingPieceCoordinates[0], attackingPieceCoordinates[1]];
            }

            piecesCoordinates[attackingPieceCoordinates[0], attackingPieceCoordinates[1]] = ChessPiece.None;
        }
        
        return piecesCoordinates;
    }

    public void SetDidAttackingWin(bool playerWonTheBattle)
    {
        if (piecesCoordinates[attackingPieceCoordinates[0], attackingPieceCoordinates[1]] == ChessPiece.Opponent && playerWonTheBattle 
            ||
            piecesCoordinates[attackingPieceCoordinates[0], attackingPieceCoordinates[1]] != ChessPiece.Opponent && !playerWonTheBattle)
        {
            attackingWon = false;
        }
        
        else
        {
            attackingWon = true;
        }

        playerWon = playerWonTheBattle;
    }

    public void SaveCapturingAndAllLocations()
    {
        ChessGameManager chessGameManager = GameManager.Instance.chessGameManager;
        attackingPieceCoordinates = chessGameManager.GridForPiece(chessGameManager.chosenPiece);
        attackedPieceCoordinates = chessGameManager.chosenPiece.GetComponent<MoveSelector>().gridPoint;
        
        SendAttackingAndAttackedCoordinates();
        SaveLocations();
    }

    private void SendAttackingAndAttackedCoordinates()
    {
        int[] eventContent =
        {
            attackingPieceCoordinates.x, attackingPieceCoordinates.y, attackedPieceCoordinates.x,
            attackedPieceCoordinates.y
        };
        
        PhotonNetwork.RaiseEvent(7, eventContent, new RaiseEventOptions {Receivers = ReceiverGroup.Others},
                                SendOptions.SendReliable);
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 7)
        {
            int[] eventContent = (int[]) photonEvent.CustomData;
            
            attackingPieceCoordinates = new Vector2Int(eventContent[0], eventContent[1]);
            attackedPieceCoordinates = new Vector2Int(eventContent[2], eventContent[3]);
            
            SaveLocations();
        }
    }
}