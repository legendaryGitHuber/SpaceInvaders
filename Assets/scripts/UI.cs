using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UI : MonoBehaviour
{
    public PlayerCharacter playerCharacter;

    public Text scoreText;
    public Slider healthBar;
    public Text textForScore;

    public void RestartButton()
    {
	playerCharacter.score = 0;
	scoreText.gameObject.SetActive(true);
	healthBar.gameObject.SetActive(true);
	textForScore.gameObject.SetActive(true);
    }

    public void HomeButton()
    {
	SceneManager.LoadScene("Start");
    }
}
