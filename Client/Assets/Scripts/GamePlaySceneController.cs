using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySceneController : MonoBehaviour 
{
	[SerializeField]
	private GameManager gameManager;

	private static GamePlaySceneController instance;

	public GameManager GameManager{get{ return gameManager;}}
	public static GamePlaySceneController Instance{ get{return instance; }}

	void Awake()
	{
		instance = this;
	}
}
