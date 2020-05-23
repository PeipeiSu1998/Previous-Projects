using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public GameObject glasses, bow;
    public Animator fade;
    private bool colorButtonsDone;
	// Use this for initialization
	void Start () {
        colorButtonsDone = false;

        if (ButtonAction.colorButtonEvent == null) ButtonAction.colorButtonEvent = new UnityEvent();
		if(Chackpoint.OnKeyPuzzleDone == null)
        {
            Chackpoint.OnKeyPuzzleDone = new UnityEvent();
        }
        if (DoneTest.onMixingDone == null) DoneTest.onMixingDone = new UnityEvent();
        DoneTest.onMixingDone.AddListener(FluidPuzzleDone);
        Chackpoint.OnKeyPuzzleDone.AddListener(KeyPuzzleDone);
        ButtonAction.colorButtonEvent.AddListener(OnGameDone);
	}

    private void KeyPuzzleDone()
    {
        Debug.Log("keyPuzzle Done!!");
    }

    private void FluidPuzzleDone()
    {
        Debug.Log("fluidPuzzle Done");
        glasses.SetActive(true);
        bow.SetActive(true);
    }

    private void OnDestroy()
    {
        Chackpoint.OnKeyPuzzleDone.RemoveListener(KeyPuzzleDone);
        DoneTest.onMixingDone.RemoveListener(FluidPuzzleDone);
    }

    private void OnGameDone()
    {
        if (!colorButtonsDone)
        {
            Debug.Log("colorDone");
            colorButtonsDone = true;
            return;
        }
        Debug.Log("gamedone");
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        fade.SetBool("StartFadeToBlack", false);
        fade.SetBool("StartFadeToBlack", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

}
