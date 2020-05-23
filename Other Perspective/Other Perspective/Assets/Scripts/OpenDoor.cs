
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{

    private InputField input;
    public GameObject door;
    public GameObject inputField;
    private bool openDoor = false;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public Button btn6;
    public Button btn7;
    public Button btn8;
    public Button btn9;
    public Button btn0;
    public Button del;
    public Button delAll;

    // Use this for initialization
    void Start()
    {
        input = gameObject.GetComponent<InputField>();

        input.text = "";

        btn1.onClick.AddListener(delegate { ButtonInput("1"); });

        btn2.onClick.AddListener(delegate{ButtonInput("2");});

        btn3.onClick.AddListener(delegate{ButtonInput("3");});

        btn4.onClick.AddListener(delegate { ButtonInput("4"); });

        btn5.onClick.AddListener(delegate { ButtonInput("5"); });

        btn6.onClick.AddListener(delegate { ButtonInput("6"); });

        btn7.onClick.AddListener(delegate { ButtonInput("7"); });

        btn8.onClick.AddListener(delegate { ButtonInput("8"); });

        btn9.onClick.AddListener(delegate { ButtonInput("9"); });

        btn0.onClick.AddListener(delegate{ButtonInput("0");});

        delAll.onClick.AddListener(DeleteAll);

        del.onClick.AddListener(DeleteNumber);
        //      inputField = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.text == "12321")
        {
            door.transform.localPosition -= new Vector3(-4,0, 0);
            inputField.SetActive(false);
        }
    }

    void ButtonInput(string number)
    {
        input.text += number;
    }

    void DeleteNumber()
    {
        if (input.text.Length > 0)
        {
            input.text = input.text.Remove(input.text.Length - 1);
        }
    }

    void DeleteAll()
    {
        if (input.text.Length > 0)
        {
            input.text = "";
        }
    }

    

   
}
