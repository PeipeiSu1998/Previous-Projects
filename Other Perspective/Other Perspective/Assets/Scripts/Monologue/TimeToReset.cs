using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToReset : MonoBehaviour
{
    private int time;
    public AudioSource audioSrc;
    public AudioClip fiveMinutes, tenMinutes, fifteenMinutes, timesUp;
    public List<AudioClip> startClips;

    // Start is called before the first frame update
    void Start()
    {
        
        time = 0;
        StartCoroutine(IntroRoomGlados());

    }

    public IEnumerator Timer()
    {
        while (true)
        {
            if(time == 0)
            {
                audioSrc.PlayOneShot(fifteenMinutes);
            }
            print(Time.time);
            if (time == 300)
                
            {
                audioSrc.PlayOneShot(tenMinutes);
            }//600
            if (time == 600)
            {
                audioSrc.PlayOneShot(fiveMinutes);
            }//900
            if (time == 900)
            {
                //reset game perhaps spawn gas
                audioSrc.PlayOneShot(timesUp);

                //StopAllCoroutines();

            }
            yield return new WaitForSeconds(1f);
            time++;
        }
    }

    public IEnumerator IntroRoomGlados()
    {
        
        
        //for (int i = 0; i < startClips.Count; i++)
            foreach (AudioClip startClip in startClips)
            {
            
            audioSrc.PlayOneShot(startClip);
            yield return new WaitForSeconds(startClip.length + 0.5f);
            
                }
                    if(Time.time == 180)
                {
                    
                audioSrc.PlayOneShot(timesUp);
                
               
                    new WaitForSeconds(timesUp.length + 0.5f);

            StartCoroutine(Timer());
        }

    }
}