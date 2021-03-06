﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class NBETester : MonoBehaviour
{
    public string GetPlayerID; //プレイヤーの意開始時刻を取得する
    public int GetSkillLevel; //プレイヤーが選択したスキルレベルを取得する
    public int GetStageNumber; //ステージの種類を取得する
    public string GetTryData; //プレイヤーが成功したか失敗したかを取得する
    public int GetAnswer = 0; //プレイヤーのアンケート結果を取得する。０の場合はアンケート対象外

    public int SendChecker = 0;
    int SendStoper = 0;
    public int SendStoper2 = 0;

    void Start()
    {
        //プレイヤーのIDを取得
        GetPlayerID = IDSetter.IDGetter();
        //プレイヤーのスキルレベルを取得
        GetSkillLevel = Keysetter.SkillGetter();
        //選択されたステージを取得
        GetStageNumber = Keysetter.StageGetter();
    }

    void Update()
    {
        if (SendChecker == 1 && SendStoper == 0)
        {
            SendStoper = 1;

            // クラスのNCMBObjectを作成
            NCMBObject testClass = new NCMBObject("TestClass");

            //スキルレベルを送信用に変換
            GetSkillLevel++;
            //ステージナンバーを送信用に変更
            GetStageNumber++;

            // オブジェクトに値を設定
            testClass["message"] = "ID「" + GetPlayerID + "」SkillLevel:" + GetSkillLevel + ", Stage" + GetStageNumber + ":" + GetTryData + ", Answer:" + GetAnswer;

            // データストアへの登録
            testClass.SaveAsync();
        }

        if(SendChecker == 1 && SendStoper2 == 1)
        {
            SendStoper2 = 2;

            // クラスのNCMBObjectを作成
            NCMBObject testClass = new NCMBObject("TestClass");

            // オブジェクトに値を設定
            testClass["message"] = "ID「" + GetPlayerID + "」SkillLevel:" + GetSkillLevel + ", Stage" + GetStageNumber + ":NoSuccessEnd, Answer:" + GetAnswer;

            // データストアへの登録
            testClass.SaveAsync();
        }

    }
}