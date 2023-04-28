using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalScoreText : MonoBehaviour
{
    //Scorecounttextを格納する
    public Scoretext TotalScore;

    public TextMeshProUGUI totalscorecounttext;

    //[SerializeField] float openTime = 95.0f;
    float openTime;
    float musicTime;

    // Start is called before the first frame update
    void Start()
    {

        musicTime = Title.musicTime;

        //textの表示タイミング　＝　曲の時間　＋　開始までの時間
        openTime = musicTime + GManager.instance.StartTime;

        //コンポーネントからScorecounttextを検出する
        TotalScore = GameObject.Find("scorecounttext").GetComponent<Scoretext>();

        //オブジェクトを非アクティブにする
        this.gameObject.SetActive(false);
        //曲終了後にOpen関数を実行する
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //textのフォーマットを設定する
        totalscorecounttext.text = string.Format("{0}", TotalScore.Score);

        //オブジェクトをアクティブにする
        this.gameObject.SetActive(true);
    }
}