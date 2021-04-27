using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCone : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rightAng = Quaternion.AngleAxis(45.0f, transform.forward) * transform.forward;
        Debug.DrawRay(transform.position, rightAng, Color.cyan);

        Vector3 leftAng = Quaternion.AngleAxis(-45.0f, transform.forward) * transform.forward;
        Debug.DrawRay(transform.position, leftAng, Color.red);
    }
}
