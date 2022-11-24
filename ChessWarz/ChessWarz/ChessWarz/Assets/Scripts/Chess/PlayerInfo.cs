using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public List<GameObject> pieces;
    //public List<GameObject> capturedPieces;

    public string color;
    
    public int forward;

    public PlayerInfo(string color)
    {
        this.color = color;
        pieces = new List<GameObject>();
        //capturedPieces = new List<GameObject>();

        if (color.Equals("white"))
        {
            forward = 1;
        }
        else
        {
            forward = -1;
        }
    }
}