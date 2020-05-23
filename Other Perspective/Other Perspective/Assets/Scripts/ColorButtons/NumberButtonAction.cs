using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NumberButtonAction : ButtonAction
{
    public Text display;
    private string tempDisplay;

    private void Start()
    {
        if (colorButtonEvent == null)
            colorButtonEvent = new UnityEvent();
        ButtonAction.colorButtonEvent.AddListener(Activate);
        gameObject.SetActive(false);
    }
    public override bool Check(GameObject button1, GameObject button2)
    {
        return button1.name.Equals(button2.name);
    }
    public override void Act(int i, GameObject button)
    {
        tempDisplay = " ";
        for (int j = 1; j < display.text.Length; j++)
        {
            if (j != i * 2 + 1)
                tempDisplay += display.text[j];
            else
                tempDisplay += button.name;
        }
        display.text = tempDisplay;
    }
    public override void DeleteLast()
    {
        //tralala
    }
    public override void Restart()
    {
        display.text = " _ _ _ _ _ _ _ _";
        i = icons.Length - 1;
        correct = true;
    }
    public void Activate()
    {
        gameObject.SetActive(true);
        i = icons.Length - 1;
        correct = true;
    }

}
