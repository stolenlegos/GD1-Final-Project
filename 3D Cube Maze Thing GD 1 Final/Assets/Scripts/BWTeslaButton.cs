using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWTeslaButton : MonoBehaviour
{
  public GameObject[] BWButtons;
  public GameObject[] BlackLightnings;
  public GameObject[] WhiteLightnings;
  public bool BlackWhite; //true is black false is White
  public bool inputActive;
  public bool triggerActive;

    void Start()
    {
      BWButtons = GameObject.FindGameObjectsWithTag("TeslaButtonBW");
      BlackLightnings = GameObject.FindGameObjectsWithTag("TeslaBLACK");
      WhiteLightnings = GameObject.FindGameObjectsWithTag("TeslaWHITE");
      BlackWhite = true;
      foreach (GameObject BWButton in BWButtons)
      {
        BWButton.GetComponent<Renderer>().material.color = new Color (0,0,1);
      }
    }

    void Update()
    {
      ButtonActive();
      stopBlack();
      stopWhite();
    }

    void stopWhite()
    {
      if (BlackWhite)
      {
        foreach (GameObject WhiteLightning in WhiteLightnings)
        {
          WhiteLightning.SetActive(false);
        }
      } else {
        foreach (GameObject WhiteLightning in WhiteLightnings)
        {
          WhiteLightning.SetActive(true);
        }
      }
    }

    void stopBlack()
    {
      if (!BlackWhite)
      {
        foreach (GameObject BlackLightning in BlackLightnings)
        {
          BlackLightning.SetActive(false);
        }
      } else {
        foreach (GameObject BlackLightning in BlackLightnings)
        {
          BlackLightning.SetActive(true);
        }
      }
    }

    void ButtonActive()
    {
      if (Input.GetKeyDown(KeyCode.E) && BlackWhite && triggerActive)
      {
        foreach (GameObject BWButton in BWButtons)
        {
          BWButton.GetComponent<Renderer>().material.color = new Color (1,1,1);
        }
        BlackWhite = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !BlackWhite && triggerActive)
      {
        foreach (GameObject BWButton in BWButtons)
        {
          BWButton.GetComponent<Renderer>().material.color = new Color (0,0,0);
        }
        BlackWhite = true;
      }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.tag == "TeslaButtonBW")
      {
        triggerActive = true;
      }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.tag == "TeslaButtonBW")
      {
        triggerActive = false;
      }
    }
}
