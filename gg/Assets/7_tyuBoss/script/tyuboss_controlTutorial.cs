using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyuboss_controlTutorial : MonoBehaviour {

    public GameObject Explosion;
    GameObject target;

    [SerializeField] private float speed = 0.0f;
    [SerializeField] private int tyubosslife = 50; //中ボスのライフ

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
            tyubosslife -= 50;
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
        FindObjectOfType<SEController>().SeEventTutorialAndEnd();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(150);
        FindObjectOfType<EventPlay>().Tyubosswarawara();
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
}

