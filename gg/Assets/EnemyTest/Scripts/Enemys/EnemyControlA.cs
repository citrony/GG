using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlA : MonoBehaviour
{
    //public GameObject EnemyBullet;
    public GameObject Explosion;
    public GameObject ScoreMotion40;
    GameObject target;
    //public GameObject target;


    [SerializeField]private float speed = 12.5f;
    //float intervalTime;
    [SerializeField]private int Enemylife = 1;


    // Use this for initialization
    void Start()
    {
        //intervalTime = 0;
        //プレイヤーを変数に保存
        target = GameObject.Find("drone");
    }

    // Update is called once per frame
    void Update()
    {
        //enemyの移動
        //transform.Translate(0, 0, 1 * speed);
        //Enemyのプレイヤーを目指した移動
        if (target != null)
        {
            //transformをプレイヤー向きにする
            this.transform.LookAt(target.transform);
            //相対Z軸を標準化したものをspeed分だけpositionに足していく？？
            this.transform.position += this.transform.forward.normalized * Time.deltaTime * speed;
            //enemyの回転
            //this.transform.Rotate(100f, 100f, 100f);
        }

        /*      //たまの回転の制御
                Quaternion quat = Quaternion.Euler(0, 180, 0);
                //フレームごとに時間をインターバルタイムを計測
                intervalTime += Time.deltaTime;
                //自動でたまの生成
                if (intervalTime >= 0.8f)
                {
                    intervalTime = 0.0f;
                    var go = Instantiate(EnemyBullet);
                    //goの親(座標)を設定
                    go.transform.parent = this.transform;
                    //ローカル座標を指定
                    go.transform.localPosition = new Vector3(0, 0, 0);
                    go.transform.localEulerAngles = new Vector3(0, 0, 0);
                    //親座標をリセット
                    go.transform.parent = null;
                }
        */
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Enemylife -= 1;
            Destroy(coll.gameObject);
            //Debug.Log(Enemylife);
            if (Enemylife <= 0)
            {
                EnemyBuster();
            }
        }

        //チャージショットと当たった時の処理
        if (coll.gameObject.tag == "PlayerCharge")
        {
            Enemylife -= 3;
            Destroy(coll.gameObject);
            //Debug.Log(Enemylife);
            if (Enemylife <= 0)
            {
                EnemyBuster();
            }
        }

    }

    //敵のライフがゼロになった時の処理
    void EnemyBuster()
    {
        Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(ScoreMotion40, new Vector3(transform.position.x, transform.position.y +15, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(40);
        //FindObjectOfType<Manager>().AddDestroyEnemy();
    }


    //初期化
    public void InitEnemy()
    {
        if (this != null)
        {
            Destroy(this.gameObject);
        }
    }
}
