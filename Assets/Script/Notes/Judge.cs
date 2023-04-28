using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    //�ϐ��̐錾
    [SerializeField] private GameObject[] MessageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    [SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�

    [SerializeField] TextMeshProUGUI comboName;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI maxComboText;
    [SerializeField] TextMeshProUGUI totalScoreText;

    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    // eventSystem�^�̕ϐ���錾�@
    private EventSystem eventSystem;

    int maxcombo = 0;
    public Camera Camera; //�J�������擾
    private RaycastHit hit; //���C�L���X�g�������������̂��擾������ꕨ
    string objectName;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //�e�l���������E��\��
        GManager.instance.combo = 0;
        GManager.instance.score = 0;
        //GManager.instance.StartTime = 0;
        comboText.color = new Color(0, 0, 0, 0);
        comboName.color = new Color(0, 0, 0, 0);

        //�t���R���{�t���O�𗧂Ă�
        GManager.instance.fullcombFlg = true;
    }

    public void Update()
    {
        if (0 == notesManager.NotesTime.Count)
        {
            return;
        }

        bool isMouseClick = Input.GetMouseButtonDown(0);

        //�f�o�b�O�p�@�N���b�N���̍��W���擾
        /*
        if (isMouseClick)
        {
            Vector3 mousePosition = Input.mousePosition;

            Debug.Log(mousePosition);
        }
        */

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ; //�}�E�X�̃|�W�V�������擾����Ray�ɑ��
            if(Physics.Raycast(ray,out hit))  //�}�E�X�̃|�W�V��������Ray�𓊂��ĉ����ɓ���������hit�ɓ����
            {
                objectName = hit.collider.gameObject.name; //�I�u�W�F�N�g�����擾���ĕϐ��ɓ����
                //Debug.Log(objectName); //�f�o�b�O�p�@�I�u�W�F�N�g�����R���\�[���ɕ\��
            }
        }

        if (GManager.instance.StartFlg)
        {
            //�R���{���O�̏ꍇ�A�R���{�\��������
            if(GManager.instance.combo == 0)
            {
                comboText.color = new Color(0, 0, 0, 0);
                comboName.color = new Color(0, 0, 0, 0);
            }

            //��ԍ����̃��[���ɍ~���Ă���I�u�W�F�N�g���^�b�`��
            if (objectName == "Notes0")
            {
                if (notesManager.LaneNum[0] == 0)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
                {
                    //���菈��
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //������Q�Ԗڂ̃��[���ɍ~���Ă���I�u�W�F�N�g���^�b�`��
            if (objectName == "Notes1")
            {
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //�E����Q�Ԗڂ̃��[���ɍ~���Ă���I�u�W�F�N�g���^�b�`��
            if (objectName == "Notes2")
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            //��ԉE���̃��[���ɍ~���Ă���I�u�W�F�N�g���^�b�`��
            if (objectName == "Notes3")
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (0 == notesManager.NotesTime.Count)
            {
                return;
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//�{���m�[�c���������ׂ����Ԃ���0.2�b�����Ă����͂��Ȃ������ꍇ
            {
                message(3);
                deleteData(0);
                //Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                comboText.color = new Color(0, 0, 0, 0);
                comboName.color = new Color(0, 0, 0, 0);
                //�~�X

                //�t���R���{�t���O��false�ɐݒ�A��x�~�X����ƃt���O��false�̂܂�
                GManager.instance.fullcombFlg = false;
            }

            objectName = null;
        }
    }
    void Judgement(float timeLag, int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.05)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.1�b�ȉ���������
        {
            //Debug.Log("Perfect");
            message(0);
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.08)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.15�b�ȉ���������
            {
                //Debug.Log("Great");
                message(1);
                GManager.instance.ratioScore += 3;
                GManager.instance.great++;
                GManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.10)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.2�b�ȉ���������
                {
                    //Debug.Log("Good");
                    message(2);
                    GManager.instance.ratioScore += 1;
                    GManager.instance.good++;
                    GManager.instance.combo++;
                    deleteData(numOffset);
                }
            }

        }

        //�ő�R���{��ޔ�
        if(maxcombo <= GManager.instance.combo)
        {
            maxcombo = GManager.instance.combo;
        }
        maxComboText.text = maxcombo.ToString();

        //�R���{����\��
        comboText.color = new Color(255, 255, 0, 255);
        comboName.color = new Color(255, 255, 0, 255);

    }
    float GetABS(float num)//�����̐�Βl��Ԃ��֐�
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData(int numOffset)//���łɂ��������m�[�c���폜����֐�
    {
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);

        //�R���{�E�X�R�A��ݒ�
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        totalScoreText.text = GManager.instance.score.ToString();
        EventSystem.current.SetSelectedGameObject(null);


    }

    void message(int judge)//�����\������
    {
        float x = 0f;

        //LineA�`D�ɐU�蕪��
        switch (notesManager.LaneNum[0])
        {
            case 0:
                x = -3.02f; //LineA
                break;
            case 1:
                x = -0.99f; //LineB
                break;
            case 2:
                x = 1.01f; //LineC
                break;
            case 3:
                x = 3.05f; //LineD
                break;
        }

        Instantiate(MessageObj[judge], new Vector3(x, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}