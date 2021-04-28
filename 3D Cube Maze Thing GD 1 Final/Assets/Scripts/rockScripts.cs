using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScripts : MonoBehaviour
{
	public float moveRate = 2;
	public float moveTimer;
    float resetTimer;
	public float moveSpeed;
    void Start()
    {
        resetTimer = moveTimer; 
    }
    void FixedUpdate()
    {
		moveTimer -= Time.deltaTime;
		if (moveTimer < 0) {
			moveSpeed = moveSpeed * -1;
			moveTimer = resetTimer;
		}
		transform.Rotate(0, moveSpeed, 0);
    }
}
