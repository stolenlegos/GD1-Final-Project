using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pankoDestroy : MonoBehaviour
{
  private float timer = 120;

    void Update()
    {
        transform.Rotate(0,0,14f*Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) {
          Destroy(gameObject);
        }
    }
}
