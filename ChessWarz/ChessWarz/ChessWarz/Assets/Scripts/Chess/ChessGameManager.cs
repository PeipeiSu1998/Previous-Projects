using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ChessGameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    public Board board;

    public GameObject chosenPiece { get; set; }
    public GameObject gameProcessSaverPrefab;

    public GameObject[,] pieces;
    
    public PlayerInfo currentPlayer;

    private List<GameObject> movedPawns;

    private PlayerInfo white;
    private PlayerInfo black;
    
    private GameProcessSaver gameProcessSaver;

    public void SetPlayerColor(string color)
    {
        GameObject temp = GameObject.FindGameObjectWithTag("GameProcessSaver");
        
        gameProcessSaver = temp == null ? null : temp.GetComponent<GameProcessSaver>();

        if (gameProcessSaver == null)
        {
            gameProcessSaver = Instantiate(gameProcessSaverPrefab).GetComponent<GameProcessSaver>();
        }

        currentPlayer = new PlayerInfo(color);
        pieces = new GameObject[8, 8];
        movedPawns = new List<GameObject>();

        ChessPiece[,] chessPiecesLocations = gameProcessSaver.GetPiecesCoordinates();

        if (chessPiecesLocations != null)
        {
            GameManager.Instance.userStateManager.SetInitialUserState(gameProcessSaver.playerWon);
            LoadPiecesLocations(chessPiecesLocations);
        }

        else
        {
            InitialSetup();
        }
    }

    private void InitialSetup()
    {
        AddPiece("Rook", 0);
        AddPiece("Knight", 1);
        AddPiece("Bishop", 2);
        AddPiece("Queen", 3);
        AddPiece("King", 4);
        AddPiece("Bishop", 5);
        AddPiece("Knight", 6);
        AddPiece("Rook", 7);

        for (int i = 0; i < 8; i++)
        {
            AddPiece("Pawn", i);
        }

        PopulateArrayWithOpponentPieces();
    }

    public void SaveCurrentLocation()
    {
        if (chosenPiece != null)
        {
            gameProcessSaver.SaveCapturingAndAllLocations();
        }
    }

    private void AddPiece(string pieceType, int col)
    {
        int row;
        if (currentPlayer.color.Equals("white") && pieceType.Equals("Pawn"))
        {
            row = 1;
        }
        else if (currentPlayer.color.Equals("white"))
        {
            row = 0;
        }
        else if (currentPlayer.color.Equals("black") && pieceType.Equals("Pawn"))
        {
            row = 6;
        }
        else
        {
            row = 7;
        }

        GameObject pieceObject = board.AddPiece(currentPlayer.color, pieceType, col, row);
        currentPlayer.pieces.Add(pieceObject);
        pieces[col, row] = pieceObject;
    }

    private void PopulateArrayWithOpponentPieces()
    {
        int row;
        
        GameObject empty = new GameObject();

        if (currentPlayer.color.Equals("black"))
        {
            row = 0;
        }

        else
        {
            row = 6;
        }

        for (int i = 0; i < 8; i++)
        {
            pieces[i, row] = empty;
        }

        row++;

        for (int i = 0; i < 8; i++)
        {
            pieces[i, row] = empty;
        }
    }

    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        Piece piece = pieceObject.GetComponent<Piece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        List<Vector2Int> locations = piece.MoveLocations(gridPoint);

        // filter out offboard locations
        locations.RemoveAll(gp => gp.x < 0 || gp.x > 7 || gp.y < 0 || gp.y > 7);

        // filter out locations with friendly piece
        locations.RemoveAll(gp => FriendlyPieceAt(gp));

        return locations;
    }

    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        Piece pieceComponent = piece.GetComponent<Piece>();
        if (pieceComponent.type == ChessPiece.Pawn && !HasPawnMoved(piece) && piece.CompareTag("SelectedPiece"))
        {
            movedPawns.Add(piece);
        }

        Vector2Int startGridPoint = GridForPiece(piece);
        
        pieces[startGridPoint.x, startGridPoint.y] = null;
        pieces[gridPoint.x, gridPoint.y] = piece;
        
        board.MovePiece(piece, gridPoint);

        object[] pieceCoordinates = new object[] {startGridPoint.x, startGridPoint.y, gridPoint.x, gridPoint.y};

        PhotonNetwork.RaiseEvent(2, pieceCoordinates, new RaiseEventOptions {Receivers = ReceiverGroup.Others},
                                SendOptions.SendReliable);
    }

    private void LoadPiecesLocations(ChessPiece[,] piecesCoordinates)
    {
        GameObject empty = new GameObject();
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch (piecesCoordinates[i, j])
                {
                    case ChessPiece.None:
                        pieces[i, j] = null;
                        break;

                    case ChessPiece.Rook:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "Rook", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        break;

                    case ChessPiece.Knight:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "Knight", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        break;

                    case ChessPiece.Bishop:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "Bishop", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        break;

                    case ChessPiece.King:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "King", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        break;

                    case ChessPiece.Queen:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "Queen", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        break;

                    case ChessPiece.Pawn:
                        pieces[i, j] = board.AddPiece(currentPlayer.color, "Pawn", i, j);
                        currentPlayer.pieces.Add(pieces[i, j]);
                        
                        if (j != 1 && j != 6)
                        {
                            GameManager.Instance.chessGameManager.movedPawns.Add(pieces[i, j]);
                        }
                        
                        break;

                    case ChessPiece.Opponent:
                        pieces[i, j] = empty;
                        break;
                }
            }
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 2)
        {
            object[] pieceCoordinatesReceived = (object[]) photonEvent.CustomData;
            pieces[(int) pieceCoordinatesReceived[0], (int) pieceCoordinatesReceived[1]] = null;
            pieces[(int) pieceCoordinatesReceived[2], (int) pieceCoordinatesReceived[3]] = new GameObject();
        }
    }

    public bool HasPawnMoved(GameObject pawn)
    {
        return movedPawns.Contains(pawn);
    }
    
    public bool TurnRecognition(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 7 || gridPoint.y > 7 || gridPoint.x < 0 || gridPoint.y < 0)
        {
            return null;
        }

        return pieces[gridPoint.x, gridPoint.y];
    }

    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    public bool FriendlyPieceAt(Vector2Int gridPoint)
    {
        GameObject piece = PieceAtGrid(gridPoint);

        if (piece == null)
        {
            return false;
        }
        
        if (!currentPlayer.pieces.Contains(piece))
        {
            return false;
        }
        
        return true;
    }
}