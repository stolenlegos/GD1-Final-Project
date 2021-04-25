using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaToSpotTeleport : MonoBehaviour
{
    // Start is called before the first frame update 
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
        if (other.CompareTag("teleportSpot"))
            teleporterActive = false; 
    }

    public void lavaPort() {  
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false; 
        mainCamera.GetComponent<cameraMove>().enabled = false;
        player.transform.position = lavaTarget.transform.position;
        player.transform.rotation = lavaTarget.transform.rotation; 
        mainCamera.transform.rotation = lavaTarget.transform.rotation; 
        player.GetComponent<CharacterMove>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true; 
        mainCamera.GetComponent<cameraMove>().enabled = true;
    }
}
