using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChipScripts : MonoBehaviour
{
    public bool greenWon;
    private bool greenActive;
    public GameObject greenChip;
    public bool blueWon;
    private bool blueActive;
    public GameObject blueChip;
    public bool yellowWon;

    private bool yellowActive;
    public GameObject yellowChip;
    public bool purpleWon;

    private bool purpleActive;
    public GameObject purpleChip;
    public bool redWon;

    private bool redActive;
    public GameObject redChip;
    private bool whiteActive;
    public GameObject whiteWall;
    public GameObject island; 
    // Start is called before the first frame update
    void Start()
    {
        greenChip.SetActive(false);
        blueChip.SetActive(false);
        yellowChip.SetActive(false);
        purpleChip.SetActive(false);
        redChip.SetActive(false);
        island.SetActive(false);
        greenWon = false;
        greenActive = false;
        blueWon = false;
        blueActive = false;
        yellowWon = false;
        yellowActive = false;
        purpleWon = false;
        purpleActive = false;
        redWon = false;
        redActive = false;
        whiteActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (greenWon && !greenActive)
            setGreenActive();
        if (blueWon && !blueActive)
            setBlueActive();
        if (yellowWon && !yellowActive)
            setYellowActive();
        if (purpleWon && !purpleActive)
            setPurpleActive();
        if (redWon && !redActive)
            setRedActive();
        if (greenWon && blueWon && yellowWon && purpleWon && redWon && whiteActive)
            openExit();
    }

    private void setGreenActive() {
        greenActive = true;
        greenChip.SetActive(true);
    }
    private void setBlueActive() {
        blueActive = true;
        blueChip.SetActive(true);
    }
    private void setPurpleActive() {
        purpleActive = true;
        purpleChip.SetActive(true);
    }
    private void setYellowActive() {
        yellowActive = true;
        yellowChip.SetActive(true);
    }
    private void setRedActive() {
        redActive = true;
        redChip.SetActive(true);
    }

    private void openExit() {
        whiteActive = false;
        whiteWall.SetActive(false);
        island.SetActive(true);
    }
}
