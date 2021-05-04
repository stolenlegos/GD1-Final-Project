using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{

 
     public Transform pointA, pointB;
     float speed;
     float num;
     bool reverse;
     public int maxNum;
     public float speedMultiplier;    
 
     void Start() { 
        if (speedMultiplier == 0)
            speedMultiplier = 1;
        reverse = false;
        num = 0;  
     }
     
     void FixedUpdate () {
        if (num>maxNum || num<0) { 
            if (reverse) 
                reverse = false;
            else 
                reverse = true;   
        }
        speed = speedMultiplier*num*Time.deltaTime/2;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, speed);
        if (!reverse) {
            num++; 
        } else num--; 
    }
}
