
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHidden : MonoBehaviour
{
    //[SerializeField] float openTime = 95.0f;
    float openTime;
    float musicTime;

    // Start is called before the first frame update
    void Start()
    {

        musicTime = Title.musicTime;

        //textの表示タイミング　＝　曲の時間　＋　開始までの時間
        openTime = musicTime + GManager.instance.StartTime;

        //オブジェクトを非アクティブにする
        this.gameObject.SetActive(true);
        //曲終了後にOpen関数を実行する
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //オブジェクトをアクティブにする
        this.gameObject.SetActive(false);
    }
}