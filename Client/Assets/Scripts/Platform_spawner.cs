using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platform_spawner : MonoBehaviour {
//	public Sprite platfrom1;
//	public Sprite platfrom2;
//	public Sprite platfrom3;

//	float timer = 1f;
//	float delay = 1f;

    private bool Playerspawn = false;

    private float yPos = -4f;

    private float xPos = 0f;

    [SerializeField]
    GameObject platformPrefab;

    [SerializeField]
    GameObject playerPrefab;

	[SerializeField]
	GameObject ItemPrefab;

	[SerializeField]
	GameObject ENEPrefab;

	[SerializeField]
	GameObject TapButton;

    public Camerafollow CmFol;


	void start()
	{
//		platformPrefab.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom1;
        StartCoroutine("LoopSpawnPlatform");
		spawnPlatformStart ();
		enespawnStart ();


	}
	public void TapButtonClick()
	{
		spawnPlatformStart();
		CmFol.CameraStartFollow();
		StartCoroutine("LoopSpawnPlatform");
//
		if (Time.timeScale == 0) 
		{
			Time.timeScale = 1;
		}
		Destroy (TapButton);
	}

	void enespawnStart ()
	{
		for (int i = 0; i < 1; i++) {
			xPos = 0f;
			yPos += 1f;

			Instantiate (ENEPrefab, new Vector3 (xPos, yPos, 0), Quaternion.identity);

		}	
	}

    void spawnPlatformStart()
    {


		for (int i = 0; i < 10; i++)

		{

			xPos = Random.Range(-4f, 6f);

			Instantiate(platformPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
	
			if (i <= 0)
			{
				if(Playerspawn == false)
				{
					Playerspawn = true;

					Instantiate(playerPrefab, new Vector3(xPos, yPos + 1f, 0f), Quaternion.identity);
				}

			}

			yPos += 2f;

		}

		for (int i = 0; i < 1; i++) {

			xPos = Random.Range (-3f, 4f);
			Instantiate (ItemPrefab, new Vector3 (xPos, yPos, 0), Quaternion.identity);

		}	


	
    }
    

    void Update()
	{
//		timer -= Time.deltaTime;
//		Debug.Log ("time");
//		if (timer <= 0)
//		{
//			if (platformPrefab.gameObject.GetComponent<SpriteRenderer> ().sprite == platfrom1) 
//			{
//				platformPrefab.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom2;
//				timer = delay;
//				Debug.Log ("kuy");
//				return;
//
//			}
//			if (platformPrefab.gameObject.GetComponent<SpriteRenderer> ().sprite == platfrom2) 
//			{
//				platformPrefab.gameObject.GetComponent<SpriteRenderer> ().sprite = platfrom3;
//				timer = delay;
//				return;
//				Debug.Log ("kuytummimaitidwa");
//			}
//		}
	}
    IEnumerator LoopSpawnPlatform ()
    {
        spawnPlatformStart();
		enespawnStart ();
        yield return new WaitForSeconds(1f);

        StartCoroutine("LoopSpawnPlatform");
    }
//	IEnumerator Destroyplat ()
//	{
//		Destroy (platformPrefab);
//		yield return new WaitForSeconds (5f);
//
//		StartCoroutine("Destroyplat");
//	}
}