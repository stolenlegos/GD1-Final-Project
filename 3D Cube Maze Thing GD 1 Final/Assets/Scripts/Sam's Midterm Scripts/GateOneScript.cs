using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOneScript : MonoBehaviour
{
    public GameObject GateOne;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("buttonAnimation");

                Destroy(GateOne);

                Debug.Log("input");
            }
        }
    }
}
