using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaButtons : MonoBehaviour
{
  public GameObject[] RGButtons;
  public GameObject[] GreenLightnings;
  public GameObject[] RedLightnings;
  public GameObject[] BOButtons;
  public GameObject[] BlueLightnings;
  public GameObject[] OrangeLightnings;
  public GameObject[] BWButtons;
  public GameObject[] BlackLightnings;
  public GameObject[] WhiteLightnings;
  public GameObject finalButton;
  public GameObject[] finalLightnings;
  public bool BlackWhite; //true is black false is White
  public bool BlueOrange; //true is blue false is orange
  public bool GreenRed; //true is red false is green
  public bool final; //true is on false is off
  public bool RGTriggerActive;
  public bool BOTriggerActive;
  public bool BWTriggerActive;
  public bool finalTriggerActive;

    void Start()
    {
      RGButtons = GameObject.FindGameObjectsWithTag("TeslaButtonRG");
      GreenLightnings = GameObject.FindGameObjectsWithTag("TeslaGREEN");
      RedLightnings = GameObject.FindGameObjectsWithTag("TeslaRED");
      GreenRed = true;
      foreach (GameObject RGButton in RGButtons) {
        RGButton.GetComponent<Renderer>().material.color = Color.red;
      }

      BOButtons = GameObject.FindGameObjectsWithTag("TeslaButtonBO");
      BlueLightnings = GameObject.FindGameObjectsWithTag("TeslaBLUE");
      OrangeLightnings = GameObject.FindGameObjectsWithTag("TeslaORANGE");
      BlueOrange = true;
      foreach (GameObject BOButton in BOButtons) {
        BOButton.GetComponent<Renderer>().material.color = Color.blue;
      }

      BWButtons = GameObject.FindGameObjectsWithTag("TeslaButtonBW");
      BlackLightnings = GameObject.FindGameObjectsWithTag("TeslaBLACK");
      WhiteLightnings = GameObject.FindGameObjectsWithTag("TeslaWHITE");
      BlackWhite = true;
      foreach (GameObject BWButton in BWButtons) {
        BWButton.GetComponent<Renderer>().material.color = Color.black;
      }

      finalLightnings = GameObject.FindGameObjectsWithTag("TeslaFINAL");
      final = true;
      finalButton.GetComponent<Renderer>().material.color = Color.black;
    }

    void Update() {
      ButtonActive();
      stopGreen();
      stopRed();
      stopBlue();
      stopOrange();
      stopBlack();
      stopWhite();
      stopFinal();
    }

    void stopRed() {
      if (!GreenRed) {
        foreach (GameObject RedLightning in RedLightnings) {
          RedLightning.SetActive(false);
        }
      } else {
        foreach (GameObject RedLightning in RedLightnings) {
          RedLightning.SetActive(true);
        }
      }
    }

    void stopGreen() {
      if (GreenRed) {
        foreach (GameObject GreenLightning in GreenLightnings) {
          GreenLightning.SetActive(false);
        }
      } else {
        foreach (GameObject GreenLightning in GreenLightnings) {
          GreenLightning.SetActive(true);
        }
      }
    }

    void stopOrange() {
      if (BlueOrange) {
        foreach (GameObject OrangeLightning in OrangeLightnings) {
          OrangeLightning.SetActive(false);
        }
      } else {
        foreach (GameObject OrangeLightning in OrangeLightnings) {
          OrangeLightning.SetActive(true);
        }
      }
    }

    void stopBlue() {
      if (!BlueOrange) {
        foreach (GameObject BlueLightning in BlueLightnings) {
          BlueLightning.SetActive(false);
        }
      } else {
        foreach (GameObject BlueLightning in BlueLightnings) {
          BlueLightning.SetActive(true);
        }
      }
    }

    void stopWhite() {
      if (BlackWhite) {
        foreach (GameObject WhiteLightning in WhiteLightnings) {
          WhiteLightning.SetActive(false);
        }
      } else {
        foreach (GameObject WhiteLightning in WhiteLightnings) {
          WhiteLightning.SetActive(true);
        }
      }
    }

    void stopBlack() {
      if (!BlackWhite) {
        foreach (GameObject BlackLightning in BlackLightnings) {
          BlackLightning.SetActive(false);
        }
      } else {
        foreach (GameObject BlackLightning in BlackLightnings) {
          BlackLightning.SetActive(true);
        }
      }
    }

    void stopFinal() {
      if (!final) {
        foreach (GameObject finalLightning in finalLightnings) {
          finalLightning.SetActive(false);
        }
      } else {
        foreach (GameObject finalLightning in finalLightnings) {
          finalLightning.SetActive(true);
        }
      }
    }

    void ButtonActive() {
      if (Input.GetKeyDown(KeyCode.E) && GreenRed && RGTriggerActive) {
        foreach (GameObject RGButton in RGButtons) {
          RGButton.GetComponent<Renderer>().material.color = Color.green;
        }
        GreenRed = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !GreenRed && RGTriggerActive) {
        foreach (GameObject RGButton in RGButtons) {
          RGButton.GetComponent<Renderer>().material.color = Color.red;
        }
        GreenRed = true;
      }

      if (Input.GetKeyDown(KeyCode.E) && BlueOrange && BOTriggerActive) {
        foreach (GameObject BOButton in BOButtons) {
          BOButton.GetComponent<Renderer>().material.color = new Color (0.93f,0.62f,0f);
        }
        BlueOrange = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !BlueOrange && BOTriggerActive) {
        foreach (GameObject BOButton in BOButtons) {
          BOButton.GetComponent<Renderer>().material.color = Color.blue;
        }
        BlueOrange = true;
      }

      if (Input.GetKeyDown(KeyCode.E) && BlackWhite && BWTriggerActive) {
        foreach (GameObject BWButton in BWButtons) {
          BWButton.GetComponent<Renderer>().material.color = Color.white;
        }
        BlackWhite = false;
      }
      else if (Input.GetKeyDown(KeyCode.E) && !BlackWhite && BWTriggerActive) {
        foreach (GameObject BWButton in BWButtons) {
          BWButton.GetComponent<Renderer>().material.color = Color.black;
        }
        BlackWhite = true;
      }

      if (Input.GetKeyDown(KeyCode.E) && final && finalTriggerActive) {
        finalButton.GetComponent<Renderer>().material.color = Color.white;
        final = false;
      } else if (Input.GetKeyDown(KeyCode.E) && !final && finalTriggerActive) {
        finalButton.GetComponent<Renderer>().material.color = Color.black;
        final = true;
      }
    }

    void OnTriggerEnter(Collider other) {
      if (other.tag == "TeslaButtonRG") {
        RGTriggerActive = true;
      }

      if (other.tag == "TeslaButtonBO") {
        BOTriggerActive = true;
      }

      if (other.tag == "TeslaButtonBW") {
        BWTriggerActive = true;
      }

      if (other.tag == "TeslaFinalButton") {
        finalTriggerActive = true;
      }
    }

    void OnTriggerExit(Collider other) {
      if (other.tag == "TeslaButtonRG") {
        RGTriggerActive = false;
      }

      if (other.tag == "TeslaButtonBO") {
        BOTriggerActive = false;
      }

      if (other.tag == "TeslaButtonBW") {
        BWTriggerActive = false;
      }

      if (other.tag == "TeslaFinalButton") {
        finalTriggerActive = false;
      }
    }
}
