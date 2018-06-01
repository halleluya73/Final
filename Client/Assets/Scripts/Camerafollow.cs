using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour {

    private GameObject Player;
    private Transform PlayerVector;

    private bool StartUpdate = false;

    //[SerializeField]
    Vector3 followPos;
    float yPos;


void Awake()
{
        followPos = new Vector3(transform.position.x, 1 ,transform.position.z);

}

void start()

    {
       yPos = PlayerVector.position.y;
       transform.position = followPos + (Vector3.up * yPos);

    }
    
    void Update ()
    {
        if(StartUpdate == true)
        {
            yPos = Mathf.Max(yPos, PlayerVector.position.y);
            transform.position = followPos + (Vector3.up * yPos);
        }
        

    }

    IEnumerator CameraStartFallow()
    {
        yield return new WaitForSeconds(1f);
        if (Player == null)
        {
            Player = GameObject.Find("Player(Clone)");
            PlayerVector = Player.transform;
        }

        yPos = PlayerVector.position.y;
        transform.position = followPos + (Vector3.up * yPos);
        StartUpdate = true;

    }
    public void CameraStartFollow()
    {
        StartCoroutine("CameraStartFallow");

    }

 }