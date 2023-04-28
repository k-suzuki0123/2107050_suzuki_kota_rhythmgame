using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combotext0 : MonoBehaviour
{
    //コンボ加算したいtextと紐付ける
    //public float Combo;
    public TextMeshProUGUI combocounttext;

    //コンボやCombotextをアタッチしているcombocounttextを格納する
    public Combotext Nowcombo;

    //public Text NowComboText;

    //Combotextにアクセスして実行する
    internal static void SetCombotext0()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントからcombocounttextを検出する
        Nowcombo = GameObject.Find("combocounttext").GetComponent<Combotext>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Nowcombo.Combo);
        if (Nowcombo.Combo == 0)
        {
            combocounttext.color = new Color(0, 0, 0, 0);
        }
        else
        {
            combocounttext.color = new Color(255, 255, 0, 255);
        }

    }
}