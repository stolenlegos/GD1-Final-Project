using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationEdit : MonoBehaviour
{
  bool allowButton; 
  float playerRestriction;
    // Start is called before the first frame update
    void Start()
    {
      allowButton = true; 
    }

    // Update is called once per frame
    void Update ()
    {
      playerRestriction -= Time.deltaTime;
    }

    public void turnDown() { 
      if (allowButton) {
        StartCoroutine(Rotate(Vector3.right, -90, 1.0f));
        playerRestriction = 1.2f;
        }
    }

    public void turnUp() {
      if (allowButton) { 
        StartCoroutine(Rotate(Vector3.right, 90, 1.0f));
        playerRestriction = 1.2f;
      }
    }

    public void turnLeft() {
      if (allowButton) { 
        StartCoroutine(Rotate(Vector3.up, 90, 1.0f)); // forward
        playerRestriction = 1.2f;
      }
    }

    public void turnRight() {
      if (allowButton) { 
        StartCoroutine(Rotate(Vector3.up, -90, 1.0f)); // forward
        playerRestriction = 1.2f;
      }
    }

    public void dropPlayer() {
      if (allowButton) { 
        turnUp();
        GameObject player = GameObject.Find("player"); 
        Rigidbody rb = player.GetComponent<Rigidbody>(); 
        rb.useGravity = true; 
      }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
      allowButton = false; 
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
      allowButton = true; 
    }
}