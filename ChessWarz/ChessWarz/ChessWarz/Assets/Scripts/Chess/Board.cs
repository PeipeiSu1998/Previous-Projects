using Photon.Pun;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject AddPiece(string color, string pieceType, int col, int row)
    {
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        GameObject newPiece = PhotonNetwork.Instantiate(color + pieceType, Geometry.PointFromGrid(gridPoint), Quaternion.identity);
        newPiece.transform.parent = gameObject.transform;
        return newPiece;
    }

    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = Geometry.PointFromGrid(gridPoint);
        GameManager.Instance.chessGameManager.chosenPiece = null;
    }
}