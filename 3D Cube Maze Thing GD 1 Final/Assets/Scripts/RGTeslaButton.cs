using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGTeslaButton : MonoBehaviour
{
  public GameObject[] RGButtons;
  public bool GreenRed; //true is red false is green
  public bool inputActive;
  public bool triggerActive;

    void Start()
    {
      RGButtons = GameObject.FindGameObjectsWithTag("TeslaButtonRG");
      GreenRed = true;
      foreach (GameObject RGButton in RGButtons)
      {
        RGButton.GetComponent<Renderer>().material.color = new Color (255,0,0);
      }
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.E) && GreenRed && triggerActive)
      {
        foreach (GameObject RGButton in RGButtons)
        {
          RGButton.GetComponent<Renderer>().material.color = new Color (0,255,0);
        }
        GreenRed = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !GreenRed && triggerActive)
      {
        foreach (GameObject RGButton in RGButtons)
        {
          RGButton.GetComponent<Renderer>().material.color = new Color (255,0,0);
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
