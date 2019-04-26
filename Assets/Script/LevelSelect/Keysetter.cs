﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keysetter : MonoBehaviour
{
    //表示させるオブジェクト
    GameObject Key;
    GameObject StageSelectBack;

    //現在の段階を判断する
    public int LiveScene = 0; //１…レベル選択画、２…ステージ選択画面、３…SelectSceneを参照して、指定されたシーンへ飛ぶ

    //どのステージを選択したかを判断する
    public int SelectStage; //０〜４
    public static int SendStage; //選択した難易度を各シーンに送る

    void Start()
    {
        Key = GameObject.Find("SelectKey"); 　
        StageSelectBack = GameObject.Find("StageSelectBack");
    }

    void Update()
    {
        if (LiveScene == 1)
        {
            Key.GetComponent<KeyController_Level>().enabled = true;
            Key.GetComponent<KeyController_Stage>().enabled = false;
            StageSelectBack.transform.position = new Vector3(0, 12.0f, 0);
            LiveScene = 0;
        }

        if (LiveScene == 2)
        {
            Key.GetComponent<KeyController_Level>().enabled = false;
            Key.GetComponent<KeyController_Stage>().enabled = true;
            Key.GetComponent<KeyController_Stage>().KeyPos = 2;
            Key.transform.position = new Vector3(0, -1.5f, 0);
            Key.transform.localScale = new Vector3(0.2f, 0.1f, 0);
            StageSelectBack.transform.position = new Vector3(0, 0, 0);
            LiveScene = 0;
        }

        if (LiveScene == 3)
        {
            SendStage = SelectStage;
            SceneManager.LoadScene("RiskLevel");
            LiveScene = 0;
        }
    }

    public static int StageGetter()
    {
        return SendStage;
    }
}
