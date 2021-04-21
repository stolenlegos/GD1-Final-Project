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

  public Transform target;

  public float angleBetween = 0.0f;

  private GameObject Player;

  private Transform position;

    float player_dist;

    float player_dist_threshold;

    float FrameTimer;

    void Start()
    {
        Player = GameObject.Find("Player");

        position = Player.GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        angleBetween = Vector3.Angle(transform.forward, targetDir);

        if(state == States.Idle && player_dist <= player_dist_threshold)
        {
            state = States.Fire;
        }
        else if(state == States.Fire && player_dist > player_dist_threshold)
        {
            state = States.Search;
        }
        else if(state == States.Search && player_dist > player_dist_threshold && FrameTimer == 0)
        {
            state = States.Idle;
        }
        if(state == States.Idle)
        {
            
        }
        if(state == States.Fire)
        {
            
        }
        if(state == States.Search)
        {
            
        }
 
    }

}
