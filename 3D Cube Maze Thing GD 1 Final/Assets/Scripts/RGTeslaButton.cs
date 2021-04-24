using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGTeslaButton : MonoBehaviour
{
  public GameObject[] RGButtons;
  public GameObject[] GreenLightnings;
  public GameObject[] RedLightnings;
  public bool GreenRed; //true is red false is green
  public bool inputActive;
  public bool triggerActive;

    void Start()
    {
      RGButtons = GameObject.FindGameObjectsWithTag("TeslaButtonRG");
      GreenLightnings = GameObject.FindGameObjectsWithTag("TeslaGREEN");
      RedLightnings = GameObject.FindGameObjectsWithTag("TeslaRED");
      GreenRed = true;
      foreach (GameObject RGButton in RGButtons)
      {
        RGButton.GetComponent<Renderer>().material.color = new Color (0.86f,0.33f,0.24f);
      }
    }

    void Update()
    {
      ButtonActive();
      stopGreen();
      stopRed();
    }

    void stopRed()
    {
      if (!GreenRed)
      {
        foreach (GameObject RedLightning in RedLightnings)
        {
          RedLightning.SetActive(false);
        }
      } else {
        foreach (GameObject RedLightning in RedLightnings)
        {
          RedLightning.SetActive(true);
        }
      }
    }

    void stopGreen()
    {
      if (GreenRed)
      {
        foreach (GameObject GreenLightning in GreenLightnings)
        {
          GreenLightning.SetActive(false);
        }
      } else {
        foreach (GameObject GreenLightning in GreenLightnings)
        {
          GreenLightning.SetActive(true);
        }
      }
    }

    void ButtonActive()
    {
      if (Input.GetKeyDown(KeyCode.E) && GreenRed && triggerActive)
      {
        foreach (GameObject RGButton in RGButtons)
        {
          RGButton.GetComponent<Renderer>().material.color = new Color (0.05f,0.59f,0.06f);
        }
        GreenRed = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !GreenRed && triggerActive)
      {
        foreach (GameObject RGButton in RGButtons)
        {
          RGButton.GetComponent<Renderer>().material.color = new Color (0.86f,0.33f,0.24f);
        }
        GreenRed = true;
      }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.tag == "TeslaButtonRG")
      {
        triggerActive = true;
      }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.tag == "TeslaButtonRG")
      {
        triggerActive = false;
      }
    }
}
