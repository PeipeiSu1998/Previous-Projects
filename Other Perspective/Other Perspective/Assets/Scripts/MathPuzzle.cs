using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Wilberforce;

public class MathPuzzle : MonoBehaviour {


    int _RightAnswer, _NumberOfTries;
    public int Answer;
    public InputField RiddleAnswer;
    public Button BtnCheckAnswer;
    private Colorblind ColorBlindScript;

   

    private void Awake()
    {
        ColorBlindScript = GetComponent<Colorblind>();
        //if more puzzles instantiate 
        _NumberOfTries = 0;
        _RightAnswer = 125;
    }
    // Use this for initialization
    void Start () {

        //var colorblindScript = ColorBlindScript as Colorblind;
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //HandleButtonPress();
	}

    void HandleButtonPress()
    {
        //BtnCheckAnswer.GetComponent<Button>().onClick.AddListener(HandleAnswer);        
    }

    void HandleAnswer()
    {
        //setinput should be run click on something, only run here for testing
        SetInput();
        if (Answer != _RightAnswer)
        {
            print("not so much succes");
            NumberOfTries();
        }
        else
            print("Succes");
    }

    void SetInput()
    {
        Answer = Int32.Parse(RiddleAnswer.text);
    }

   

    void NumberOfTries()
    {
    if(_NumberOfTries == 2)
        {
            
            Debug.Log("NOW LOOK AT WHAT YOU HAVE DONE!");
            //perhaps play audio 
            _NumberOfTries = 0;
        }
    else
            _NumberOfTries++;
    }

    

}
