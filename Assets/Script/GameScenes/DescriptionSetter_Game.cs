using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionSetter_Game : MonoBehaviour 
{
    //２つの説明画面オブジェクトを収納
    GameObject Description1;
    GameObject Description2;

    //操作説明の切り替えを確認する。０…ゲーム用、１…ゲーム終了時用
    public int DescriptionChange = 0;

    void Start()
    {
        this.Description1 = GameObject.Find("Description1");
        this.Description2 = GameObject.Find("Description2");
    }


    void Update () 
    {
        if (DescriptionChange == 0)
        {
            Description1.GetComponent<UnityEngine.UI.Image>().enabled = true;
            Description2.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        if (DescriptionChange == 1)
        {
            Description1.GetComponent<UnityEngine.UI.Image>().enabled = false;
            Description2.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
    }
}
