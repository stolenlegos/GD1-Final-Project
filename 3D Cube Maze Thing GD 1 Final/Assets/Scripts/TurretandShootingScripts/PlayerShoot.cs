using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject cameraObj;
    private bool DestroyerPickedUp;


    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");

        DestroyerPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && DestroyerPickedUp == true)
        {

            GameObject bulletBreakable = Instantiate(bulletPrefab, transform.position, transform.rotation);

        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Destroyer")
        {
            DestroyerPickedUp = true;

            Destroy(col.gameObject);

            Debug.Log("Weapon Pickup");
        }
    }

}
