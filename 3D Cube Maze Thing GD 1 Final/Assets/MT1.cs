using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MT1 : MonoBehaviour
{
  public Transform teleportTarget;
  public GameObject player;
  public bool test;

  void OnTriggerEnter(Collider other)
    {
      if (other.tag == "MT1")
      {
        test = true;
        player.transform.position = teleportTarget.transform.position;
      }
    }

    void OnTriggerExit (Collider other)
    {
      test = false;
    }

}
