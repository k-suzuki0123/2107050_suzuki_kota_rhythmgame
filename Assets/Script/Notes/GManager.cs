using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public float maxScore;
    public float ratioScore;

    public int songID;
    public float noteSpeed;

    public bool StartFlg;
    public float StartTime;

    public int combo;
    public int score;

    public int perfect;
    public int great;
    public int good;
    public int miss;

    public bool fullcombFlg;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        //maxScore = 0;
        //ratioScore = 0;
        //combo = 0;
        //score = 0;
    }
}