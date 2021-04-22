using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime; 
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "maze")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
