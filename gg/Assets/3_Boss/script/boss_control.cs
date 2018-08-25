using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour {

    public GameObject Explosion;
    [SerializeField] private int bosslife = 27; //ボスのライフ

    private Renderer cren;
    Color color1;


    // Use this for initialization
    void Start () {
        cren = GameObject.FindWithTag("Bossmate").GetComponent<Renderer>();
        color1 = cren.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        //Bossが振動する
          //iTween.ShakePosition(this.gameObject, iTween.Hash("x", 2f, "y", 2f, "z", 2f, "time", 1.0f * Time.deltaTime));
    }

    void OnTriggerEnter(Collider coll)
    {
        //レーザーと当たった時の処理
        if(coll.gameObject.tag == "PlayerBullet")
        {
            FindObjectOfType<SEController>().SeBossDamage();
            bosslife -= 1;
            Destroy(coll.gameObject);
            StartCoroutine("Tenmetsu");

            Debug.Log(bosslife);
            if(bosslife <= 0)
            {
                                BossBuster();
            }

        }

        //チャージショットと当たった時の処理
        if (coll.gameObject.tag == "PlayerCharge")
        {
            FindObjectOfType<SEController>().SeBossDamage();
            bosslife -= 3;
            Destroy(coll.gameObject);
            StartCoroutine("Tenmetsu");

            Debug.Log(bosslife);
            if (bosslife <= 0)
            {
                               BossBuster();
            }

        }

    }

    //ボスのライフがゼロになった時の処理
       void BossBuster()
       {
        Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        FindObjectOfType<SEController>().SeExplosion1000();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(800);
        FindObjectOfType<Manager>().Dispatch(Manager.GameState.Clear);
    }

    //点滅コルーチン
       private IEnumerator Tenmetsu()
       {
            for (int i = 0; i < 5; i++)
            {

                cren.material.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                cren.material.color = color1;
                yield return new WaitForSeconds(0.1f);

            }

        }
}
