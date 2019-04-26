using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    public int GetStageNumber; //ステージの種類を取得する。難易度

    //ステージ構成に必要なオブジェクト「ゴールの床」を収納
    GameObject Goal;

    void Start()
    {
        //選択されたステージを取得
        GetStageNumber = Keysetter.StageGetter();

        //各オブジェクトを取得
        Goal = GameObject.Find("Goal");

        if (GetStageNumber == 0)
        {
            Goal.transform.position = new Vector3(25.1f, -6.0f, 0);
        }
        if (GetStageNumber == 1)
        {
            Goal.transform.position = new Vector3(25.6f, -6.0f, 0);
        }
        if (GetStageNumber == 2)
        {
            Goal.transform.position = new Vector3(26.1f, -6.0f, 0);
        }
        if (GetStageNumber == 3)
        {
            Goal.transform.position = new Vector3(26.6f, -6.0f, 0);
        }
        if (GetStageNumber == 4)
        {
            Goal.transform.position = new Vector3(26.63f, -6.0f, 0);
        }
    }

    void Update()
    {

    }
}
