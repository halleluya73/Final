////using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class spritechange : MonoBehaviour {
//
//	public Sprite platfrom1;
//	public Sprite platfrom2;
//	public Sprite platfrom3;
//
//	float timer = 10f;
//	float delay = 10f;
//
//
//	// Use this for initialization
//	void Start () {
//		this.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom1;
//	}
//
//	// Update is called once per frame
//	void Update () 
//	{
//		timer -= Time.deltaTime;
//		Debug.Log ("time");
//		if (timer <= 0)
//		{
//			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == platfrom1) 
//			{
//				this.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom2;
//				timer = delay;
//				Debug.Log ("kuy");
//				return;
//
//			}
//			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == platfrom2) 
//			{
//				this.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom3;
//				timer = delay;
//				return;
//				Debug.Log ("kuytummimaitidwa");
//			}
//		}
//
//	}
//}
