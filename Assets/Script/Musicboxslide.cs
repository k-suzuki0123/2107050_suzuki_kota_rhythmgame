using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicboxslide : MonoBehaviour
{
    [SerializeField] public float posz = 0.08f;

    // Update is called once per frame
    void FixedUpdate()
    {

        //�g�����X�t�H�[���̎擾
        Transform myTransform = this.transform;

        //���W�̎擾
        Vector3 pos = myTransform.position;

        //z�����̑��x
        pos.z -= posz;

        //���W�̐ݒ�
        myTransform.position = pos;
    }
}