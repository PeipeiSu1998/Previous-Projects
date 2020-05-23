using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSphere : MonoBehaviour {

    private Renderer rend;
    private bool startedRight = false;
    private void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        rend.material.SetColor("_Color", Color.green);
        KeyCollide.firstCollide = true;
    }
}
