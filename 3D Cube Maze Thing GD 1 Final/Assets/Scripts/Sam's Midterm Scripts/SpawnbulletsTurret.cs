using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnbulletsTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "player")
        {
            transform.LookAt(Player);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

    }
    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "player")
        {
            transform.LookAt(Player);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

    }
}

