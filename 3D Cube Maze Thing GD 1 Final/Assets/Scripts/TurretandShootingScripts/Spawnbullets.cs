using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawnbullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            GameObject bulletBreakable = Instantiate(bulletPrefab, transform.position, transform.rotation);

        }

    }

}

