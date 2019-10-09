using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keysetter : MonoBehaviour
{
    //表示させるオブジェクト
    GameObject Key;
    GameObject StageSelectBack;
    GameObject SkillCheckBack;
    GameObject Description;

    //現在の段階を判断する
    public int LiveScene = 1; //１…レベル選択画、２…ウデマエ確認画面、３…ステージ選択画面、４…ゲームシーンへ飛ぶ

    //選択したスキルレベルを判断
    public int SelectSkill; //０〜４
    public static int SendSkill; //選択したウデマエを各シーンに送る
    public static int SkillInsertChecker = 0; //スキルレベルが既に入力されたかを確認する
    public int SkipSkillCheck = 0; //ウデマエ画面をどうスキップするのかを受け取る。１…レベル選択へ、２…タイトルへ

    //どのステージを選択したかを判断する
    public int SelectStage; //０〜４
    public static int SendStage; //選択した難易度を各シーンに送る

    void Start()
    {
        //各オブジェクトの取得
        Key = GameObject.Find("SelectKey");
        StageSelectBack = GameObject.Find("StageSelectBack");
        SkillCheckBack = GameObject.Find("SkillLevelCheck");
        Description = GameObject.Find("Image");

        //操作説明を最初はオフ
        Description.GetComponent<DescriptionSetter_Title>().DescriptionSet = 0;
    }

    void Update()
    {
        if (LiveScene == 1) //タイトルの設定
        {
            Key.GetComponent<KeyController_Level>().enabled = true;
            Key.GetComponent<KeyController_Skill>().enabled = false;
            Key.GetComponent<KeyController_Stage>().enabled = false;
            StageSelectBack.transform.position = new Vector3(0, 12.0f, 0);
            SkillCheckBack.transform.position = new Vector3(0, -12.0f, 0);
            Description.GetComponent<DescriptionSetter_Title>().DescriptionSet = 0;
            LiveScene = 0;
        }
        if (LiveScene == 2) //ウデマエ確認の設定
        {
            if (SkillInsertChecker != 1)
            {
                Key.GetComponent<KeyController_Level>().enabled = false;
                Key.GetComponent<KeyController_Skill>().enabled = true;
                Key.GetComponent<KeyController_Stage>().enabled = false;
                Key.GetComponent<KeyController_Skill>().KeyPos = 2;
                Key.transform.position = new Vector3(0, -1.0f, 0);
                Key.transform.localScale = new Vector3(0.2f, 0.1f, 0);
                StageSelectBack.transform.position = new Vector3(0, 12.0f, 0);
                SkillCheckBack.transform.position = new Vector3(0, 0.0f, 0);
                Description.GetComponent<DescriptionSetter_Title>().DescriptionSet = 1;
                LiveScene = 0;
            }
            else
            {
                if (SkipSkillCheck == 1)
                    LiveScene = 3;
                if (SkipSkillCheck == 2)
                    LiveScene = 1;
            }

        }
        if (LiveScene == 3) //ステージ選択の設定
        {
            Key.GetComponent<KeyController_Level>().enabled = false;
            Key.GetComponent<KeyController_Skill>().enabled = false;
            Key.GetComponent<KeyController_Stage>().enabled = true;
            Key.transform.localScale = new Vector3(0.2f, 0.1f, 0);
            StageSelectBack.transform.position = new Vector3(0, 0, 0);
            SkillCheckBack.transform.position = new Vector3(0, -12.0f, 0);
            Description.GetComponent<DescriptionSetter_Title>().DescriptionSet = 1;
            LiveScene = 0;
        }
        if (LiveScene == 4) //ゲームシーンへ移行
        {
            SendStage = SelectStage;
            if (SkillInsertChecker != 1)
                SendSkill = SelectSkill;
            SkillInsertChecker = 1;
            SceneManager.LoadScene("RiskLevel");
            LiveScene = 0;
        }
    }

    public static int SkillGetter()
    {
        return SendSkill;
    }

    public static int StageGetter()
    {
        return SendStage;
    }
}
