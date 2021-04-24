using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTeslaButton : MonoBehaviour
{
  public GameObject[] BOButtons;
  public GameObject[] BlueLightnings;
  public GameObject[] OrangeLightnings;
  public bool BlueOrange; //true is blue false is orange
  public bool inputActive;
  public bool triggerActive;

    void Start()
    {
      BOButtons = GameObject.FindGameObjectsWithTag("TeslaButtonBO");
      BlueLightnings = GameObject.FindGameObjectsWithTag("TeslaBLUE");
      OrangeLightnings = GameObject.FindGameObjectsWithTag("TeslaORANGE");
      BlueOrange = true;
      foreach (GameObject BOButton in BOButtons)
      {
        BOButton.GetComponent<Renderer>().material.color = new Color (0.4f,0.44f,1f);
      }
    }

    void Update()
    {
      ButtonActive();
      stopBlue();
      stopOrange();
    }

    void stopOrange()
    {
      if (BlueOrange)
      {
        foreach (GameObject OrangeLightning in OrangeLightnings)
        {
          OrangeLightning.SetActive(false);
        }
      } else {
        foreach (GameObject OrangeLightning in OrangeLightnings)
        {
          OrangeLightning.SetActive(true);
        }
      }
    }

    void stopBlue()
    {
      if (!BlueOrange)
      {
        foreach (GameObject BlueLightning in BlueLightnings)
        {
          BlueLightning.SetActive(false);
        }
      } else {
        foreach (GameObject BlueLightning in BlueLightnings)
        {
          BlueLightning.SetActive(true);
        }
      }
    }

    void ButtonActive()
    {
      if (Input.GetKeyDown(KeyCode.E) && BlueOrange && triggerActive)
      {
        foreach (GameObject BOButton in BOButtons)
        {
          BOButton.GetComponent<Renderer>().material.color = new Color (0.94f,0.64f,0.18f);
        }
        BlueOrange = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !BlueOrange && triggerActive)
      {
        foreach (GameObject BOButton in BOButtons)
        {
          BOButton.GetComponent<Renderer>().material.color = new Color (0.4f,0.44f,1f);
        }
        BlueOrange = true;
      }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.tag == "TeslaButtonBO")
      {
        triggerActive = true;
      }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.tag == "TeslaButtonBO")
      {
        triggerActive = false;
      }
    }
}
