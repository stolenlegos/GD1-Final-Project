using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        float moveSpeed = 10.0f;
        float rotateSpeed = 50.0f;

        // Prevent player from moving past first lillypad
       /* if (gameObject.transform.position.z > 8)
        {
            //gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
            //gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime * 100.0f, Space.World);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 8.0f);
            return;
        }*/

        // TRANSLATE

        if (Input.GetKey(KeyCode.W))
        {
            // gameObject.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
                gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //gameObject.transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.position -= Vector3.left * moveSpeed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.E))
        {
            //gameObject.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //gameObject.transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
        }


        //ROTATE

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //gameObject.transform.Rotate(-1.0f * rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
            //gameObject.transform.Rotate(gameObject.transform.right, -1.0f * rotateSpeed * Time.deltaTime);
            gameObject.transform.Rotate(Vector3.right, -1.0f * rotateSpeed * Time.deltaTime, Space.Self); // Space.Self is default
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //gameObject.transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
            //gameObject.transform.Rotate(gameObject.transform.right, rotateSpeed * Time.deltaTime);
            gameObject.transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //gameObject.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
            //gameObject.transform.Rotate(gameObject.transform.up, rotateSpeed * Time.deltaTime);
            gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World); // Space.World is the other option
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //gameObject.transform.Rotate(0.0f, -1.0f * rotateSpeed * Time.deltaTime, 0.0f);
            //gameObject.transform.Rotate(gameObject.transform.up, -1.0f * rotateSpeed * Time.deltaTime);
            gameObject.transform.Rotate(Vector3.up, -1.0f * rotateSpeed * Time.deltaTime, Space.World);
        }

       
    }
}
