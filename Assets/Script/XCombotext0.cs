using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combotext0 : MonoBehaviour
{
    //�R���{���Z������text�ƕR�t����
    //public float Combo;
    public TextMeshProUGUI combocounttext;

    //�R���{��Combotext���A�^�b�`���Ă���combocounttext���i�[����
    public Combotext Nowcombo;

    //public Text NowComboText;

    //Combotext�ɃA�N�Z�X���Ď��s����
    internal static void SetCombotext0()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g����combocounttext�����o����
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