using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitWorld : MonoBehaviour
{
  
    
    public float rpm = 3;
    public bool x; 
    // Start is called before the first frame update
    void Update () {
        if (x) 
            transform.Rotate(rpm*Time.deltaTime,0,0);
        else 
            transform.Rotate(0,0,rpm*Time.deltaTime);
    }
}
