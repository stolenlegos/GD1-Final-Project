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

    public GameObject bulletPrefab;

  public Transform target;

  public float player_dist_threshold; // length of cone

  public float angleThreshold; // radius of cone

  float player_dist;

  float angleBetween;

  int FrameTimer;

  int abort = 0;

    float currentRotation = 0.0f;

    bool MovingRight;

    void Start()
    {
     
    }
    void Update()
    {
        player_dist = Vector3.Distance(target.position, transform.position); 

        Vector3 targetDir = target.position - transform.position;
        angleBetween = Vector3.Angle(-transform.forward, targetDir);

        bool wallBlocksVisibility = false;

        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, targetDir.normalized, out hitInfo, targetDir.magnitude))
        {
            if(hitInfo.collider.gameObject != target)
            {
                wallBlocksVisibility = true;
            }
        }

        bool player_in_cone = player_dist <= player_dist_threshold && angleBetween >= -angleThreshold && angleBetween <= angleThreshold && !wallBlocksVisibility;

        Debug.DrawRay(transform.position, targetDir.normalized * player_dist_threshold, Color.red);
        Debug.DrawRay(transform.position, -transform.forward * player_dist_threshold, Color.blue);

        if(state == States.Idle && player_in_cone)
        {
            state = States.Fire;

        }
        else if(state == States.Fire && !player_in_cone)
        {
            state = States.Search;

            FrameTimer = 600;

            MovingRight = true;
        }
        else if(state == States.Search && !player_in_cone && FrameTimer <= abort)
        {
            state = States.Idle;
        }
        if(state == States.Idle)
        {
            
        }
        if (state == States.Fire)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if (angleBetween < 0.0f)
            {
                transform.Rotate(Vector3.up, -1.0f, Space.Self);

                currentRotation = currentRotation - 1.0f;
            }
            else
            {
                transform.Rotate(Vector3.up, 1.0f, Space.Self);

                currentRotation = currentRotation + 1;
            }
     
        }
        if(state == States.Search)
        {
            if(MovingRight && currentRotation < angleThreshold)
            {
                transform.Rotate(Vector3.up, 1.0f, Space.Self);

                currentRotation = currentRotation + 1;
            }
            else if (MovingRight && currentRotation >= angleThreshold)
            {
                MovingRight = false;
            }
            else if (currentRotation > -angleThreshold)
            {
                transform.Rotate(Vector3.up, -1.0f, Space.Self);

                currentRotation = currentRotation - 1.0f;
            }
            else
            {
                MovingRight = true;
            }

            FrameTimer = FrameTimer - 1;
        }
 
    }

}
