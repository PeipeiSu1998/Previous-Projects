using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHarbourSounds : MonoBehaviour {

    public AudioSource seagulsSource;
    public AudioSource shipsSource;
    public AudioSource otherSource;

    public AudioClip[] sounds;

    // Use this for initialization
    void Start () {
        StartCoroutine("PlaySeagul");
        StartCoroutine("PlayShips");
        StartCoroutine("PlayOther");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator PlaySeagul()
    {
        while(true)
        {
            seagulsSource.clip = sounds[Random.Range(0, 2)];
            seagulsSource.Play();
            yield return new WaitForSeconds(Random.Range(20, 30));
        }
    }

    public IEnumerator PlayShips()
    {
        while (true)
        {
            shipsSource.clip = sounds[Random.Range(3, 6)];
            shipsSource.Play();
            yield return new WaitForSeconds(Random.Range(20, 30));
        }
    }

    public IEnumerator PlayOther()
    {
        while (true)
        {
            otherSource.clip = sounds[Random.Range(7, 8)];
            otherSource.Play();
            yield return new WaitForSeconds(Random.Range(20, 30));
        }
    }
}
