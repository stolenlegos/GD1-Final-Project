using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmaGrab : MonoBehaviour
{
  public int plasma;
  public GameObject blockOne;
  public GameObject blockTwo;
  public GameObject blockThree;
  bool blockOneExist = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
      if (plasma >= 2 && blockOneExist) {
        Destroy(blockOne);
        plasma -= 2;
        blockOneExist = false;
      }
    }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "plasma") {
        plasma += 1;
      }
    }
}
