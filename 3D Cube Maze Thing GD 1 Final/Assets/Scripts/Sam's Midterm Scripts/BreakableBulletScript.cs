using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBulletScript : MonoBehaviour
{
    public float speed = 0.5f;

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

        if (col.gameObject.tag == "BreakableWall")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag != "BreakableWall")
        {
            Destroy(gameObject);
        }

    }
}
