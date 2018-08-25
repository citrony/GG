using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyuboss_controlStart : MonoBehaviour {

    public GameObject Explosion;
    GameObject target;

    [SerializeField] private float speed = 25.9f;
    //	float intervalTime;


    // Use this for initialization
    void Start()
    {
        //		intervalTime = 0;
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
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
            FindObjectOfType<player_move>().EventStart();
        }
    }
}
