using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float rotateSpeed = 1.0F; // set in inspector to 10.0f
    bool pause = false;
    [HideInInspector] public bool freeze = false;

    //Quaternion startRotation; // starting rotation of camera
    //Quaternion lastRotation; // previous rotation of camera

    public float angleThreshold = 90.0f; // set in inspector
    float tempAngle;
    float tempAngle2;
    float tempAngle3;

    // Start is called before the first frame update
    void Start()
    {
        //startRotation = transform.rotation;
        //gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObject.transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.P))
        {
            pause = !pause;
        }

        if (freeze)
        {
            return;
        }

        // Rotate around x - axis

        tempAngle = gameObject.transform.eulerAngles.x;
        tempAngle2 = tempAngle + Input.GetAxis("Mouse Y") * rotateSpeed / 8 * -1;
        tempAngle3 = tempAngle + Input.GetAxis("FwdBack") * rotateSpeed / 10 * -1;

        //Debug.Log("tempAngle " + tempAngle + " tempAngle2 " + tempAngle2);

        if(tempAngle > 180 && tempAngle2 > 180 && tempAngle2 < tempAngle && tempAngle2 < 360.0f - angleThreshold) //  * (3.14157f / 180.0f))
        {
            return;
        }

        else if (tempAngle < 180 && tempAngle2 < 180 && tempAngle2 > tempAngle && tempAngle2 > angleThreshold) //  * (3.14157f / 180.0f))
        {
            return;
        }

        else if (tempAngle > 180 && tempAngle3 > 180 && tempAngle3 < tempAngle && tempAngle3 < 360.0f - angleThreshold) //  * (3.14157f / 180.0f))
        {
            return;
        }

        else if (tempAngle < 180 && tempAngle3 < 180 && tempAngle3 > tempAngle && tempAngle3 > angleThreshold) //  * (3.14157f / 180.0f))
        {
            return;
        }

        else
        {
            if(!pause)
            {
                gameObject.transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed / 8 * -1, 0, 0);
                gameObject.transform.Rotate(Input.GetAxis("FwdBack") * rotateSpeed / 10 * -1, 0, 0);
            }
        }

        //lastRotation = gameObject.transform.rotation;

    }


}
