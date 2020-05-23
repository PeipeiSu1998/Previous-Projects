using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class Shaking2 : MonoBehaviour
{

    public Hand leftHand, rightHand;
    public float nextShake, vibrationDuration, randomX, randomY, randomZ,coinFlip;

    private Transform leftParent;
    private Transform rightParent;



    //public static event Shake;

    private void Start()
    {
        nextShake = Time.time + 5;
        StartCoroutine(ShakeTime());
        leftParent = GameObject.Find("ParkinsonsElementLeft").transform;
        rightParent = GameObject.Find("ParkinsonsElementRight").transform;
    }
    private void Update()
    {

        ReturnRandomRange(vibrationDuration,1, 10);
        //ReturnRandomRange(randomX, -0.03f, 0.03f);
        //ReturnRandomRange(randomY, -0.03f, 0.03f);
        //ReturnRandomRange(randomZ, -0.03f, 0.03f);

        randomZ = Random.Range(-0.07f, 0.07f);
        randomX = Random.Range(-0.07f, 0.07f);
        randomY = Random.Range(-0.07f, 0.07f);



    }

    //runs forever as is
    public IEnumerator ShakeTime()
    {
        while (true)
        {
            float currentTime = Time.time;

            if (currentTime > nextShake)
            {

                VibrateController(ChooseCurrentHand());
                nextShake = currentTime + Random.Range(1f, 5f);

                
            }
            yield return null;
        }
        //think this can be removed
        yield return null;

    }

    public Hand ChooseCurrentHand()
    {
        
        if (Random.Range(1, 3) == 1)
        {
            return rightHand;
        }
        else

            return leftHand;
    }

    public void VibrateController(Hand chosentHand)
    {
        //float duration float frequency, float amplitude dont remember how these should be set

        chosentHand.TriggerHapticPulse(vibrationDuration, 50, 5);
        //might aswell be an event I guess
        //StartCoroutine(MoveHandTrans(chosentHand));
        MoveHandTrans(chosentHand);
        
    }

    public void MoveHandTrans(Hand chosentHand)
    {
        Vector3 originalPosition;
        Vector3 newPosition =  new Vector3(randomX, randomY, randomZ);

        
        

        if (chosentHand != null)
        {
            
            if (chosentHand.name == "LeftHand")
            {
                originalPosition = leftParent.transform.localPosition;
                leftParent.transform.localPosition = newPosition;
                 new WaitForSeconds(0.3f);
                leftParent.transform.localPosition = originalPosition;
               
            }
            else
            {
                originalPosition = rightParent.transform.localPosition;
                rightParent.transform.localPosition = newPosition;
                new WaitForSeconds(0.3f);
                rightParent.transform.localPosition = originalPosition;
            }

        }
    }

        public float ReturnRandomRange(float floatToBeRandom, float rangeMin, float rangeMax)
    {

        return Random.Range((float)rangeMin, (float)rangeMax); 
    }
}