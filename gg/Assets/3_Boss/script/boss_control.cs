using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour {

    public GameObject Explosion;
    [SerializeField] private int bosslife = 20;　//ボスのライフ
    

    //   [SerializeField] private float interval = 1.0f; //点滅周期
    //    [SerializeField] private AudioClip aClip1;
    //    [SerializeField] private AudioClip aClip2;
    //    private AudioSource audioSource;

    private GameObject _child;

    // Use this for initialization
    void Start () {
        //       audioSource = gameObject.GetComponent<AudioSource>();
        _child = transform.Find("default").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //Bossが振動する
            iTween.ShakePosition(this.gameObject, iTween.Hash("x", 2f, "y", 2f, "z", 2f, "time", 1.0f * Time.deltaTime));
    }

    void OnTriggerEnter(Collider coll)
    {
        //レーザーと当たった時の処理
        if(coll.gameObject.tag == "PlayerBullet")
        {
            FindObjectOfType<Laser4>().SeDamage();
            bosslife -= 1;
            Destroy(coll.gameObject);
            Debug.Log(bosslife);
            if(bosslife <= 0)
            {
                                BossBuster();
            }

            //当たってる間だけ色を変える
 /*           if (_child.GetComponent<iTween>())
            {
                iTween.ColorFrom(_child, iTween.Hash(
                    "color", new Color(255, 0, 0),
                    "time", 0.5f,
                    "delay", 0.01f
                ));
            }
*/
            //            on_damage = true;
            //            StartCoroutine("Blink");
            //            on_damage = false;
        }

        //チャージショットと当たった時の処理
        if (coll.gameObject.tag == "PlayerCharge")
        {
            FindObjectOfType<Laser4>().SeDamage();
            bosslife -= 3;
            Destroy(coll.gameObject);
            Debug.Log(bosslife);
            if (bosslife <= 0)
            {
                               BossBuster();
            }

/*
            if (_child.GetComponent<iTween>())
            {
                iTween.ColorFrom(_child, iTween.Hash(
                    "color", new Color(255, 0, 0),
                    "time", 0.5f,
                    "delay", 0.01f
                ));
            }
*/
        }

    }

    //ボスのライフがゼロになった時の処理
       void BossBuster()
       {
        Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        FindObjectOfType<Laser4>().SeExplosion1000();
        Destroy(this.gameObject);
        FindObjectOfType<ScoreUi>().AddPoint(800);
        FindObjectOfType<Manager>().Dispatch(Manager.GameState.Clear);
    }
       
    //点滅コルーチン
 /*       IEnumerator Blink()
    {
        if (on_damage = true)
        {

            _child = transform.FindChild("default").gameObject;
            _child.GetComponent<Renderer>().enabled = !_child.GetComponent<Renderer>().enabled;
            yield return new WaitForSeconds(interval);
            
        }
    }
    */
}
