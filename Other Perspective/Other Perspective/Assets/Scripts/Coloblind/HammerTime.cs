using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentButDeadly : MonoBehaviour {

    public Animator hammerAnim;
    
    

	// Use this for initialization
	void Start () {

        StartCoroutine(HammerCountdown());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator HammerCountdown()
    {
        float duration = 15f;
        float timeRunning = 0f;

        while (true)
        {

            if (timeRunning >= duration)
            {
                
                yield return null;
                hammerAnim.SetBool("TimesUp", true);
            }
            else
                
                yield return new WaitForSeconds(1);
                    timeRunning++;
          

        }

    }

    public void RotateItem(GameObject item)
    {
        float maxRotation = 275f;

        for(int i = 0; i < maxRotation; i++)
        {
            item.transform.localRotation = GameObject.Find("Player/NoSteamVRFallbackObjects").transform.localRotation;
        }
    }
}
