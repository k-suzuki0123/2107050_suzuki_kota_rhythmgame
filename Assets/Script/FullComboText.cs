using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullComboText : MonoBehaviour
{

    //[SerializeField] float openTime = 95.0f;
    float openTime = 0;
    float musicTime = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        //ミスが０の場合、フルコンボを表示
        if (GManager.instance.fullcombFlg)
        {
            //オブジェクトをアクティブにする
            this.gameObject.SetActive(true);
        }

    }
}