﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController_Stage : MonoBehaviour
{
    //キーの現在位置番号
    public int KeyPos = 1; //０…１、１…２、２…３、３…４、４…５(KeyPosの数値 … キーが指してるステージ番号)

    //ジョイコンのスティックの入力検出
    float JoyconHor; //水平方向の検出を収納
    //float JoyconVer; //垂直方向の検出を収納。念のため記載

    //左右それぞれが検出されたかを判断する
    public bool GetDownLeft = false;
    public bool GetDownRight = false;

    //ステージ選択画面に移行する為のディレクターを収納するオブジェクト
    GameObject KeySetter;

    void Start()
    {
        KeySetter = GameObject.Find("SceneDirector");
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
        //this.JoyconVer = Input.GetAxis("Vertical1"); //垂直方向。念のため記載

        //スティックを左に倒した時
        if (this.JoyconHor  < 0 && !GetDownLeft)
        {
            //スティックが左に倒された事を検出
            GetDownLeft = true;

            //ポジション別に位置を移動
            if (this.KeyPos == 0)
            {
                KeyPos = 4;
                transform.position = new Vector3(5.0f, -1.5f, 0);
            }
            else if (this.KeyPos == 1)
            {
                KeyPos = 0;
                transform.position = new Vector3(-5.0f, -1.5f, 0);

            }
            else if (this.KeyPos == 2)
            {
                KeyPos = 1;
                transform.position = new Vector3(-2.55f, -1.5f, 0);
            }
            else if (this.KeyPos == 3)
            {
                KeyPos = 2;
                transform.position = new Vector3(0, -1.5f, 0);

            }
            else if (this.KeyPos == 4)
            {
                KeyPos = 3;
                transform.position = new Vector3(2.55f, -1.5f, 0);
            }
        }

        //スティックを右に倒した時
        if (this.JoyconHor  > 0 && !GetDownRight)
        {
            //スティックが右に倒された事を検出
            GetDownRight = true;

            //ポジション別に位置を移動
            if (this.KeyPos == 0)
            {
                KeyPos =1;
                transform.position = new Vector3(-2.55f, -1.5f, 0);
            }
            else if (this.KeyPos == 1)
            {
                KeyPos = 2;
                transform.position = new Vector3(0, -1.5f, 0);
            }
            else if (this.KeyPos == 2)
            {
                KeyPos = 3;
                transform.position = new Vector3(2.55f, -1.5f, 0);
            }
            else if (this.KeyPos == 3)
            {
                KeyPos = 4;
                transform.position = new Vector3(5.0f, -1.5f, 0);

            }
            else if (this.KeyPos == 4)
            {
                KeyPos = 0;
                transform.position = new Vector3(-5.0f, -1.5f, 0);
            }
        }

        //スティックが降ろされていないかを検出
        if(this.JoyconHor == 0)
        {
            GetDownLeft = false;
            GetDownRight = false;
        }

        //Zキーで難易度決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeySetter.GetComponent<Keysetter>().SelectStage = this.KeyPos;
            KeySetter.GetComponent<Keysetter>().LiveScene = 3;
        }

        //Xキーでレベル選択に戻る
        if (Input.GetKey(KeyCode.X))
        {
            KeySetter.GetComponent<Keysetter>().LiveScene = 1;
        }
    }
}