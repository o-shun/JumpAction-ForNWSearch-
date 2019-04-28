using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController_Level : MonoBehaviour
{
    //キーの現在位置番号
    public int KeyPos = 1; //０…ノーリスクレベル、１…リスクレベル、２…ゲットレベル

    //ステージ選択画面に移行する為のディレクターを収納するオブジェクト
    GameObject KeySetter;

    void Start()
    {
        KeySetter = GameObject.Find("SceneDirector");
    }

    void Update()
    {
        transform.position = new Vector3(0, 12.0f, 0);

        //スペースキーでステージ決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeySetter.GetComponent<Keysetter>().LiveScene = 2;
            KeySetter.GetComponent<Keysetter>().SkipSkillCheck = 1;
        }
    }
}