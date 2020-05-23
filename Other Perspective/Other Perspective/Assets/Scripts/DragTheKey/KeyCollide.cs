using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollide : MonoBehaviour {

    public GameObject sphere;
    public delegate void Collided();
    public static Collided collided;
    public static bool firstCollide;
    private Renderer rend;

    private void Start()
    {
        firstCollide = true;
        rend = sphere.GetComponent<Renderer>();
        
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);
        
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (firstCollide)
    //    {
    //        firstCollide = false;
    //        rend.material.SetColor("_Color", Color.red);
    //        collided();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (firstCollide)
        {
            firstCollide = false;
            rend.material.SetColor("_Color", Color.red);
            collided();
        }
    }
}
