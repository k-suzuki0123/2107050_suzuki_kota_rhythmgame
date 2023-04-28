using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxComboText : MonoBehaviour
{
    //combocounttextを格納する
    public Combotext MaxCombo;

    public TextMeshProUGUI maxcombocounttext;

    //[SerializeField] float openTime = 95.0f;
    float openTime = 0;
    float musicTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicTime = Title.musicTime;

        //textの表示タイミング　＝　曲の時間　＋　開始までの時間
        openTime = musicTime + GManager.instance.StartTime;
        //コンポーネントからcombocounttextを検出する
        MaxCombo = GameObject.Find("maxcombocounttext").GetComponent<Combotext>();

        //オブジェクトを非アクティブにする
        this.gameObject.SetActive(false);
        //曲終了後にOpen関数を実行する
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //textのフォーマットを設定する
        maxcombocounttext.text = string.Format("{0}", MaxCombo.MaxCombo);

        //オブジェクトをアクティブにする
        this.gameObject.SetActive(true);
    }
}