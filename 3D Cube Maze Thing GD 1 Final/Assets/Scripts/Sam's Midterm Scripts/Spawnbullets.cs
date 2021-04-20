using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawnbullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Player;
    private GameObject cameraObj;
    private int FrameTimer;
    public int ammo;
    public Text txt;
    GameObject PickUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Rigidbody PlayerBody = Player.GetComponent<Rigidbody>();

            PlayerBody.isKinematic = true;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            FrameTimer = 10;

            ammo = ammo - 1;

            txt.text = "Ammo " + ammo.ToString();

            Debug.Log("kinematic working");
        }
        else
        {
            if (FrameTimer >= 1) {

                FrameTimer = FrameTimer - 1;

            }
            else
            {
                Rigidbody PlayerBody = Player.GetComponent<Rigidbody>();

                PlayerBody.isKinematic = false;
            }
        }


    }

}

