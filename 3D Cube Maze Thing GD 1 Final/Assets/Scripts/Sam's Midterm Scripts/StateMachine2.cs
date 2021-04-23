using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine2 : MonoBehaviour
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

    public GameObject Player;

    float currentRotation = 0.0f;

    bool MovingRight;

    Vector3 startPosition;

    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    void Update()
    {
        player_dist = Vector3.Distance(target.position, transform.position);

        Vector3 targetDir = target.position - transform.position;
        angleBetween = Vector3.Angle(transform.forward, targetDir);


        bool wallBlocksVisibility = false;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, targetDir.normalized, out hitInfo, targetDir.magnitude))

            Debug.Log("Working");
        {
            if (hitInfo.collider.gameObject != Player)
            {
                wallBlocksVisibility = true;
            }
        }

        bool player_in_cone = player_dist <= player_dist_threshold && angleBetween >= -angleThreshold && angleBetween <= angleThreshold && !wallBlocksVisibility;

        Debug.DrawRay(transform.position, targetDir.normalized * player_dist_threshold, Color.red);
        Debug.DrawRay(transform.position, transform.forward * player_dist_threshold, Color.blue);

        if (player_dist > player_dist_threshold && angleBetween < -angleThreshold || angleBetween > angleThreshold)
        {
            Debug.Log("player is not in range");
        }

        if (state == States.Idle && player_in_cone)
        {
            state = States.Fire;

            Debug.Log("player in range");
        }
        else if (state == States.Fire && !player_in_cone)
        {
            state = States.Search;

            FrameTimer = 6000;

            MovingRight = true;
        }
        else if (state == States.Search && !player_in_cone || FrameTimer <= abort)
        {
            state = States.Idle;
        }
        if (state == States.Idle)
        {

            Debug.Log("Turret is idle");
        }
        if (state == States.Fire)
        {
            if (angleBetween > -angleThreshold || angleBetween < angleThreshold)
            {

                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                Debug.Log("Turret is firing");
            }
        }
        if (state == States.Search)
        {

            FrameTimer = FrameTimer - 1;

            Debug.Log("Turret is searching");

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
