using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextHidden : MonoBehaviour
{
    //[SerializeField] int openTime = 95;
    float openTime;
    float musicTime;

    // Start is called before the first frame update
    void Start()
    {
        musicTime = Title.musicTime;

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