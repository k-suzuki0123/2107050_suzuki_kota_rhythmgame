using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    //[SerializeField] float openTime = 95;
    float openTime = 0;
    float musicTime = 0;

    bool tmpStartFlg;

    // Start is called before the first frame update
    void Start()
    {
        tmpStartFlg = false;

        musicTime = Title.musicTime;
        //textの表示タイミング　＝　曲の時間　＋　開始までの時間
        openTime = musicTime + GManager.instance.StartTime;
        //オブジェクトを非アクティブにする
        this.gameObject.SetActive(false);
        //曲終了後にOpen関数を実行する
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //オブジェクトをアクティブにする
        this.gameObject.SetActive(true);
    }
}