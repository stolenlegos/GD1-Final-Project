using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float rotateSpeed = 1.0F;
    bool pause = false;
    [HideInInspector] public bool freeze = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.P))
        {
            pause = !pause;
        }

        if (pause)
        {
            return;
        }

        if (freeze)
        {
            return;
        }

        // Rotate around x - axis
        gameObject.transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed * -1, 0, 0);
        gameObject.transform.Rotate(Input.GetAxis("FwdBack") * rotateSpeed/10 * -1, 0, 0);

    }
}
