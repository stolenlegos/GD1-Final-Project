using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    enum States
    {
        Patrol,
        Chase,
        Attack
    }
    States state = States.Patrol;

    float player_dist_threshold = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "patrol" && player_dist_threshold < player_dist_threshold)
        {
            state = 1;
        }
        else if(state == 1 && player_dist_threshold > player_dist_threshold)
        {
            state = 2;
        }
        if (state == "patrol")
        {
            patrol();
        }
        else if (state == "attack")
        {
            attack();
        }
        else if (state == "chase")
        {
            chase();
        }
        else
        {
            Debug.Log("Invalid state: " + state);
        }
    }
}
