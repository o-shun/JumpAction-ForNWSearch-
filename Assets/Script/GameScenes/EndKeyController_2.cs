using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndKeyController_2 : MonoBehaviour 
{

    GameObject endSceneDirector; //ゲームオブジェク「EndSceneDirector」を収納
    GameObject dataSender; //ゲームオブジェクト「DataSender」を収納

    //キーの現在位置番号
    public int KeyPos = 0; //０…もう１度プレイ、１…タイトルに戻る(KeyPosの数値 … キーが指してるステージ番号)

    //十字キーの入力検出
    float JoyconHor;

    //左右それぞれが検出されたかを判断する
    public bool GetDownLeft = false;
    public bool GetDownRight = false;

    void Start () 
    {
        //Find関数でオブジェクトの呼び出し
        this.dataSender = GameObject.Find("DataSender");
        this.endSceneDirector = GameObject.Find("EndSceneDirector");

        //データを送信する指示を通達する
        this.dataSender.GetComponent<NBETester>().SendChecker = 1;
    }

	void Update () 
    {
        //水平方向の入力確認。-１…左移動、1…右移動
        if (Input.GetKey(KeyCode.LeftArrow)) 
        { 
            this.JoyconHor = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.JoyconHor = 1;
        }
        else 
        {
            this.JoyconHor = 0;
        }

        //スティックを左に倒した時
        if (this.JoyconHor < 0 && !GetDownLeft)
        {
            //スティックが左に倒された事を検出
            GetDownLeft = true;

            //ポジション別に位置を移動
            if (this.KeyPos == 0)
            {
                KeyPos = 1;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 4.7f, pos.y, pos.z);
            }

            else if (this.KeyPos == 1)
            {
                KeyPos = 0;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 4.7f, pos.y, pos.z);
            }
        }

        //スティックを右に倒した時
        if (this.JoyconHor > 0 && !GetDownRight)
        {
            //スティックが右に倒された事を検出
            GetDownRight = true;

            //ポジション別に位置を移動
            if (this.KeyPos == 0)
            {
                KeyPos = 1;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 4.7f, pos.y, pos.z);
            }

            else if (this.KeyPos == 1)
            {
                KeyPos = 0;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 4.7f, pos.y, pos.z);
            }
        }

        //スティックが降ろされていないかを検出
        if (this.JoyconHor == 0)
        {
            GetDownLeft = false;
            GetDownRight = false;
        }

        //ジョイコン↓ボタンで難易度決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.KeyPos == 0) //「もう１度プレイ」を選択した時
            {
                SceneManager.LoadScene("RiskLevel");
            }
            else if (this.KeyPos == 1) //「タイトルに戻る」を選択した時
            {
                endSceneDirector.GetComponent<EndSceneSetter>().EndSceneMode = 3;
            }
        }
    }
}
