using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScripts : MonoBehaviour
{
	public float moveRate = 2;
	public float moveTimer;
    float resetTimer;
	public float moveSpeed = 0.05f;
    void Start()
    {
        resetTimer = moveTimer; 
    }
    void Update()
    {
		moveTimer -= Time.deltaTime;
		if (moveTimer < 0) {
			moveSpeed = moveSpeed * -1;
			moveTimer = resetTimer;
		}
		transform.Translate(moveSpeed, 0, 0);
    }
}
