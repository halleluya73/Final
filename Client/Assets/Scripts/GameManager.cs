using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public UImanager uiManager;

	[SerializeField]
	PlayerCTRL playerScipt;
	public AudioSource BGM;

	public void TapStartClick()
	{
		SceneManager.LoadScene ("Demo 001");
	}

	public void TapMenuClick()
	{
		SceneManager.LoadScene ("menu");
	}

	public void TapPlayAGClick()
	{
		SceneManager.LoadScene ("Demo 001");
		if (Time.timeScale == 0) 
		{
			Time.timeScale = 1;
		}
	}
	void start()
	{
//		BGM = GetComponent<AudioSource> ();
//		BGM.Play ();
//		BGM.Play (44100);
	}

	public void GameOver()
	{
		uiManager.ShowGameOverText ();
	}
		

	void Update()
	{
		//uiManager.ShowScoreText (playerScipt.score);
		//Debug.Log(playerScipt.score);

	}
	public void startcountscore(int score)
	{
		
		uiManager.ShowScoreText (score);

	}


}
