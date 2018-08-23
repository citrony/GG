using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlay : MonoBehaviour
{

    [SerializeField] GameObject enemyEventPlay;
    [SerializeField] GameObject enemyEventEnd;
    private Vector3[] enemyEventPos = new Vector3[8];
    float eventTime = 0;
    bool eventStart = false;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            enemyEventPos[i] = new Vector3(100 - Random.Range(55, 60), Random.Range(-18, -16), 32 + Random.Range(-20, 20));
            //Debug.Log(enemyEventPos[0].x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (eventStart == true)
        {
            eventTime += Time.deltaTime;
            if (eventTime >= 15)
            {
                Instantiate(enemyEventEnd, new Vector3(30, -19, 30), Quaternion.identity);
                eventStart = false;
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<player_move>().EventPlay();
            eventStart = true;
            Debug.Log("EventPlay!");
            for (int i = 0; i < 7; i++)
            {
                Instantiate(enemyEventPlay, enemyEventPos[i], Quaternion.identity);
            }
        }
    }
}
