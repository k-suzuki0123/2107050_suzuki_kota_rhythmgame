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

        //text�̕\���^�C�~���O�@���@�Ȃ̎��ԁ@�{�@�J�n�܂ł̎���
        openTime = musicTime + GManager.instance.StartTime;

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
        //�ȏI�����Open�֐������s����
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //�~�X���O�̏ꍇ�A�t���R���{��\��
        if (GManager.instance.fullcombFlg)
        {
            //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
            this.gameObject.SetActive(true);
        }

    }
}