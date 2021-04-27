using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime; 
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "maze")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            //Destroy(col.gameObject);
            col.GetComponent<CharacterMove>().enabled = false;
            col.GetComponent<CharacterController>().enabled = false;
            col.GetComponent<SC_MovingPlatform>().enabled = false;
            //mainCamera.GetComponent<cameraMove>().enabled = false;
            //controlsUI.SetActive(false);
            col.transform.position = col.GetComponent<playerTriggerScripts>().spotCoordinates;
            col.GetComponent<CharacterMove>().enabled = true;
            col.GetComponent<CharacterController>().enabled = true;
            col.GetComponent<SC_MovingPlatform>().enabled = true;
        }

    }
}
