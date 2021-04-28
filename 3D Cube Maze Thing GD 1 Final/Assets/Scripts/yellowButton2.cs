using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowButton2 : MonoBehaviour
{
    public bool BlueOrange; //true is blue false is orange
    public bool inputActive;
    public bool triggerActive;
    public GameObject quicksand;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;
    public GameObject cube6;
    public GameObject cube7;
    public GameObject cube8;
    public float spacing = 50.0f;
    Vector3 origPos;

    void Start()
    {
        BlueOrange = true;
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
        //origPos = cube2.transform.position;
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
            //Debug.Log("Button press TRUE");
            quicksand.GetComponent<quicksand>().cancel = true;
            //Vector3 origPos = cube2.transform.position;
            origPos = cube2.transform.position;
            cube2.transform.position = origPos + cube2.transform.forward * spacing;
            cube3.transform.position = origPos + cube2.transform.forward * 2.0f * spacing;
            cube4.transform.position = origPos + cube2.transform.forward * 3.0f * spacing;
            cube5.transform.position = origPos + cube2.transform.forward * -1.0f * spacing;
            cube6.transform.position = origPos + cube2.transform.forward * -2.0f * spacing;
            cube7.transform.position = origPos + cube2.transform.forward * -3.0f * spacing;
            cube8.transform.position = origPos + cube2.transform.forward * -4.0f * spacing;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !BlueOrange && triggerActive)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 1);
            BlueOrange = true;
            //Debug.Log("Button press FALSE");
            quicksand.GetComponent<quicksand>().cancel = false;
            cube2.transform.position = origPos;
            cube3.transform.position = origPos;
            cube4.transform.position = origPos;
            cube5.transform.position = origPos;
            cube6.transform.position = origPos;
            cube7.transform.position = origPos;
            cube8.transform.position = origPos;
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

