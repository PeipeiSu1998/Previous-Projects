using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chackpoint : MonoBehaviour {

    public GameObject nextCheckpoint;
    private static int countCheckpoints;
    public static UnityEvent OnKeyPuzzleDone;

    void Start()
    {
        KeyCollide.collided += DisableCkeckpoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        countCheckpoints++;
        Debug.Log(countCheckpoints);
        if (countCheckpoints < 3)
        {
            nextCheckpoint.SetActive(true);
            
        }
        else
        {
            nextCheckpoint.SetActive(false);
            if (OnKeyPuzzleDone != null) { OnKeyPuzzleDone.Invoke(); }
        }
        GetComponent<SphereCollider>().enabled = false;
        
    }
    public void DisableCkeckpoint()
    {
        countCheckpoints = 0;
        if(nextCheckpoint != null) nextCheckpoint.SetActive(false);
        GetComponent<SphereCollider>().enabled = true;

    }
}
