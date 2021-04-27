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

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("maze"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            //Destroy(col.gameObject);
            col.gameObject.GetComponent<CharacterMove>().enabled = false;
            col.gameObject.GetComponent<CharacterController>().enabled = false;
            col.gameObject.GetComponent<SC_MovingPlatform>().enabled = false;
            //mainCamera.GetComponent<cameraMove>().enabled = false;
            //controlsUI.SetActive(false);
            col.transform.position = col.gameObject.GetComponent<playerTriggerScripts>().spotCoordinates;
            col.gameObject.GetComponent<CharacterMove>().enabled = true;
            col.gameObject.GetComponent<CharacterController>().enabled = true;
            col.gameObject.GetComponent<SC_MovingPlatform>().enabled = true;
        }

    }
}
