using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ButtonAction : MonoBehaviour
{

    public GameObject[] icons;
    public static int i;
    public static bool correct;
    public static bool lastCorrect;
    public static bool deleted;
    public static UnityEvent colorButtonEvent;
    void Start()
    {
        if (colorButtonEvent == null)
            colorButtonEvent = new UnityEvent();
        i = icons.Length - 1;
        correct = true;
    }
    public void Click(GameObject button)
    {
        lastCorrect = correct;
        deleted = false;
        Debug.Log(icons[i] + ", " + button);
        if (!Check(icons[i], button))
        {
            correct = false;
        }
        Act(i, button);
        i--;
        if (i < 0)
            if (correct)
            {

                colorButtonEvent.Invoke();
            }
            else
                Restart();
    }

    public abstract void Restart();
    public abstract void DeleteLast();
    public abstract bool Check(GameObject button1, GameObject button2);
    public abstract void Act(int i, GameObject button);
}
