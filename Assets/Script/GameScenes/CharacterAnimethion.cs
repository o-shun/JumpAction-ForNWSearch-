using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimethion : MonoBehaviour
{
    //アニメーション番号を収納する
    int SpriteSetter;

    //アニメループを決定。０…走行、４…ジャンプ、９…着地
    public int AnimationSet = 0;

    //Playerのスプライトを渡す
    SpriteRenderer MainSpriteRenderer;

    //アニメーションを入れる。アナログ的に手動で入れましょう
    public Sprite[] image = new Sprite[10];

    void Start()
    {
        //Playerのスプライトを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //アニメーション番号を現在位置から決定
        SpriteSetter = (int)Mathf.Abs(Mathf.Floor(gameObject.transform.position.x * 2 % 4));

        //アニメーションループの状態をセット
        if (SpriteSetter != 4)
        {
            if (AnimationSet == 0)
                MainSpriteRenderer.sprite = image[SpriteSetter];
            else if (AnimationSet == 4)
                MainSpriteRenderer.sprite = image[SpriteSetter + AnimationSet];
            else if (AnimationSet == 9)
                MainSpriteRenderer.sprite = image[AnimationSet];
            if (gameObject.transform.position.y < -3.75)
                MainSpriteRenderer.sprite = image[8];
        }
    }
}
