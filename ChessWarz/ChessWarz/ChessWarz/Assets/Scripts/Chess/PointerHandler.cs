using UnityEngine;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class PointerHandler : MonoBehaviour
{
    private ChessGameManager chessGameManager;

    private SteamVR_LaserPointer laserPointer;

    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick += OnPointerClick;
    }

    private void OnDisable()
    {
        laserPointer.PointerClick -= OnPointerClick;
    }

    private void OnPointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("Piece"))
        {
            if (chessGameManager.chosenPiece == null)
            {
                e.target.GetComponent<MoveSelector>().SelectAPiece();
            }
        }
        else
        {
            if (chessGameManager.chosenPiece != null)
            {
                if (e.target.CompareTag("AvailableLocation"))
                {
                    GameObject temp = chessGameManager.chosenPiece;
                    temp.GetComponent<MoveSelector>().gridPoint = Geometry.GridFromPoint(e.target.transform.position);
                }
                
                chessGameManager.chosenPiece.GetComponent<MoveSelector>().MoveThePiece();
            }
        }
    }

    private void Start()
    {
        chessGameManager = GameManager.Instance.chessGameManager;
    }
}