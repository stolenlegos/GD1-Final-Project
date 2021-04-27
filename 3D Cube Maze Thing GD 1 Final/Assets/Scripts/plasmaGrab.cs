using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmaGrab : MonoBehaviour
{
  public int plasma;
  public GameObject blockOne;
  public GameObject blockTwo;
  public GameObject blockThree;
  public GameObject blockFour;
  bool blockOneExist = true;
  bool blockTwoExist = true;
  bool blockThreeExist = true;
  bool blockFourExist = true;

    void Update() {
      if (plasma >= 2 && blockOneExist) {
        Destroy(blockOne);
        plasma -= 2;
        blockOneExist = false;
      }

      if (plasma >= 4 && blockTwoExist) {
        Destroy(blockTwo);
        plasma -= 4;
        blockTwoExist = false;
      }

      if (plasma >= 8 && blockThreeExist) {
        Destroy(blockThree);
        plasma -= 8;
        blockThreeExist = false;
      }

      if (plasma >= 15 && blockFourExist){
        Destroy(blockFour);
        plasma -= 15;
        blockFourExist = false;
      }
    }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "plasma") {
        plasma += 1;
      }
    }
}
