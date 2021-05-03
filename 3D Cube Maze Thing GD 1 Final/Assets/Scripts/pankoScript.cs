using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pankoScript : MonoBehaviour
{
  public GameObject pankoPrefab;
  public GameObject purpleMaze;
  private float timer = 2;
  private bool onPurple = false;

    void Update() {
      if (timer <= 0 && onPurple) {
        Quaternion pankoRotation = pankoPrefab.transform.rotation;
        GameObject panko = Instantiate(pankoPrefab, transform.position, pankoRotation);
        panko.transform.parent = purpleMaze.transform;
        timer = 2;
      }
      timer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
      if (other.tag == "onPurple") {
        onPurple = true;
      }
    }

    void OnTriggerExit(Collider other) {
      if (other.tag == "onPurple") {
        onPurple = false;
      }
    }
}
