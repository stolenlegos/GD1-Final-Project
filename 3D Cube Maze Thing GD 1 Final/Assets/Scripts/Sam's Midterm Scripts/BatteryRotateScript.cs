using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 45.0f * Time.deltaTime, Space.Self);
    }
}
