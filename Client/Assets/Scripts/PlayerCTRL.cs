using System.Collections;
using UnityEngine;

public class PlayerCTRL : MonoBehaviour 
{  
	public AudioClip jump;

	public AudioClip die;

	private AudioSource ffx;
	public float jumpSPD;
	[SerializeField]
	private float moveSpd;
    [SerializeField]

	public int Status = 1;

	private Rigidbody2D myRigidbody2d;
	private SpriteRenderer mySpriteRenderer;
	private GameManager gameManger;


	public GameObject fire1;

	//private bool readycounting = false;

	public int score;

	float playerFirstYPos;

	void start()
	{
		jumpSPD = 500f;
		playerFirstYPos = transform.position.y;

	}

    void Awake()
	{
		ffx = GetComponent<AudioSource> ();
		myRigidbody2d = GetComponent<Rigidbody2D> ();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
		gameManger = GamePlaySceneController.Instance.GameManager;
	}
    // Update is called once per frame

    void Update()
    {
		FlipCharacter ();
		SetScore ();

		if (jumpSPD > 510f) 
		{
			StartCoroutine ("normalspeed");
			fire1.SetActive (true);
		}
		Debug.Log (jumpSPD);
    }

    void FixedUpdate  ()
    {
		Movement ();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.CompareTag("Jumpable"))
		{
			ffx.PlayOneShot (jump);
        	myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x, 0f);
        	myRigidbody2d.AddForce(Vector2.up * jumpSPD);
			

        }
		if(col.gameObject.CompareTag("Star"))
		{
			myRigidbody2d.velocity = new Vector2(myRigidbody2d.velocity.x, 0f);
			myRigidbody2d.AddForce(Vector2.up * jumpSPD);
		}
			
		if (col.gameObject.CompareTag ("Killbox")) 
		{
			if(score > ScoreUpdate.Instance.HighScore)
                {
                    ScoreUpdate.Instance.HighScore = score;
                    PlayerPrefs.SetInt("Highscore", ScoreUpdate.Instance.HighScore);
                    ScoreUpdate.Instance.UpdateScore();	
					Debug.Log("can update");	
                }
			ffx.PlayOneShot (die);
			gameManger.GameOver ();
			
			this.gameObject.SetActive (false);
			
			if (Time.timeScale == 1f) 
			{
				Time.timeScale = 0f;
				
			}
			
		}
	}
	


	void FlipCharacter()
	{
		if (Input.GetAxisRaw("Horizontal") < 0)
			mySpriteRenderer.flipX = true;

		else if (Input.GetAxisRaw("Horizontal") > 0)
			mySpriteRenderer.flipX = false;
		
	}

	void Movement()
	{
		myRigidbody2d.AddForce (Vector2.right * Input.GetAxis("Horizontal") * moveSpd);
	}
		
	void SetScore()
	{
		score = Mathf.Max (score, Mathf.FloorToInt (transform.position.y - playerFirstYPos));
		gameManger.startcountscore (score);

	}
		
	public void speedup (float speed)
	{
		jumpSPD += speed;

	}
	IEnumerator normalspeed ()
	{
		yield return new WaitForSeconds (5f);
		jumpSPD = 500f;
		fire1.SetActive (false);
	}
 
}