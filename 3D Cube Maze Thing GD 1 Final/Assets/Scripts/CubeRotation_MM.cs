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
      if(Input.GetKeyDown(KeyCode.LeftArrow) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.forward, 90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.RightArrow) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.forward, -90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.UpArrow) && playerRestriction <= 0)
      {
        StartCoroutine(Rotate(Vector3.right, 90, 1.0f));
        playerRestriction = 1.2f;
      }

      if(Input.GetKeyDown(KeyCode.DownArrow) && playerRestriction <= 0)
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

      float elapsed = 0.0f;
      while(elapsed < duration)
      {
        transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
      }
      transform.rotation = to;
    }
}
