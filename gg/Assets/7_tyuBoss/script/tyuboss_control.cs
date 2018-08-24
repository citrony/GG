using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyuboss_control : MonoBehaviour {

    public GameObject Explosion;
    public GameObject ScoreMotion150;
    [SerializeField] private int tyubosslife = 3; //中ボスのライフ

    private Renderer cren;
    Color color1;


    // Use this for initialization
    void Start()
    {
        cren = GameObject.FindWithTag("tyuBossmate").GetComponent<Renderer>();
        color1 = cren.material.color;
    }

    // Update is called once per frame
    void Update()
    {

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
            tyubosslife -= 3;
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
        Instantiate(ScoreMotion150, new Vector3(transform.position.x, transform.position.y+4, transform.position.z), Quaternion.identity);
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
}