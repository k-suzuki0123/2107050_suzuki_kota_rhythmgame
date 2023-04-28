using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicboxslide : MonoBehaviour
{
    [SerializeField] public float posz = 0.08f;

    // Update is called once per frame
    void FixedUpdate()
    {

        //トランスフォームの取得
        Transform myTransform = this.transform;

        //座標の取得
        Vector3 pos = myTransform.position;

        //z方向の速度
        pos.z -= posz;

        //座標の設定
        myTransform.position = pos;
    }
}