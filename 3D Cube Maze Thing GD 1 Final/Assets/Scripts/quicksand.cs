using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quicksand : MonoBehaviour
{
    public GameObject yellow;
    public GameObject walls;
    public GameObject platform;
    //Transform yellowOrig;
    Vector3 yellowOrigVec;
    Vector3 platformOrig;
    int counter = 0;
    int counter2 = 0;
    Vector3 scaleChange;
    Vector3 scaleOrig;
    //float scaleSum = 0.0f;
    float speedOrig;
    float gravityOrig;
    [HideInInspector] public bool cancel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {

        if(cancel)
        {
            return;
        }

        if(col.gameObject.CompareTag("Player"))
        {
            if(counter == 0)
            {
                //gravityOrig = col.gameObject.GetComponent<CharacterMove>().gravityValue;
                //col.gameObject.GetComponent<CharacterMove>().gravityValue = -2.0f;
                //Debug.Log("Gravity " + col.gameObject.GetComponent<CharacterMove>().gravityValue);
                speedOrig = col.gameObject.GetComponent<CharacterMove>().speed;
                col.gameObject.GetComponent<CharacterMove>().speed *= 0.5f;
                //Debug.Log("Speed " + col.gameObject.GetComponent<CharacterMove>().speed);
                //yellowOrig = yellow.transform;
                yellowOrigVec = yellow.transform.position;
                scaleOrig = walls.transform.localScale;
                platformOrig = platform.transform.position;
            }
            else if(counter >= 120)
            {
                //col.gameObject.GetComponent<CharacterMove>().gravityValue += -2.0f;
                //Debug.Log("Gravity " + col.gameObject.GetComponent<CharacterMove>().gravityValue);
                col.gameObject.GetComponent<CharacterMove>().speed *= 0.5f;
                //Debug.Log("Speed " + col.gameObject.GetComponent<CharacterMove>().speed);
                counter = 0;
            }

            //Transform current = yellow.transform;
            yellow.transform.Translate(0, -0.1f, 0);
            platform.transform.Translate(0, +0.4f, 0);
            scaleChange = new Vector3(0.0f, 0.01f, 0.0f);
            //scaleSum += 0.01f;
            walls.transform.localScale += scaleChange;
            /*
            col.GetComponent<CharacterMove>().enabled = false;
            col.GetComponent<CharacterController>().enabled = false;
            col.GetComponent<SC_MovingPlatform>().enabled = false;
            //mainCamera.GetComponent<cameraMove>().enabled = false;
            //controlsUI.SetActive(false);
            col.transform.position = teleportTarget.transform.position;
            //player.transform.rotation = teleportTarget.transform.rotation;
            */

            counter++;
            counter2++;

            if (counter2 >= 200)
            {
                col.gameObject.GetComponent<CharacterMove>().enabled = false;
                col.gameObject.GetComponent<CharacterController>().enabled = false;
                col.gameObject.GetComponent<SC_MovingPlatform>().enabled = false;

                //yellow.transform.position = yellowOrig.position;
                yellow.transform.position = yellowOrigVec;
                platform.transform.position = platformOrig;
                walls.transform.localScale = scaleOrig;
                col.transform.position = col.gameObject.GetComponent<playerTriggerScripts>().spotCoordinates;

                col.gameObject.GetComponent<CharacterMove>().enabled = true;
                col.gameObject.GetComponent<CharacterController>().enabled = true;
                col.gameObject.GetComponent<SC_MovingPlatform>().enabled = true;

                //col.gameObject.GetComponent<CharacterMove>().gravityValue = gravityOrig;
                col.gameObject.GetComponent<CharacterMove>().speed = speedOrig;


                counter = 0;
                counter2 = 0;


            }
        }
    }
}
