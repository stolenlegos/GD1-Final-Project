using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaToSpotTeleport : MonoBehaviour
{
    public Transform lavaTarget;
    public GameObject player;
    public GameObject mainCamera; 
    private bool teleporterActive;   

    
    void Update() {
        if (teleporterActive) { 
            lavaPort(); 
        }
    }
    
    public void OnTriggerEnter(Collider other) { 
        if (other.CompareTag("teleportSpot")) { 
            teleporterActive = true; 
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("teleportSpot")) {
            teleporterActive = false; 
            if(!player.GetComponent<SC_MovingPlatform>().enabled)
                player.GetComponent<SC_MovingPlatform>().enabled = true;
        }
    }

    public void lavaPort() {  
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<SC_MovingPlatform>().enabled = false;  
        mainCamera.GetComponent<cameraMove>().enabled = false;
        player.transform.position = lavaTarget.transform.position;
        player.transform.rotation = lavaTarget.transform.rotation; 
        mainCamera.transform.rotation = lavaTarget.transform.rotation; 
        player.GetComponent<CharacterMove>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<SC_MovingPlatform>().enabled = true;  
        mainCamera.GetComponent<cameraMove>().enabled = true;
    }
}
