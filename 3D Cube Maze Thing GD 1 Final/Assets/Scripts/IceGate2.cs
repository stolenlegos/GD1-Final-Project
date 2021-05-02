using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGate2 : MonoBehaviour
{
    public GameObject gate;
    public GameObject playerchip;
    private playerChipScripts chips;
    // Start is called before the first frame update
    void Start()
    {
        chips = playerchip.GetComponent<playerChipScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chips.pCBlue == 2 ) {

            Destroy(gate);
        }
    }
}
