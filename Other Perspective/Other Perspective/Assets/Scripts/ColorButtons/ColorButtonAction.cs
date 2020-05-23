using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonAction : ButtonAction
{
    
    public override bool Check(GameObject button1, GameObject button2)
    {
        return button1.GetComponent<MeshRenderer>().material.color == button2.GetComponent<MeshRenderer>().material.color;
    }
    public override void Act(int i, GameObject button)
    {
        this.icons[i].SetActive(false);
    }

    public override void DeleteLast()
    {
        if (!deleted && i < icons.Length - 1)
        {
            this.icons[i + 1].SetActive(true);
            i++;
            correct = lastCorrect;
        }
        deleted = true;
    }
    public override void Restart()
    {
        for (int j = icons.Length - 1; j >= 0; j--)
        {
            icons[j].SetActive(true);
        }
        i = icons.Length - 1;
        correct = true;
    }
}
