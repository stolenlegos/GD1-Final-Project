using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool WeaponOn;
    public GameObject BulletBreakable;

    // Start is called before the first frame update
    void Start()
    {
        WeaponOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WeaponOn == true)
        {
            GameObject bullet = Instantiate(BulletBreakable, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Destroyer")
        {
            Destroy(col.gameObject);

            WeaponOn = true;
        }
    }
}
