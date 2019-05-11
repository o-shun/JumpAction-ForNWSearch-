using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionWriter_Game : MonoBehaviour
{
    //カメラのオブジェクトを収納
    GameObject camera;

    //操作説明のオブジェクトをそれぞれ収納
    GameObject description;
    GameObject description2;

    //操作説明を変更
    public int WriteChange = 1; //１…ゲーム画面用、２、ゲーム終了用

    void Start()
    {
        //Find関数で各オブジェクトの呼び出し
        this.camera = GameObject.Find("Main Camera");
        this.description = GameObject.Find("Description");
        this.description2 = GameObject.Find("Description2");
    }

    void Update()
    {
        if (WriteChange == 1)
        {
            description.transform.position = new Vector3(camera.transform.position.x + 5.2f, 5.51f, 0);
            description2.transform.position = new Vector3(-5.0f, 16.45f, 0);
        }
        if (WriteChange == 2)
        {
            description.transform.position = new Vector3(-4.5f, 16.45f, 0);
            description2.transform.position = new Vector3(camera.transform.position.x + 5.75f, 5.51f, 0);
        }
    }
}
