using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{


	public PlayerCTRL Playercon ;
	void Start ()
	{
		
		Playercon = GameObject.Find ("Player(Clone)").GetComponent<PlayerCTRL> ();

	}

	void OnTriggerEnter2D (Collider2D orther)
	{

		if (orther.tag == "Player")
		{
			
			Playercon.speedup (300f);

			Destroy (this.gameObject);


		}

	}
		

}
