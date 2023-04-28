using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    //[SerializeField] float openTime = 95;
    float openTime = 0;
    float musicTime = 0;

    bool tmpStartFlg;

    // Start is called before the first frame update
    void Start()
    {
        tmpStartFlg = false;

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
        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(true);
    }
}