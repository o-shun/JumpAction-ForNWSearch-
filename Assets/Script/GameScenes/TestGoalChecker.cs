using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGoalChecker : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //タグ「Player」でキャラがゴールにに触れた時を検出する
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Break();
        }
    }
}
