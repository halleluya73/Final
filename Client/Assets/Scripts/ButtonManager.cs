using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public GameObject pageLog;
    public GameObject pageCre;
    public GameObject pageLea;

    public GameObject Startbtn;

    public LeaderBoardScript ldb;

    public static ButtonManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ButtonManager>();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    private static ButtonManager instance;
	public void LogToCreate()
    {
        pageLog.SetActive(false);
        pageCre.SetActive(true);

    }

    public  void CreateToLog()
    {
        pageCre.SetActive(false);
        pageLog.SetActive(true);

    }
    public void ToBoard()
    {
        pageLog.SetActive(false);
        pageLea.SetActive(true);
    }
    public void BoardToLog()
    {
        pageLea.SetActive(false);
        pageLog.SetActive(true);
        ldb.DelList();

    }
    public void ToStart()
    {
        Startbtn.SetActive(true);
        pageLog.SetActive(false);
    }
}
