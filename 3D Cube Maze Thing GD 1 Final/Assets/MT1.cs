using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MT1 : MonoBehaviour
{
  public Transform teleportTarget;
  public GameObject player;
  public GameObject mainCamera; 
  public bool test;

  void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("MT1")) 
      {
        test = true;
        player.transform.position = teleportTarget.transform.position;
        player.transform.rotation = teleportTarget.transform.rotation;
        mainCamera.transform.rotation = teleportTarget.transform.rotation;
      }
    }

    void OnTriggerExit (Collider other)
    {
      test = false;
    }

}
