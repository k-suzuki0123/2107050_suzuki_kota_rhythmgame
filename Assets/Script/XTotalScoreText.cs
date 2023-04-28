using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalScoreText : MonoBehaviour
{
    //Scorecounttext���i�[����
    public Scoretext TotalScore;

    public TextMeshProUGUI totalscorecounttext;

    //[SerializeField] float openTime = 95.0f;
    float openTime;
    float musicTime;

    // Start is called before the first frame update
    void Start()
    {

        musicTime = Title.musicTime;

        //text�̕\���^�C�~���O�@���@�Ȃ̎��ԁ@�{�@�J�n�܂ł̎���
        openTime = musicTime + GManager.instance.StartTime;

        //�R���|�[�l���g����Scorecounttext�����o����
        TotalScore = GameObject.Find("scorecounttext").GetComponent<Scoretext>();

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(false);
        //�ȏI�����Open�֐������s����
        Invoke("Open", openTime);
    }

    //
    void Open()
    {
        //text�̃t�H�[�}�b�g��ݒ肷��
        totalscorecounttext.text = string.Format("{0}", TotalScore.Score);

        //�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        this.gameObject.SetActive(true);
    }
}