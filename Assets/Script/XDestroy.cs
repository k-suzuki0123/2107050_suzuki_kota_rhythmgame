using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //�Փ˂�����
    private void OnCollisionEnter(Collision collision)
    {
        //"resetbox"�^�O�ɏՓ˂����ꍇ
        if (collision.gameObject.tag == "resetbox")
        {
            //�I�u�W�F�N�g��������
            Destroy(this.gameObject);
        }
    }
}