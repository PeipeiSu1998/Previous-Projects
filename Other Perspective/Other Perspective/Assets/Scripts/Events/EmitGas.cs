using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmitGas : MonoBehaviour {

    public ParticleSystem gas;
    public static UnityEvent emitGas;
    public AudioSource audioSrc;
    public AudioClip gasSound;

	// Use this for initialization
	void Start () {
		if(emitGas == null)
        {
            emitGas = new UnityEvent();
        }
        emitGas.AddListener(GasEmission);
        emitGas.AddListener(GasEmissionSound);
        
	}
	
	void GasEmission()
    {
        print("gas emitted");
        gas.Play();
    }

    void GasEmissionSound()
    {
        audioSrc.PlayOneShot(gasSound);
    }
}
