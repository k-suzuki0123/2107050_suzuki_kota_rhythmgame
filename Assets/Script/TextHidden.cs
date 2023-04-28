
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHidden : MonoBehaviour
{
    //[SerializeField] float openTime = 95.0f;
    float openTime;
    float musicTime;

    // Start is called before the first frame update
    void Start()
    {

        musicTime = Title.musicTime;

        //text�̕\���^�C�~���O�@���@�Ȃ̎��ԁ@�{�@�J�n�܂ł̎���
        openTime = musicTime + GManager.instance.StartTime;

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(true);
        //�ȏI�����Open�֐������s����
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
    }
}