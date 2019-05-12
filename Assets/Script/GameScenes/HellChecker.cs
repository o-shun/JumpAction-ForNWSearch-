using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HellChecker : MonoBehaviour
{
    public GameObject player;
    GameObject resultWriter; //ゲームオブジェクト「Resultdirector」を収納
    GameObject endSceneDirector; //ゲームオブジェクト「EndSceneDirector」を収納
    bool CheckHell = false; //プレイヤーがゴールに到達したかを判断
    GameObject dataSender; //ゲームオブジェクト「DataSender」を収納

    void Start()
    {
        //Find関数で各オブジェクトの呼び出し
        this.player = GameObject.Find("Player");
        this.resultWriter = GameObject.Find("ResultDirector");
        this.endSceneDirector = GameObject.Find("EndSceneDirector");
        this.dataSender = GameObject.Find("DataSender");
    }

    void Update()
    {
        if (this.CheckHell)
        {
            this.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //プレイヤーの停止
            this.player.GetComponent<PlayerController>().enabled = false; //「PlayerController」の停止(操作不能にする)
            this.resultWriter.GetComponent<ResultWriter>().Result = 2; //ゲームの結果が失敗だった事を「Resultdirector」に通達する
                                                                       
            this.dataSender.GetComponent<NBETester>().GetTryData = "Miss"; //ゲームの結果が失敗だった事を「DataSender」に通達する

            //ボタンを押して進む
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.endSceneDirector.GetComponent<EndSceneSetter>().EndSceneMode = 2; //リザルト後の選択画面を表示
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //タグ「Player」でキャラがゴールにに触れた時を検出する
        if (other.gameObject.CompareTag("Player"))
        {
            this.CheckHell = true;
        }
    }
}
