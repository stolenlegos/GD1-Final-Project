using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour {

    public CanvasGroup uiElement;
    public CanvasGroup uiElement2;
    public GameObject mainCamera;
    private bool buttonAvailable; 

    public void Start() { 
        buttonAvailable = true;
    }
   

    public void swapUIs() {
        if (buttonAvailable) {
            GetComponent<slideOnce>().enabled = true;
            uiElement.interactable = false;
            uiElement.blocksRaycasts = false;
            uiElement2.interactable = true;
            uiElement2.blocksRaycasts = true;
            StartCoroutine(FadeCanvasGroup(uiElement2, uiElement2.alpha, 1, .5f));
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
        }
    }


    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, .5f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
	{
        buttonAvailable = false;
        float _timeStartedLerping = Time.time;
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / lerpTime;

		while (true)
		{
			timeSinceStarted = Time.time - _timeStartedLerping;
			percentageComplete = timeSinceStarted / lerpTime;

			float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

			yield return new WaitForFixedUpdate();
		}
        buttonAvailable = true; 
	}
}
