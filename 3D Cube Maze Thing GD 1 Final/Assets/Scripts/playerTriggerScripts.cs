using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerScripts : MonoBehaviour
{
    
    GameObject portalRoomUI; 
    GameObject portalSpotUI;
    public bool prtActive; 
    public bool spotActive;
    public Transform teleportTarget; 
    public GameObject player; 

    void Start()
    {
        portalRoomUI = GameObject.Find("portalRoomUI");     
        portalSpotUI = GameObject.Find("portalSpotUI");
        if (!prtActive) { 
            portalRoomUI.SetActive(false);
        }
        if (!spotActive) { 
            portalSpotUI.SetActive(false); 
        } 
    }
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) { 
        if (other.CompareTag("portalRoomTrigger")) { 
            if (prtActive) {
                portalRoomUI.SetActive(false);
                prtActive = false; 
            } else {
                portalRoomUI.SetActive(true);
                prtActive = true;  
            }
        }
        if (other.CompareTag("portalSpot")) {
            spotActive = true;
            portalSpotUI.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other) { 
        if (other.CompareTag("portalSpot")) {
            spotActive = false; 
            portalSpotUI.SetActive(false); 
        }
    }

    public void portPlayer() { 
        player.transform.position = teleportTarget.transform.position;
        prtActive = true; 
        portalRoomUI.SetActive(true);
        Rigidbody rb = player.GetComponent<Rigidbody>(); 
        rb.useGravity = false; 
    }

}
