using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOneScript : MonoBehaviour
{
    public GameObject GateOne;
    private Animator anim;
    private bool gateButtonActive;
    private bool animPlayed;

    // Start is called before the first frame update
    void Start()
    {
        animPlayed = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gateButtonActive) {
            if (Input.GetKeyDown(KeyCode.E)) {
                if (!animPlayed) { 
                    anim.Play("buttonAnimation");
                    Destroy(GateOne);
                    animPlayed = true;
                } 
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            gateButtonActive = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            gateButtonActive = false;
        }
    }
    
    /*void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("buttonAnimation");

                Destroy(GateOne);

            }
        }
    }*/
}
