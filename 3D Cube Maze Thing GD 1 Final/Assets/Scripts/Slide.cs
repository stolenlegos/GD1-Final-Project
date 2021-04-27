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
 
     void Start() { 
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
        speed = num*Time.deltaTime/2;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, speed);
        if (!reverse) {
            num++; 
        } else num--; 

    }
}
