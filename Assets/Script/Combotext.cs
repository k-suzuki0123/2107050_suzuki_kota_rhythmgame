using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combotext : MonoBehaviour
{
    //�R���{���Z������text�ƕR�t����
    public float Combo;
    public float MaxCombo;
    public TextMeshProUGUI combocounttext;
    public TextMeshProUGUI maxcombocounttext;

    //Combotext�ɃA�N�Z�X���Ď��s����
    internal static void SetCombotext()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //0����X�^�[�g����
        Combo = 0;
        MaxCombo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //text�̃t�H�[�}�b�g��ݒ肷��
        combocounttext.text = string.Format("{0}", Combo);

        //�ő�R���{��ޔ�
        if(MaxCombo < Combo)
        {
            MaxCombo = Combo;
        }

        //text�̃t�H�[�}�b�g��ݒ肷��
        maxcombocounttext.text = string.Format("{0}", MaxCombo);
    }
}