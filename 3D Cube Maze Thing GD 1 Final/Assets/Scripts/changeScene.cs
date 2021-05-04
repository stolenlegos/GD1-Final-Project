using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class changeScene : MonoBehaviour {
    public void loadScene() { 
        SceneManager.LoadScene("TESTING SCENE #1");
    }

    public void loadHome() {
        SceneManager.LoadScene("Main Menu"); 
    }

    public void loadCredits() { 
        SceneManager.LoadScene("credits"); 
    }

    public void loadControls() { 
        SceneManager.LoadScene("controls"); 
    }
    public void quit() {
        Application.Quit();
    }
}
