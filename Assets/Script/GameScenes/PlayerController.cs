using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject player;

    public Vector2 PlayerVec; //プレイヤーのベクトルを収納する
    Vector2 PlayerVelo; //プレイヤーの速度を収納する

   　Rigidbody2D rigid2D; //コンポーネント「Rigidbody2D」を収納する

    //X軸
    float PlayerLimit = 10.0f; //プレイヤーの最高速度を収納
    float ForcePower = 10.0f; // 慣性のかかり具合(大きければすぐ最高速に)

    //Y軸
    float JumpForce = 2000.0f; //ジャンプ力を収納する
    bool JumpKeyDown = false; //ジャンプボタンが押されたかを判断する

    //方向キーの入力検出
    public float JoyconHor; //水平方向の検出を収納
    //float JoyconVer; //垂直方向の検出を収納。念のため記載int　

    //フレーム関係
    public int flameCheck_1 = 0;
    public int flameCheck_2 = 0;

    void Start()
    {
        //コンポーネント「Rigidbody2D」取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        //オブジェクト「Player」取得
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        ///水平方向の入力を検出。-１…左移動、1…右移動
        //this.JoyconHor = 1;
        this.JoyconHor = Input.GetAxisRaw("Horizontal"); //水平方向。-１…左移動、1…右移動
        //this.JoyconVer = Input.GetAxis("Vertical1"); //垂直方向。念のため記載

        //経過フレームのカウント用
        //flameCheck_1++;

        //以下物理処理

        if (this.JoyconHor >= 0)
            this.PlayerVelo.x = this.PlayerLimit * this.JoyconHor; //向きを判定

        //ジャンプキーが押された時、Y軸方向に「AddForce」
        //if (JumpKeyDown)
        //{
        //this.rigid2D.AddForce(Vector2.up * this.PlayerVec.y);
        //JumpKeyDown = false;
        //}

        //ジャンプ中じゃない時にできること
        if (this.rigid2D.velocity.y == 0)
        {
            //間隔確認用
            Debug.Log("Update:" + transform.position.x);

            //ジャンプアニメーションに移行
            player.GetComponent<CharacterAnimethion>().AnimationSet = 0;

            //スペースキーでジャンプをする
            //if (player.transform.position.x >= 8.6f && JumpKeyDown == false)
            if (Input.GetKeyDown(KeyCode.Space) && JumpKeyDown == false)
            {
                //ジャンプアニメーションに移行
                player.GetComponent<CharacterAnimethion>().AnimationSet = 4;

                //ジャンプ開始
                //JumpKeyDown = true;

                this.rigid2D.AddForce(Vector2.up * this.PlayerVec.y);
                JumpKeyDown = false;

                //ジャンプ位置確認用
                Debug.Log("JumpPos:" + transform.position.x);

                //ジャンプ時の最高速度を代入(ダッシュ時)
                if ((int)this.rigid2D.velocity.x < -5.0f || (int)this.rigid2D.velocity.x > 5.0f)
                {
                    this.PlayerLimit = Mathf.Abs(rigid2D.velocity.x);
                }
            }
        }

        this.PlayerVec.y = this.JumpForce; //ダッシュ時以外はジャンプ力を統一

        //ダッシュ時に速度が大きいほどでジャンプ力を強くする
        if ((int)this.rigid2D.velocity.x < -5.0f || (int)this.rigid2D.velocity.x > 5.0f)
        {
            var number = (Mathf.Round(Mathf.Abs(this.rigid2D.velocity.x) * 100)) / 100;
            this.PlayerVec.y = Mathf.FloorToInt(this.JumpForce + ((int)number - 5.0f) * 100.0f);
        }

        //ジョイコンの指定した方向に力を加える
        //「moveVector - this.rigid2D.velocity」で、最高速度に近づくたび、かける力を弱くする。「this.ForcePower」で効率の調整。
        this.rigid2D.AddForce(transform.right * this.ForcePower * (this.PlayerVelo - this.rigid2D.velocity));
    }

    //FixedUpdate() → 秒間に呼ばれる回数が一定のUpdate()。Rigidbodyの更新はここでやるのが良い。GetKeyはダメ。
    //void FixedUpdate()
    //{
    //    if (this.rigid2D.velocity.y == 0)
    //    {
    //        間隔確認用
    //    Debug.Log("FixedUpdate:" + transform.position.x);
    //    }

    //    経過フレームのカウント用
    //        flameCheck_2++;
    //}
}