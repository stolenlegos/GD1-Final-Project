using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalRoomTriggerScript : MonoBehaviour
{
    GameObject prt; 
    public bool prtActive; 
    // Start is called before the first frame update
    void Start()
    {
        prt = GameObject.Find("portalRoomTrigger"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (prtActive == true) {
            prt.SetActive(false); 
            prtActive = false; 
        }
        else {
            prt.SetActive(true);
            prtActive = true;  
        }
    }
}
