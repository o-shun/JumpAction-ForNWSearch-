using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndKeyController_3 : MonoBehaviour
{
    //ゲームオブジェクト「EndSceneDirector」を収納
    GameObject endSceneDirector;

    //ゲームオブジェクト「DataSender」を収納
    GameObject dataSender;

    //キーの現在位置番号
    public int KeyPos = 0; //０…１、１…２、２…３、３…４、４…５、５…６、６…７(KeyPosの数値 … キーが指してる番号)

    //十字キーの入力検出
    float JoyconHor;

    //左右それぞれが検出されたかを判断する
    public bool GetDownLeft = false;
    public bool GetDownRight = false;

    //アンケート回答を各シーンに送る
    public static int SendAnswer;

    void Start()
    {
        //Find関数でオブジェクトの呼び出し
        this.endSceneDirector = GameObject.Find("EndSceneDirector");
        this.dataSender = GameObject.Find("DataSender");

        //キーのポジションを真ん中に設定
        KeyPos = 3;
    }

    void Update()
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
                KeyPos = 6;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 10.902f, pos.y, pos.z);
            }

            else if (this.KeyPos == 1)
            {
                KeyPos = 0;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 2)
            {
                KeyPos = 1;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
            }

            else if (this.KeyPos == 3)
            {
                KeyPos = 2;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 4)
            {
                KeyPos = 3;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
            }

            else if (this.KeyPos == 5)
            {
                KeyPos = 4;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 6)
            {
                KeyPos = 5;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 1.817f, pos.y, pos.z);
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
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }

            else if (this.KeyPos == 1)
            {
                KeyPos = 2;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 2)
            {
                KeyPos = 3;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }

            else if (this.KeyPos == 3)
            {
                KeyPos = 4;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 4)
            {
                KeyPos = 5;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }

            else if (this.KeyPos == 5)
            {
                KeyPos = 6;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x + 1.817f, pos.y, pos.z);
            }
            else if (this.KeyPos == 6)
            {
                KeyPos = 0;
                Vector3 pos = transform.position;
                this.gameObject.transform.position = new Vector3(pos.x - 10.902f, pos.y, pos.z);
            }
        }

        //スティックが降ろされていないかを検出
        if (this.JoyconHor == 0)
        {
            GetDownLeft = false;
            GetDownRight = false;
        }

        this.dataSender.GetComponent<NBETester>().GetAnswer = KeyPos + 1; //選択したアンケート回答を送信

        //スペースキーで決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //データを送信する指示を通達する
            this.dataSender.GetComponent<NBETester>().SendChecker = 1;
            this.dataSender.GetComponent<NBETester>().SendStoper2 = 1;
            endSceneDirector.GetComponent<EndSceneSetter>().EndSceneMode = 4;
        }
    }
}
