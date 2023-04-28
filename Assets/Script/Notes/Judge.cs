using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数

    [SerializeField] TextMeshProUGUI comboName;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI maxComboText;
    [SerializeField] TextMeshProUGUI totalScoreText;

    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    // eventSystem型の変数を宣言　
    private EventSystem eventSystem;

    int maxcombo = 0;
    public Camera Camera; //カメラを取得
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    string objectName;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //各値を初期化・非表示
        GManager.instance.combo = 0;
        GManager.instance.score = 0;
        //GManager.instance.StartTime = 0;
        comboText.color = new Color(0, 0, 0, 0);
        comboName.color = new Color(0, 0, 0, 0);

        //フルコンボフラグを立てる
        GManager.instance.fullcombFlg = true;
    }

    public void Update()
    {
        if (0 == notesManager.NotesTime.Count)
        {
            return;
        }

        bool isMouseClick = Input.GetMouseButtonDown(0);

        //デバッグ用　クリック時の座標を取得
        /*
        if (isMouseClick)
        {
            Vector3 mousePosition = Input.mousePosition;

            Debug.Log(mousePosition);
        }
        */

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ; //マウスのポジションを取得してRayに代入
            if(Physics.Raycast(ray,out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                //Debug.Log(objectName); //デバッグ用　オブジェクト名をコンソールに表示
            }
        }

        if (GManager.instance.StartFlg)
        {
            //コンボが０の場合、コンボ表示を消す
            if(GManager.instance.combo == 0)
            {
                comboText.color = new Color(0, 0, 0, 0);
                comboName.color = new Color(0, 0, 0, 0);
            }

            //一番左側のレーンに降ってくるオブジェクトをタッチ時
            if (objectName == "Notes0")
            {
                if (notesManager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
                {
                    //判定処理
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //左から２番目のレーンに降ってくるオブジェクトをタッチ時
            if (objectName == "Notes1")
            {
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //右から２番目のレーンに降ってくるオブジェクトをタッチ時
            if (objectName == "Notes2")
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //一番右側のレーンに降ってくるオブジェクトをタッチ時
            if (objectName == "Notes3")
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (0 == notesManager.NotesTime.Count)
            {
                return;
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData(0);
                //Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                comboText.color = new Color(0, 0, 0, 0);
                comboName.color = new Color(0, 0, 0, 0);
                //ミス

                //フルコンボフラグをfalseに設定、一度ミスするとフラグはfalseのまま
                GManager.instance.fullcombFlg = false;
            }

            objectName = null;
        }
    }
    void Judgement(float timeLag, int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.05)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            //Debug.Log("Perfect");
            message(0);
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.08)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                //Debug.Log("Great");
                message(1);
                GManager.instance.ratioScore += 3;
                GManager.instance.great++;
                GManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    //Debug.Log("Good");
                    message(2);
                    GManager.instance.ratioScore += 1;
                    GManager.instance.good++;
                    GManager.instance.combo++;
                    deleteData(numOffset);
                }
            }

        }

        //最大コンボを退避
        if(maxcombo <= GManager.instance.combo)
        {
            maxcombo = GManager.instance.combo;
        }
        maxComboText.text = maxcombo.ToString();

        //コンボ数を表示
        comboText.color = new Color(255, 255, 0, 255);
        comboName.color = new Color(255, 255, 0, 255);

    }
    float GetABS(float num)//引数の絶対値を返す関数
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData(int numOffset)//すでにたたいたノーツを削除する関数
    {
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);

        //コンボ・スコアを設定
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        totalScoreText.text = GManager.instance.score.ToString();
        EventSystem.current.SetSelectedGameObject(null);


    }

    void message(int judge)//判定を表示する
    {
        float x = 0f;

        //LineA～Dに振り分け
        switch (notesManager.LaneNum[0])
        {
            case 0:
                x = -3.02f; //LineA
                break;
            case 1:
                x = -0.99f; //LineB
                break;
            case 2:
                x = 1.01f; //LineC
                break;
            case 3:
                x = 3.05f; //LineD
                break;
        }

        Instantiate(MessageObj[judge], new Vector3(x, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}