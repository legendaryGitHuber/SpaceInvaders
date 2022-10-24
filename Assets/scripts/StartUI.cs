using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class StartUI : MonoBehaviour 
{
    public Image homeScreen;
    public Button play;
    public Button settings;

    //visible or invisible
    public float target = 0.0f;

    public float second = 2.0f;

    public bool getImageDone;

    private void Start()
    {
	StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        float alpha = homeScreen.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / second)
        {
            //change color as you want
            Color newColor = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(alpha, target , t));
            homeScreen.color = newColor;
            yield return null;
        }
	if(alpha == 5f)
	{
	    play.GetComponent<Image>().enabled = false;
	    settings.GetComponent<Image>().enabled = false;
	}
    }

    public void ChangeScene()
    {
	SceneManager.LoadScene("Game");
    }

}
