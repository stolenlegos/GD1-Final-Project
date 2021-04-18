using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Vector3 playerVelocity = Vector3.zero;
    public float speed = 10.0F;
    public float rotateSpeed = 1.0F;
    public bool freeze = false;
    private float jumpVelocity = 0.2f;
    private float gravityValue = -1.0f;
    private bool grounded = true;
    private int framesInAir = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // controller.isGrounded seems unreliable: sometimes returns false when the player is on the ground
        // fix this by "filtering" the value: only believe we're in the air if it says so 3 times in a row
        if (controller.isGrounded)
        {
            framesInAir = 0;
            grounded = true;
        }
        else
        {
            framesInAir += 1;
            if (framesInAir >= 3)
            {
                grounded = false;
            }
        }

        if (freeze)
        {
            playerVelocity = Vector3.zero;
            return;
        }

        // Rotate around y - axis
        gameObject.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.Move(forward * curSpeed * Time.deltaTime);

        // Apply gravity as a decrease in y velocity. But zero out fall speed if we hit the ground
        playerVelocity.y += gravityValue * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Implement jump as an increase in y velocity
        // Uncomment the Debug.Log lines for some debug output
        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerVelocity.y += jumpVelocity;
            // Debug.Log("Jump!");
        }
        else
        {
            // Debug.Log("Is button down? " + Input.GetButtonDown("Jump"));
            // Debug.Log("Is player grounded? " + grounded);
        }
        // Debug.Log("Current Y velocity:" + playerVelocity.y);

        controller.Move(playerVelocity);
    }
}
