using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationEdit : MonoBehaviour
{
  float playerRestriction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update ()
    {
      playerRestriction -= Time.deltaTime;
    }

    public void turnDown() { 
        StartCoroutine(Rotate(Vector3.right, -90, 1.0f));
        playerRestriction = 1.2f;
    }

    public void turnUp() { 
        StartCoroutine(Rotate(Vector3.right, 90, 1.0f));
        playerRestriction = 1.2f;
    }

    public void turnLeft() { 
        StartCoroutine(Rotate(Vector3.forward, 90, 1.0f));
        playerRestriction = 1.2f;
    }

    public void turnRight() { 
        StartCoroutine(Rotate(Vector3.forward, -90, 1.0f));
        playerRestriction = 1.2f;
    }

    public void dropPlayer() { 
        turnUp();
        GameObject player = GameObject.Find("player"); 
        Rigidbody rb = player.GetComponent<Rigidbody>(); 
        rb.useGravity = true; 
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

    IEnumerator RotateTwice(Vector3 axis1, Vector3 axis2, float angle, float duration = 1.0f)
    {
      Quaternion from = transform.rotation;
      Quaternion to = Quaternion.Euler(axis1 * angle) * transform.rotation;
      Quaternion final = Quaternion.Euler(axis2 * angle) * transform.rotation; 

      float elapsed = 0.0f;
      while(elapsed < duration)
      {
        transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
      }
      transform.rotation = to;

      elapsed = 0.0f; 
      while(elapsed < duration) {
        transform.rotation = Quaternion.Slerp(to, final, elapsed/duration); 
        elapsed += Time.deltaTime; 
        yield return null;
      }
      transform.rotation = final; 
    }
}