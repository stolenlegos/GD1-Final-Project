using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotToSpotTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destination;
    public GameObject player;
    public GameObject mainCamera;
    private bool teleporterActive;


    void Update() {
        if (teleporterActive) {
            if (Input.GetKeyDown(KeyCode.E)) {
                teleport();
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        print("collision detected");
        if (other.CompareTag("teleportSpot")) { 
            teleporterActive = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("teleportSpot"))
            teleporterActive = false;
    }

    public void teleport() {
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<SC_MovingPlatform>().enabled = false; 
        mainCamera.GetComponent<cameraMove>().enabled = false;
        player.transform.position = destination.transform.position;
        player.transform.rotation = destination.transform.rotation;
        mainCamera.transform.rotation = destination.transform.rotation;
        player.GetComponent<CharacterMove>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<SC_MovingPlatform>().enabled = true; 
        mainCamera.GetComponent<cameraMove>().enabled = true;
    }
}
