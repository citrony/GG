using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBoss : MonoBehaviour
{
    //生成する敵オブジェクト
    public GameObject EnemyObject;
    //タイマーのオブジェクト
    private GameObject TimeUi;
    //Enemyの相対Position
    float[] positionsR = new float[3];
    float[] positionsL = new float[3];

    // Use this for initialization
    void Start()
    {
        //タイマーのオブジェクトを変数に保存
        TimeUi = GameObject.Find("TimeUi");
        //タイマーを非活性化
        if (TimeUi != null)
        {
            TimeUi.SetActive(false);
        }
        //Enemyの発生位置調整用の乱数を取る
        for (int i = 0; i < 3; i++)
        {
            positionsR[i] = Random.Range(1.0f, 5.0f);
        }
        for (int i = 0; i < 3; i++)
        {
            positionsL[i] = Random.Range(-5.0f, -3.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //タイマーを活性化
            TimeUi.SetActive(true);
            //BGMをかえる
            FindObjectOfType<TestSoundManager>().ChangeBgm();
            //ボスを生成
            Quaternion quat = Quaternion.Euler(0, 180, 0);
            if (positionsR[0] >= 3)
            {
                Instantiate(EnemyObject, new Vector3(transform.position.x - 400 + positionsR[0], transform.position.y + 150 + positionsR[1], transform.position.z + positionsR[2]), quat);
            }
            else
            {
                Instantiate(EnemyObject, new Vector3(transform.position.x - 400 - positionsL[0], transform.position.y + 150 - positionsL[1], transform.position.z + positionsL[2]), quat);
            }
            Debug.Log("BossAppeaqrance");
        }
    }
}