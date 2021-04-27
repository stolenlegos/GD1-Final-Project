using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineappleDestroy : MonoBehaviour
{
  private float rpm = 3;
  public GameObject pinePrefab;

  void Update () {
    transform.Rotate(9f*rpm*Time.deltaTime,6f*rpm*Time.deltaTime,3f*rpm*Time.deltaTime);
  }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "Player") {
        Destroy(pinePrefab);
      }
    }
}
