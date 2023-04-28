using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combotext : MonoBehaviour
{
    //コンボ加算したいtextと紐付ける
    public float Combo;
    public float MaxCombo;
    public TextMeshProUGUI combocounttext;
    public TextMeshProUGUI maxcombocounttext;

    //Combotextにアクセスして実行する
    internal static void SetCombotext()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //0からスタートする
        Combo = 0;
        MaxCombo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //textのフォーマットを設定する
        combocounttext.text = string.Format("{0}", Combo);

        //最大コンボを退避
        if(MaxCombo < Combo)
        {
            MaxCombo = Combo;
        }

        //textのフォーマットを設定する
        maxcombocounttext.text = string.Format("{0}", MaxCombo);
    }
}