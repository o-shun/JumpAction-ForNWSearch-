using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDSetter : MonoBehaviour
{
    //IDが取得された事を確認する
    public static int IDChecker;
    //取得したIDを各シーンに送る
    public static string SendID;

    void Start()
    {
        //IDがすでにある場合は生成せず
        if (IDChecker != 1)
        {
            //ID生成を確認
            IDChecker = 1;

            //現在時間を取得
            int HH = System.DateTime.Now.Hour;
            int MM = System.DateTime.Now.Minute;
            int SS = System.DateTime.Now.Second;
            int CC = System.DateTime.Now.Millisecond;

            //SendIDに現在時間をIDとして収納
            SendID = (HH).ToString() + ":" + (MM).ToString() + ":" + (SS).ToString() + "." + (CC).ToString();
        }
    }

    public static string IDGetter()
    {
        return SendID;
    }
}
