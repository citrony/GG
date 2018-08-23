using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate5 : MonoBehaviour
{
    //public GameObject EnemyBullet;
    public GameObject Explosion;
    public GameObject ScoreMotion60;
    //private AudioSource audioSource;
    //public GameObject target;


    //[SerializeField] private float speed = 8.7f;
    //float intervalTime;
    [SerializeField] private int Enemylife = 1;


    // Use this for initialization
    void Start()
    {
    //    audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyの移動
        //transform.Translate(0, 0, 1 * speed);
        //Enemyのプレイヤーを目指した移動  
        //enemyの回転
        transform.Rotate(2f, 0f, 0f);

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
        Instantiate(ScoreMotion60, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
        FindObjectOfType<SEController>().SeExplosion();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(60);
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
