using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class BackTitle : MonoBehaviour

{

    // Start is called before the first frame update

    public void Start()

    {

        //ボタンが押された時、BackTitle関数を実行する

        gameObject.GetComponent<Button>().onClick.AddListener(Back);

    }

    // Update is called once per frame

    void Back()

    {

        //Titleをロードする

        SceneManager.LoadScene("Title");

    }

}