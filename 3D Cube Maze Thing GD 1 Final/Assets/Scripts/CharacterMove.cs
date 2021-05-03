using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Vector3 playerVelocity = Vector3.zero;
    public float speed = 10.0F;
    public float ratio = 3.0F; // ratio of run to walk speeds
    public float rotateSpeed = 1.0F;
    [HideInInspector] public bool freeze = false;
    public float jumpVelocity = 10.0F;
    //[HideInInspector] public float gravityValue = -1000.0F;
    private float gravityValue = -40.0F;
    private bool grounded = true;
    private int framesInAir = 0;
    bool pause = false;


    private bool onSlope; // is on a slope or not
    public float slideFriction = 1f; // ajusting the friction of the slope
    private Vector3 hitNormal; //orientation of the slope.
    bool slip = false; //is trigger tags as Slippery
    float climbAble = 40f;
    public float slideAt = 15f; //when to start sliding, if slippery

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            pause = !pause;
            if (!pause)
            {
                //Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (pause)
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //return;
        }

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        CharacterController controller = GetComponent<CharacterController>();
        // controller.isGrounded seems unreliable: sometimes returns false when the player is on the ground
        // fix this by "filtering" the value: only believe we're in the air if it says so 3 times in a row
        if (controller.isGrounded)
        {
            //Debug.Log("Grounded: True");
            framesInAir = 0;
            grounded = true;
            //Debug.Log("Grounded, framesInAir " + framesInAir);
        }
        else
        {
            framesInAir += 1;
            //Debug.Log("Grounded False (" + framesInAir + " frames)");

            if (framesInAir > 25) // can increase even more (~40) if needed
            {
                grounded = false;
                //Debug.Log("GROUNDED FALSE, " + "framesInAir " + framesInAir);
            }
        }

        if (freeze)
        {
            playerVelocity = Vector3.zero;
            return;
        }

        // Rotate around y - axis
        if (!pause)
        {
            gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed / 8, 0);
            gameObject.transform.Rotate(0, Input.GetAxis("LeftRight") * rotateSpeed / 10, 0);
        }

        //implementing slope slide mechanic
        float hitAngle = Vector3.Angle(Vector3.up, hitNormal);
        onSlope = !(hitAngle <= controller.slopeLimit);

       // controller.slopeLimit = climbAble; //maximum slope the charachter can climb, in degrees

        if (slip)
        {
            playerVelocity.y += gravityValue;
            playerVelocity.x += (1f - hitNormal.y) * hitNormal.x * (-gravityValue - slideFriction);
            playerVelocity.z += (1f - hitNormal.y) * hitNormal.z * (-gravityValue - slideFriction);
        }
        else
        {
            //playerVelocity.y = -2f;
            playerVelocity.x = 0f;
            playerVelocity.z = 0f;
        }

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(forward * curSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(forward * curSpeed / ratio * Time.deltaTime);
        }


        // Move left / right
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedLR = speed * Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(right * curSpeedLR * Time.deltaTime);
        }
        else
        {
            controller.Move(right * curSpeedLR / ratio * Time.deltaTime);
        }


        // Apply gravity as a decrease in y velocity. But zero out fall speed if we hit the ground
        Vector3 down = transform.TransformDirection(Vector3.down);
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
            //Debug.Log("Jump!");
        }
        else
        {
            //Debug.Log("No Jump.");
            // Debug.Log("Is button down? " + Input.GetButtonDown("Jump"));
            // Debug.Log("Is player grounded? " + grounded);
        }
        //Debug.Log("Current Y velocity:" + playerVelocity.y + "Gravity value " + gravityValue + "TimeDelta " + Time.deltaTime);
        //Debug.Log("Speed " + speed);
        controller.Move(playerVelocity * Time.deltaTime);

        //Debug.Log("Gravity " + gravityValue + "Speed " + speed);
    }

    //Implementing slide mechanic. might return the normal vector of the characters hit box?
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slippery"))
        {
            slip = true;
            climbAble = slideAt;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slippery"))
        {
            slip = false;
            climbAble = 40;
        }
    }
}
