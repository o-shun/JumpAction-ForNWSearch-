using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{ 
    GameObject player; //ゲームオブジェクト「Player」を収納
    GameObject resultWriter; //ゲームオブジェクト「Resultdirector」を収納
    GameObject endSceneDirector; //ゲームオブジェクト「EndSceneDirector」を収納
    GameObject dataSender; //ゲームオブジェクト「DataSender」を収納
    GameObject descriptionDirector; //ゲームオブジェクト「DescriptionDirector」を収納

    bool CheckGoal = false; //プレイヤーがゴールに到達したかを判断
    bool PlayerStop = false; //プレイヤーが停止したかを判断
    public bool GetItem = false; //アイテム取得がされたかを「GetChecker」から受け取る

    void Start()
    {
        //Find関数で各オブジェクトの呼び出し
        this.player = GameObject.Find("Player");
        this.resultWriter = GameObject.Find("ResultDirector");
        this.endSceneDirector = GameObject.Find("EndSceneDirector");
        this.dataSender = GameObject.Find("DataSender");
        this.descriptionDirector = GameObject.Find("DescriptionDirector");
    }

    void Update()
    {
        //プレイヤーがゴールした時
        if (this.CheckGoal)
        {
            if (!this.PlayerStop)
            {
                Debug.Log(this.player.transform.position.x);
                this.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //プレイヤーの停止
                PlayerStop = true;
            }
            this.player.GetComponent<PlayerController>().enabled = false; //「PlayerController」の停止(操作不能にする)

            //ゲームの結果が成功だった事を「Resultdirector」に通達する
            this.resultWriter.GetComponent<ResultWriter>().Result = 1;
            this.dataSender.GetComponent<NBETester>().GetTryData = "Success"; //ゲームの結果が成功だった事を「DataSender」に通達する

            //着地アニメーションに移行
            player.GetComponent<CharacterAnimethion>().AnimationSet = 9;

            //ボタンを押して進む
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.descriptionDirector.GetComponent<DescriptionSetter_Game>().DescriptionChange = 1;
                this.endSceneDirector.GetComponent<EndSceneSetter>().EndSceneMode = 1 ; //リザルト後の選択画面を表示
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //タグ「Player」でキャラがゴールにに触れた時を検出する
        if (other.gameObject.CompareTag("Player"))
        {
            this.CheckGoal = true;
        }
    }
}
