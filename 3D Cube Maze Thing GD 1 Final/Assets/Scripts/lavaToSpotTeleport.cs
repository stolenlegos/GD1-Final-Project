using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathRespawn : MonoBehaviour
{
    public Transform respawnTarget;
    public GameObject player;
    public GameObject mainCamera; 
    private bool teleporterActive;   

    
    void Update() {
        if (teleporterActive) { 
            Respawn(); 
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

    public void Respawn() {  
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false; 
        mainCamera.GetComponent<cameraMove>().enabled = false;
        player.transform.position = respawnTarget.transform.position;
        player.transform.rotation = respawnTarget.transform.rotation; 
        mainCamera.transform.rotation = respawnTarget.transform.rotation; 
        player.GetComponent<CharacterMove>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true; 
        mainCamera.GetComponent<cameraMove>().enabled = true;
    }
}
