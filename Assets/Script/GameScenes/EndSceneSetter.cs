using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneSetter : MonoBehaviour
{
    //表示させるオブジェクト
    GameObject Key;
    GameObject EndGameSelect_1;
    GameObject EndGameSelect_2;
    GameObject EndGameSelect_3;

    //位置を決めるために取得
    GameObject Camera;

    public int EndSceneMode = 0; //ゲーム終了時の画面の種類を判別する
    float WritePos = 0; //リザルトを描画するX軸ポジションを収納

    //ステージの種類を収納する
    public int GetStageNumber;

    //アンケートが既に入力されたかを確認する
    public static int[] AnswerInsertChecker = new int[5] { 0, 0, 0, 0, 0 };

    //１度でも成功があったかを検出 ０…未クリア、１…クリア済み、２…未クリアかつアンケート記入済み
    public static int[] AnswerInsertChecker2 = new int[5] { 1, 1, 1, 1, 1 };

    void Start()
    {
        //各オブジェクトを取得
        Key = GameObject.Find("SelectKey");
        EndGameSelect_1 = GameObject.Find("Questionnaire");
        EndGameSelect_2 = GameObject.Find("EndGameSelect_2");
        EndGameSelect_3 = GameObject.Find("Questionnaire2");
        Camera = GameObject.Find("Main Camera");

        //ステージの種類を取得
        GetStageNumber = Keysetter.StageGetter();
    }

    void Update()
    {
        //ゲームが終了し、リザルト後の選択画面に入った時
        if (EndSceneMode != 0)
        {
            //描画の中心になるX軸をカメラ位置から取得
            WritePos = Camera.transform.position.x;

            //成功後のアンケート画面へ移行
            if (EndSceneMode == 1) 
            {
                if (AnswerInsertChecker[GetStageNumber] != 1)
                {
                    AnswerInsertChecker[GetStageNumber] = 1;
                    AnswerInsertChecker2[GetStageNumber] = 1;
                    Key.GetComponent<EndKeyController_1>().enabled = true;
                    Key.GetComponent<EndKeyController_2>().enabled = false;
                    Key.GetComponent<EndKeyController_3>().enabled = false;
                    Key.transform.position = new Vector3(WritePos, -1.40f, 0);
                    Key.transform.localScale = new Vector3(0.15f, 0.1f, 0);
                    EndGameSelect_1.transform.position = new Vector3(WritePos, 0, 0);
                    EndGameSelect_1.transform.localScale = new Vector3(1.1f, 1.2f, 0);
                    EndGameSelect_2.transform.position = new Vector3(0, 12.0f, 0);
                    EndGameSelect_3.transform.position = new Vector3(0, -22.0f, 0);
                    EndSceneMode = 0;
                }
                else
                {
                    EndSceneMode = 2;
                }
            }

            //リザルト後の選択画面のセット
            if (EndSceneMode == 2)
            {
                Key.GetComponent<EndKeyController_1>().enabled =false;
                Key.GetComponent<EndKeyController_2>().enabled = true;
                Key.GetComponent<EndKeyController_3>().enabled = false;
                Key.transform.position = new Vector3(WritePos - 2.55f, -1.25f, 0);
                Key.transform.localScale = new Vector3(0.3f, 0.2f, 0);
                EndGameSelect_1.transform.position = new Vector3(0, -12.0f, 0);
                EndGameSelect_2.transform.position = new Vector3(WritePos, 0, 0);
                EndGameSelect_2.transform.localScale = new Vector3(1.1f, 1.2f, 0);
                EndGameSelect_3.transform.position = new Vector3(0, -22.0f, 0);
                EndSceneMode = 0;
            }

            //リザルト後の選択画面のセット
            if (EndSceneMode == 3)
            {
                if (AnswerInsertChecker[GetStageNumber] == 0)
                {
                    AnswerInsertChecker2[GetStageNumber] = 2;
                    Key.GetComponent<EndKeyController_1>().enabled = false;
                    Key.GetComponent<EndKeyController_2>().enabled = false;
                    Key.GetComponent<EndKeyController_3>().enabled = true;
                    Key.transform.position = new Vector3(WritePos, -1.40f, 0);
                    Key.transform.localScale = new Vector3(0.15f, 0.1f, 0);
                    EndGameSelect_1.transform.position = new Vector3(0, -12.0f, 0);
                    EndGameSelect_2.transform.position = new Vector3(0, 12.0f, 0);
                    EndGameSelect_3.transform.position = new Vector3(WritePos, 0, 0);
                    EndGameSelect_3.transform.localScale = new Vector3(1.1f, 1.2f, 0);
                    EndSceneMode = 0;
                }
                else
                    SceneManager.LoadScene("LevelSelect");
            }

            if (EndSceneMode == 4)
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }


}
