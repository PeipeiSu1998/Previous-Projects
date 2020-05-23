using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipShades : MonoBehaviour
{

    private ColorBlindHandler Handler;
    [SerializeField]
    private int ShaderIndex;
    private GameObject glassesCopy;
    public Transform originalPosition;
    public BadVisionControl badVisionControl;



    // Use this for initialization
    void Start()
    {
        Handler = GameObject.Find("GlassesTable").GetComponent<ColorBlindHandler>();
        glassesCopy = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //originalPosition.position =


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "VRCamera")
        {

            Handler.ChangeSpectrum(ShaderIndex);
            badVisionControl.ChangeProfile(ShaderIndex);
            Instantiate(glassesCopy, originalPosition);
            Destroy(gameObject);

        }

    }



}