using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickUpScript : MonoBehaviour
{
    GameObject Weapon;
    public int reload;

    // Start is called before the first frame update
    void Start()
    {
       Weapon = GameObject.Find("Weapon/Trigger");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Ammo")
        {

            reload = reload + Random.Range(2, 4);

            Destroy(col.gameObject);

            Debug.Log("reload");
        }
    }

}