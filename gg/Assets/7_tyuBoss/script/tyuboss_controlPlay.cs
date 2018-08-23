using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyuboss_controlPlay : MonoBehaviour
{

    public GameObject Explosion;
    public GameObject ScoreMotion150;
    GameObject target;

    [SerializeField] private float speed = 1.7f;
    [SerializeField] private int tyubosslife = 5; //中ボスのライフ

    private Renderer cren;
    Color color1;


    // Use this for initialization
    void Start()
    {
        cren = GameObject.FindWithTag("tyuBossmate").GetComponent<Renderer>();
        color1 = cren.material.color;
        //プレイヤーを変数に保存
        target = GameObject.Find("drone");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //transformをプレイヤー向きにする
            this.transform.LookAt(target.transform);
            //相対Z軸を標準化したものをspeed分だけpositionに足していく？？
            this.transform.position += this.transform.forward.normalized * Time.deltaTime * speed;
        }
        Destroy(this.gameObject, 20.0f);
    }

    void OnTriggerEnter(Collider coll)
    {
        //レーザーと当たった時の処理
        if (coll.gameObject.tag == "PlayerBullet")
        {
            FindObjectOfType<SEController>().SeBossDamage();
            tyubosslife -= 1;
            Destroy(coll.gameObject);
            StartCoroutine("Tenmetsu");

            Debug.Log(tyubosslife);
            if (tyubosslife <= 0)
            {
                TyuBossBuster();
            }

        }

        //チャージショットと当たった時の処理
        if (coll.gameObject.tag == "PlayerCharge")
        {
            FindObjectOfType<SEController>().SeBossDamage();
            tyubosslife -= 5;
            Destroy(coll.gameObject);
            StartCoroutine("Tenmetsu");

            Debug.Log(tyubosslife);
            if (tyubosslife <= 0)
            {
                TyuBossBuster();
            }

        }

    }

    //ボスのライフがゼロになった時の処理
    void TyuBossBuster()
    {
        Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(ScoreMotion150, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
        FindObjectOfType<SEController>().SeExplosion();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(150);
    }

    //点滅コルーチン
    private IEnumerator Tenmetsu()
    {
        for (int i = 0; i < 5; i++)
        {

            cren.material.color = Color.blue;
            yield return new WaitForSeconds(0.1f);
            cren.material.color = color1;
            yield return new WaitForSeconds(0.1f);

        }

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
