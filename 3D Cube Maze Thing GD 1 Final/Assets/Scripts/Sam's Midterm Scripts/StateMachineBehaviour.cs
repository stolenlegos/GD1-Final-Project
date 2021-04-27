using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour : MonoBehaviour
{
   enum States
    {
        Idle,

        Fire,

        Search,
    }
  States state = States.Idle; // Idle = 0, Fire = 1, Search = 2

  bool wallBlocksVisibility = false;

  public GameObject bulletPrefab;

  public Transform target; // location of target

  public float player_dist_threshold; // length of cone

  public float angleThreshold; // radius of cone

  public int framesBetweenShots = 10;

  int framesBlocked = 0;

  public bool debugFlag = false;

  public bool debugFlag2 = false;

  float player_dist; // player distance from cone

  float angleBetween; // player location in or out of radius of cone

  int FrameTimer; // countdown

  int abort = 0; // end of countdown

    public GameObject Player; // target

    float currentRotation = 0.0f; // speed of search rotation animation

    bool MovingRight; // rotation animation during search

   // Quaternion startRotation; // starting rotation of turret

    private int ShotTimer;

   // bool ResetPosition;

    void Start()
    {
       // startRotation = transform.rotation;

      //  ResetPosition = false;
    }
    void Update()
    {
        player_dist = Vector3.Distance(target.position, transform.position); 

        Vector3 targetDir = target.position - transform.position;
        angleBetween = Vector3.Angle(transform.forward, targetDir);

        Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);

        //RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, targetDir.normalized, out RaycastHit hitInfo, targetDir.magnitude))
        {

            if(debugFlag)
            {
                Debug.Log("RaycastHit " + hitInfo);
            }

            LayerMask mask = LayerMask.GetMask("Default");
            if (debugFlag2)
            {
                Debug.Log("Working");
            }
        
            if(hitInfo.collider.gameObject != Player)
            {

                //if (!wallBlocksVisibility)
                //{
                    //framesBlocked = 0;
                //}
                //else
                //{
                    framesBlocked += 1;
                    if (framesBlocked >= 300)
                    {
                        wallBlocksVisibility = true;
                        framesBlocked = 0;
                        if (debugFlag)
                        {
                            Debug.Log("TURRET BREAKS");
                        }
                    }
                //}

            }
            else
            {
                wallBlocksVisibility = false;
            }
        }

        bool player_in_cone = player_dist <= player_dist_threshold && angleBetween >= -angleThreshold && angleBetween <= angleThreshold && !wallBlocksVisibility;

        if(debugFlag)
        {
            Debug.Log("is player in cone? " + player_in_cone +  " " + player_dist + " " + angleBetween);
        }    

        Debug.DrawRay(transform.position, targetDir.normalized * player_dist_threshold, Color.red);
        Debug.DrawRay(transform.position, transform.forward * player_dist_threshold, Color.blue);

        if(player_dist > player_dist_threshold && angleBetween < -angleThreshold || angleBetween > angleThreshold)
        {
            if(debugFlag2)
            {
                Debug.Log("player is not in range");
            }

        }

        if(state == States.Idle && player_in_cone)
        {
            state = States.Fire;
            if (debugFlag2)
            {
                Debug.Log("player in range");
            }
        }
        else if(state == States.Fire && !player_in_cone)
        {
            
            state = States.Search;

            FrameTimer = 300;

            MovingRight = true;
            if (debugFlag2)
            {
                Debug.Log("Entering Search");
            }
        }
        else if(state == States.Search && player_in_cone)
        {
            state = States.Fire;
            if (debugFlag2)
            {
                Debug.Log("Target Reacquired");
            }
        }
        else if(state == States.Search && !player_in_cone && FrameTimer <= abort)
        {
            state = States.Idle;
            if (debugFlag2)
            {
                Debug.Log("Entering Idle");
            }
        }
       if(state == States.Idle)
        {
            ShotTimer = 0;

            //if(ResetPosition == true)
          //  {
             //   gameObject.transform.rotation = startRotation;

           //     ResetPosition = false;
          //  }

            if (debugFlag2)
            {
                Debug.Log("Turret is idle");
            }
        }
       if (state == States.Fire)
        {
            this.transform.LookAt(targetPosition);

            bool ShootTarget = ShotTimer <= 0;

            if (ShootTarget == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                ShotTimer = framesBetweenShots; // 10;
            }
            else
            {
                ShotTimer = ShotTimer - 1;
            }
            if (debugFlag2)
            {
                Debug.Log("Turret is firing");
            }
           
        }
        if(state == States.Search)
        {
           // ResetPosition = true;

            FrameTimer = FrameTimer - 1;
            if (debugFlag2)
            {
                Debug.Log("Turret is searching");
            }

            if (MovingRight && currentRotation < angleThreshold)
            {
                transform.Rotate(Vector3.up, 0.01f, Space.Self);

                currentRotation = currentRotation + 0.1f;
            }
            else if (MovingRight && currentRotation >= angleThreshold)
            {
                MovingRight = false;
            }
            else if (currentRotation > -angleThreshold)
            {
                transform.Rotate(Vector3.up, -0.01f, Space.Self);

                currentRotation = currentRotation - 0.1f;
            }
            else
            {
                MovingRight = true;

                if (FrameTimer <= abort)
                {

                }
            }


        }
 
    }

}

   
