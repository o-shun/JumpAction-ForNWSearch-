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
            Goal.transform.position = new Vector3(25.0f, -6.0f, 0);
        }
        if (GetStageNumber == 1)
        {
            Goal.transform.position = new Vector3(25.5f, -6.0f, 0);
        }
        if (GetStageNumber == 2)
        {
            Goal.transform.position = new Vector3(26.5f, -6.0f, 0);
        }
        if (GetStageNumber == 3)
        {
            Goal.transform.position = new Vector3(27.0f, -6.0f, 0);
        }
        if (GetStageNumber == 4)
        {
            Goal.transform.position = new Vector3(27.118f, -6.0f, 0);
            //Goal.transform.position = new Vector3(26.6040735244750994999999999999999999999999999999999999999999999999999999999999999999f, -6.0f, 0);
            //Goal.transform.position = new Vector3(26.6040735244750994751f, -6.0f, 0);
        }
    }

    void Update()
    {

    }
}
