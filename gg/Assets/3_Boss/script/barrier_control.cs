using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier_control : MonoBehaviour {

    [SerializeField] private int barrierlife = 30;　//バリアのライフ
    [SerializeField] private GameObject Erosion;

    private Renderer bren;
    Color color2;

    // Use this for initialization
    void Start()
    {
        bren = GetComponent<Renderer>();
        color2 = bren.material.color;
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
            FindObjectOfType<SEController>().SeBarrierReflec();
            Destroy(coll.gameObject);
        }

        //チャージショットと当たった時の処理
        if (coll.gameObject.tag == "PlayerCharge")
        {

            barrierlife -= 10;
            StartCoroutine("Tenmetsu2");
            Debug.Log(barrierlife);
            Destroy(coll.gameObject);
            if (barrierlife <= 0)
            {
                BarrierBuster();
            }
            else
            {
                FindObjectOfType<SEController>().SeBarrierDamage();
            }
        }

    }

    //バリアのライフがゼロになった時の処理
    void BarrierBuster()
    {
        Instantiate(Erosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        FindObjectOfType<SEController>().SeBarrierBreak();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(200);
        FindObjectOfType<NaviController>().ChangeNavi9();
    }

    //点滅コルーチン
    private IEnumerator Tenmetsu2()
    {
        for (int i = 0; i < 5; i++)
        {

            bren.material.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            bren.material.color = color2;
            yield return new WaitForSeconds(0.05f);

        }

    }
}

