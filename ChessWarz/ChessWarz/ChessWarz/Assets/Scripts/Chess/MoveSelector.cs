using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MoveSelector : MonoBehaviourPunCallbacks
{
    public GameObject moveLocationPrefab;
    public GameObject attackLocationPrefab;

    public Vector2Int gridPoint = new Vector2Int(0, 0);

    private List<Vector2Int> moveLocations = new List<Vector2Int>();
    private List<GameObject> locationHighlights = new List<GameObject>();

    private Vector2Int originalPiecePosition;

    private bool isMoving;

    private ChessGameManager chessGameManager;

    private void Start()
    {
        chessGameManager = GameManager.Instance.chessGameManager;
    }

    private void GetMoveLocations()
    {
        moveLocations = chessGameManager.MovesForPiece(gameObject);
    }

    public void HighlightLocations()
    {
        locationHighlights = new List<GameObject>();
        GetMoveLocations();

        if (moveLocations.Count == 0)
        {
            CancelMove();
        }

        foreach (Vector2Int loc in moveLocations)
        {
            GameObject highlight;
            Vector3 highlightPosition = Geometry.PointFromGrid(loc);
            
            if (chessGameManager.PieceAtGrid(loc))
            {
                highlight = Instantiate(attackLocationPrefab, highlightPosition, Quaternion.identity, gameObject.transform);
            }
            
            else
            {
                highlight = Instantiate(moveLocationPrefab, highlightPosition, Quaternion.identity, gameObject.transform);
            }

            locationHighlights.Add(highlight);
        }
    }
    
    public void SelectAPiece()
    {
        originalPiecePosition = chessGameManager.GridForPiece(gameObject);
        
        if(chessGameManager.TurnRecognition(gameObject))
        {
            gameObject.tag = "SelectedPiece";
            chessGameManager.chosenPiece = gameObject;
            gameObject.transform.position += new Vector3(0, 1, 0);
            ChangeState(true);
            isMoving = true;
        }
    }
    
    public void MoveThePiece()
    {
        if (isMoving)
        {
            if (!moveLocations.Contains(gridPoint))
            {
                isMoving = false;
                gameObject.tag = "Piece";
                chessGameManager.Move(gameObject, originalPiecePosition);

                foreach (GameObject highlight in locationHighlights)
                {
                    Destroy(highlight);
                }

                chessGameManager.chosenPiece = null;
                ChangeState(false);
                return;
            }

            if (chessGameManager.PieceAtGrid(gridPoint) == null)
            {
                chessGameManager.Move(gameObject, gridPoint);
                chessGameManager.chosenPiece = null;
                ChangeState(true);
            }
            
            else
            {
                PhotonNetwork.RaiseEvent(4, "Ni hao", new RaiseEventOptions {Receivers = ReceiverGroup.All},
                                        SendOptions.SendReliable);
            }

            gameObject.tag = "Piece";
            isMoving = false;
            TurnExchange();
        }
    }

    private void CancelMove()
    {
        enabled = false;

        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }

        chessGameManager.Move(gameObject, originalPiecePosition);
        chessGameManager.chosenPiece = null;
        ChangeState(false);
    }

    private void TurnExchange()
    {
        isMoving = false;

        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }
    }

    private void ChangeState(bool next)
    {
        if (next)
        {
            GameManager.Instance.userStateManager.Next();
        }
            
        else
        {
            GameManager.Instance.userStateManager.Previous();
        }
    }
}