using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmaDestroy : MonoBehaviour
{
  private float rpm = 2;

  void Update () {
    transform.Rotate(6*rpm*Time.deltaTime,6f*rpm*Time.deltaTime,6f*rpm*Time.deltaTime);
  }

    void OnTriggerEnter (Collider other) {
      if (other.tag == "Player") {
        Destroy(gameObject);
      }
    }
}
