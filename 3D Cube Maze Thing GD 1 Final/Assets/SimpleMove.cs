using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{

    private float speed = 10.0F;
    private float rotateSpeed = 1.0F;
    private float jumpVelocity = 2.0f;
    private float gravityValue = -1.0f;
    private Vector3 playerVelocity = Vector3.zero;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        grounded = controller.isGrounded;

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.Move(forward * curSpeed * Time.deltaTime);

        // Jumping and falling
        playerVelocity.y += gravityValue * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += jumpVelocity;
            Debug.Log("We should be jumping!");
        }
        else
        {
            Debug.Log("Is button down? " + Input.GetButtonDown("Jump"));
            Debug.Log("Is player grounded? " + grounded);
        }

        Debug.Log("Current Y velocity: " + playerVelocity.y);

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity);

    }
}
