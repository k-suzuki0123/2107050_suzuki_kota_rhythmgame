using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class Replay : MonoBehaviour

{

    // Start is called before the first frame update

    public void Start()

    {

        //ボタンが押された時、StartReplay関数を実行する

        gameObject.GetComponent<Button>().onClick.AddListener(StartReplay);

    }

    // Update is called once per frame

    void StartReplay()

    {

        //ゲームを初めからスタート

        SceneManager.LoadScene("GameScene");

    }

}