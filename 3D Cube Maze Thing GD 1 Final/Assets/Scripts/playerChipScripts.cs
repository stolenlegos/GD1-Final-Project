using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChipScripts : MonoBehaviour
{
  public GameObject cubeWorld;
  public int pCPurp = 0;
  public int pCGreen = 0;
  public int pCBlue = 0;
  public int pCRed = 0;
  public int pCYellow = 0;
  private levelChipScripts chips;
    // Start is called before the first frame update
    void Start() {
      chips = cubeWorld.GetComponent<levelChipScripts>();
    }

    // Update is called once per frame
    void Update() {
      if (pCPurp >= 4) {
        chips.purpleWon = true;
      }

      if (pCGreen >= 3) {
        chips.greenWon = true;
      }

      if (pCBlue >= 3) {
        chips.blueWon = true;
      }

      if (pCRed >= 3) {
        chips.redWon = true;
      }

      if (pCYellow >= 3) {
        chips.yellowWon = true;
      }
      if (pCRed >= 2) {
        Destroy(GameObject.Find("level3Entrance"));
      }
    }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "purplePine") {
        pCPurp += 1;
      }

      if (other.tag == "greenPine") {
        pCGreen += 1;
      }

      if (other.tag == "bluePine") {
        pCBlue += 1;
      }

      if (other.tag == "redPine") {
        pCRed += 1;
      }

      if (other.tag == "yellowPine") {
        pCYellow += 1;
      }
    }
}
