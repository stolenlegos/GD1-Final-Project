using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowButton : MonoBehaviour
{
    public bool BlueOrange; //true is blue false is orange
    public bool inputActive;
    public bool triggerActive;
    public GameObject dustStorm;
    Vector3 origPos;

    void Start()
    {
        BlueOrange = true;
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
        //origPos = dustStorm.transform.position;
    }

    void Update()
    {
        ButtonActive();
    }

    void ButtonActive()
    {
        if (Input.GetKeyDown(KeyCode.E) && BlueOrange && triggerActive)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
            BlueOrange = false;
            origPos = dustStorm.transform.position;
            dustStorm.transform.position = origPos + dustStorm.transform.up * 5.0f;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !BlueOrange && triggerActive)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
            BlueOrange = true;
            dustStorm.transform.position = origPos;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerActive = false;
        }
    }
}
