using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
  public GameObject player;
  private RGTeslaButton redTracker;
  public bool green;
    // Start is called before the first frame update
    void Start()
    {
      redTracker = player.GetComponent<RGTeslaButton>();
    }

    // Update is called once per frame
    void Update()
    {
      if (!redTracker.GreenRed)
      {
        green = true;
      } else {
        green = false;
      }
    }
}
