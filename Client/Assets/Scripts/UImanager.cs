using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

	public Image PauseText;

	public Image gameOverText;

	public Text scoreText;

	public GameObject Menu;

	public GameObject PlayAgain;

	public GameObject Leader;
	public GameObject Page3;

	public void ShowGameOverText ()
	{
		gameOverText.gameObject.SetActive(true);
		PlayAgain.gameObject.SetActive (true);
		Menu.gameObject.SetActive (true);
		Leader.gameObject.SetActive(true);
	}

	public void TapPauseClick ()
	{
		if (Time.timeScale == 1.0F) 
		{
			Time.timeScale = 0.0F;
			PauseText.gameObject.SetActive (true);
		} 
		else 
		{
			Time.timeScale = 1.0F;
			PauseText.gameObject.SetActive (false);
		}
	}
    public void LeaderClick ()
	{
		Page3.gameObject.SetActive(true);
	}
	public void LeaderCLOSEClick ()
	{
		Page3.gameObject.SetActive(false);
	}

	public void ShowScoreText(int score)
	{
		scoreText.text = "Score: " + score.ToString ();
		//Debug.Log ("score" + score);
	}
}
