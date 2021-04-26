using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    //movement speed

    private float movementSpeed = 10.0f;

    //win condition
    bool playerwon = false;

    //FrameTimer

    private bool Timer = false;
    private int end;

    // Start is called before the first frame update
    void Start()
    {
        end = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving forward on W key press
        if (Input.GetKey(KeyCode.W))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            //update the position
            transform.Translate(new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime));
            //Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            // rb.AddForce(transform.forward * 100.0f);
        }
        // Canceling Movement on Key release
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(0, 0, 0);
        }
        // Moving left on A key press
        if (Input.GetKey(KeyCode.A))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            //update the position
            transform.Translate(new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime));

            //Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            // rb.AddForce(transform.TransformDirection(Vector3.left) * 100.0f);
        }
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(0, 0, 0);
        }
        // Moving right on D key press
        if (Input.GetKey(KeyCode.D))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            //update the position
            transform.Translate(new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime));

            // Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            // rb.AddForce(transform.TransformDirection(Vector3.right) * 100.0f);
        }
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(0, 0, 0);
        }
        // Moving back on S key press
        if (Input.GetKey(KeyCode.S))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            //update the position
            transform.Translate(new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime));

            //Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            // rb.AddForce(transform.TransformDirection(Vector3.back) * 100.0f);
        }
        else
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            transform.Rotate(0, -0.0001f, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //get the Input from Horizontal axis
            float horizontalInput = Input.GetAxis("Horizontal");
            //get the Input from Vertical axis
            float verticalInput = Input.GetAxis("Vertical");

            transform.Rotate(0, 0.0001f, 0);
        }
        if(Timer == true)
        {
            end = end - 1;
            if(end <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "RepairDock")
        {
            playerwon = true;

            Timer = true;

        }
    }
    private void OnGUI()
    {

        if (playerwon)
        {
            GUI.Label(new Rect(250, 250, 200, 200), "You win!");

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white, 5.0f);

            Debug.Log(collision.collider.name + collision.gameObject.transform.position.x);
        }
    }
}
