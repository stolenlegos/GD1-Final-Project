using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerScripts : MonoBehaviour
{

    GameObject portalRoomUI;
    GameObject portalSpotUI;
    GameObject controlsUI;
    public bool prtActive;
    public bool spotActive;
    public Transform teleportTarget; 
    public Transform lavaTarget;
    public GameObject player; 
    public GameObject mainCamera;
    public GameObject cubeWorld;

    void Start()
    {
        portalRoomUI = GameObject.Find("portalRoomUI");
        portalSpotUI = GameObject.Find("portalSpotUI");
        controlsUI = GameObject.Find("controlsUI");
        if (!prtActive) {
            portalRoomUI.SetActive(false);
        }
        if (!spotActive) {
            portalSpotUI.SetActive(false);
        }
    }
    void Update()
    {
        if (spotActive) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                portPlayer();
            }
        }

        if(prtActive) {
            if (Input.GetKeyDown(KeyCode.W)) {
                cubeWorld.GetComponent<CubeRotationEdit>().turnUp();
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                cubeWorld.GetComponent<CubeRotationEdit>().turnLeft();
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                cubeWorld.GetComponent<CubeRotationEdit>().turnDown();
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                cubeWorld.GetComponent<CubeRotationEdit>().turnRight();
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                cubeWorld.GetComponent<CubeRotationEdit>().dropPlayer();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("portalRoomTrigger")) {
            if (prtActive) {
                portalRoomUI.SetActive(false);
                prtActive = false;
                controlsUI.SetActive(true);
            } else {
                portalRoomUI.SetActive(true);
                prtActive = true;
                controlsUI.SetActive(false);
            }
        }
        if (other.CompareTag("portalSpot")) {
            spotActive = true;
            portalSpotUI.SetActive(true);
        }
        //if (other.name == "planeBarrier") {
        //    lavaPort();
        //}
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("portalSpot")) {
            spotActive = false;
            portalSpotUI.SetActive(false);
        }
    }

    public void portPlayer() {
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<SC_MovingPlatform>().enabled = false;
        mainCamera.GetComponent<cameraMove>().enabled = false;
        controlsUI.SetActive(false);
        player.transform.position = teleportTarget.transform.position;
        player.transform.rotation = teleportTarget.transform.rotation;
        mainCamera.transform.rotation = teleportTarget.transform.rotation;
        prtActive = true;
        portalRoomUI.SetActive(true);
    }

    /*public void lavaPort() {  
        player.GetComponent<CharacterMove>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false; 
        mainCamera.GetComponent<cameraMove>().enabled = false;
        player.transform.position = lavaTarget.transform.position;
        player.transform.rotation = lavaTarget.transform.rotation; 
        mainCamera.transform.rotation = lavaTarget.transform.rotation; 
        player.GetComponent<CharacterMove>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true; 
        mainCamera.GetComponent<cameraMove>().enabled = true;
    }*/


}
