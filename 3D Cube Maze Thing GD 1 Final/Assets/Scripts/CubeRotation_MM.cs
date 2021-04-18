using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation_MM : MonoBehaviour
{
  float playerRestriction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update ()
    {
      if(Input.GetKeyDown(KeyCode.A) && playerRestriction <= 0) // switched to WASD to deconflict with player moves
      {
        StartCoroutine(Rotate(Vector3.forward, 90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.D) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.forward, -90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.W) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.right, 90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.S) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.right, -90, 1.0f));
        playerRestriction = 1.2f;
      }

      playerRestriction -= Time.deltaTime;
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
      Quaternion from = transform.rotation;
      Quaternion to = Quaternion.Euler(axis * angle) * transform.rotation;

      GameObject[] GOs = GameObject.FindGameObjectsWithTag("player");
      for (int i = 0; i < GOs.Length; i++)
      {
        GOs[i].GetComponent<CharacterMove>().freeze = true;
      }

        float elapsed = 0.0f;
      while(elapsed < duration)
      {
        transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
      }
      transform.rotation = to;

      for (int i = 0; i < GOs.Length; i++)
      {
        GOs[i].GetComponent<CharacterMove>().freeze = false;
      }
    }
}
