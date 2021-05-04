using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideOnce : MonoBehaviour
{
    public Transform pointA, pointB;
    public GameObject mainCamera;
    public GameObject oppositeButton; 
    float speed;
    public bool move;   
    float num;
     public int maxNum;
     public float speedMultiplier;  
    void Start() { 
        if (speedMultiplier == 0)
            speedMultiplier = 1;
        num = 0;  
     }
    public void FixedUpdate () {
        if (move) {
            speed = speedMultiplier*num*Time.deltaTime/2;
            mainCamera.transform.position = Vector3.Lerp(pointA.position, pointB.position, speed);
            num++;
        }
        if (mainCamera.transform.position == pointB.position) { 
            move = false;
            GetComponent<slideOnce>().enabled = false;
        }
    }

    public void setMove() { 
        num = 0; 
        oppositeButton.GetComponent<slideOnce>().enabled = false;
        move = true;
    }
}
