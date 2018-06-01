using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Net;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class LoginScripts : MonoBehaviour {

    private static LoginScripts instance;

    [SerializeField]
	private string loginUser;
     [SerializeField]
    public static string currentUser;
    public string URL;
    public InputField userIDEnter;
    public InputField passwordEnter;

	
    private string userIDkey;
    private string passwordkey;

    private ButtonManager btn;
    public LeaderBoardScript ldb;
    void Start()
    {
        loginUser = PlayerPrefs.GetString("CurrentUser");
        currentUser = loginUser;
        //btn = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManager>();
        //ldb = GameObject.FindGameObjectWithTag("nameList").GetComponent<LeaderBoardScript>();
    }

    // Update is called once per frame

     public static LoginScripts Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<LoginScripts>();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    public void LoginToBorad()
    {

        userIDkey = userIDEnter.text;
        passwordkey = passwordEnter.text;
        
		loginUser = "http://ec2-13-229-215-177.ap-southeast-1.compute.amazonaws.com:8081/user/login/" + userIDkey;
		URL = loginUser;
        currentUser = userIDkey;
        
   

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            string responseBody = new StreamReader(stream).ReadToEnd();

            print(userIDkey);

            UserID[] userIDs = JsonConvert.DeserializeObject<UserID[]>(responseBody);
            print(userIDs[0].name);


			if(userIDkey == userIDs[0].name)
			{
				if(passwordkey == userIDs[0].password)
				{
                    ButtonManager.Instance.ToStart();
					PlayerPrefs.SetString("CurrentUser", currentUser);
                    ScoreUpdate.Instance.LoadScore();
				}
				else
				{
					
					print("passF");
				}

			}
			else
			{
				
				print("userF");

			}
        }
        catch (WebException ex)
        {

        }
       
    }
}
