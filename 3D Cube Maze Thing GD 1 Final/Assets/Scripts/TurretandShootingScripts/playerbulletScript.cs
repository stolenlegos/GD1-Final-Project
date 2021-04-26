using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbulletScript : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Breakable")
        {
            Destroy(gameObject);
        }

    }
}
