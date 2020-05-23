using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartRoomEvent : MonoBehaviour
{

  
    public List<GameObject> stuffToSpawn;
    public List<GameObject> stuffDespawn;
    public static UnityEvent startEscape;
    public GameObject MainRoomGladosControls;
    
    // Use this for initialization
    void Start()
    {
        
        if(startEscape == null)
        {
            startEscape = new UnityEvent();
        }
        startEscape.AddListener(DespawnThings);

        startEscape.AddListener(SpawnThings);

    }

    void SpawnThings()
    {
           
       
            foreach (GameObject roomThing in stuffToSpawn)
            {

            roomThing.SetActive(true);
            //stuffToSpawn[i].SetActive(true);
        }
        StartCoroutine(EnableGladosMainRoom());
       
    }

    void DespawnThings()
    {
        foreach (GameObject roomThing in stuffDespawn)
        {
            roomThing.SetActive(false);
            
        }
    }

    public IEnumerator EnableGladosMainRoom()
    {
        yield return new WaitForSeconds(7f);
        MainRoomGladosControls.SetActive(true);
    }
}

