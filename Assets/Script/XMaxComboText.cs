using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxComboText : MonoBehaviour
{
    //combocounttext���i�[����
    public Combotext MaxCombo;

    public TextMeshProUGUI maxcombocounttext;

    //[SerializeField] float openTime = 95.0f;
    float openTime = 0;
    float musicTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicTime = Title.musicTime;

        //text�̕\���^�C�~���O�@���@�Ȃ̎��ԁ@�{�@�J�n�܂ł̎���
        openTime = musicTime + GManager.instance.StartTime;
        //�R���|�[�l���g����combocounttext�����o����
        MaxCombo = GameObject.Find("maxcombocounttext").GetComponent<Combotext>();

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
        //�ȏI�����Open�֐������s����
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //text�̃t�H�[�}�b�g��ݒ肷��
        maxcombocounttext.text = string.Format("{0}", MaxCombo.MaxCombo);

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(true);
    }
}