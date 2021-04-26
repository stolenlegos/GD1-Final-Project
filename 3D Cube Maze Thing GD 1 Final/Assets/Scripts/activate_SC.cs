using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_SC : MonoBehaviour
{
    
    public GameObject player;
    
    public void OnTriggerEnter(Collider other) { 
        print("collision");
        if (other.CompareTag("teleportSpot")) { 
            if(!player.GetComponent<SC_MovingPlatform>().enabled)
                player.GetComponent<SC_MovingPlatform>().enabled = true;
        }
    }
}
