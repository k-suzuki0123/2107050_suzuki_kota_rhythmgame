using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class Title : MonoBehaviour

{

    public static string musicName;
    public static float musicTime;

    public void Start()

    {

    }

    // Update is called once per frame

    public void StartStar()

    {
        //GameSceneをロードする
        musicName = "shining-star";
        musicTime = 95;
        SceneManager.LoadScene("GameScene");

    }

    public void StartTokimeki()

    {
        //GameSceneをロードする
        musicName = "ときめき☆ラビリンス";
        musicTime = 140;
        SceneManager.LoadScene("GameScene");

    }

    public void StartTestMusic()

    {
        //GameSceneをロードする
        musicName = "サンタクロースの鈴";
        musicTime = 7;
        SceneManager.LoadScene("GameScene");

    }

}