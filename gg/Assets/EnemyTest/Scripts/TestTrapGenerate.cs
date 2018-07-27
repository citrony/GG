using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrapGenerate : MonoBehaviour
{

    public GameObject TrapA;
    public GameObject TrapB;
    public GameObject TrapC;
    public GameObject TrapBoss;

    // Use this for initialization
    void Awake()
    {
        //TrapAの生成
        for (int i = 0; i < 25; i++)
        {
            Instantiate(TrapA, new Vector3(841.4f -13- 70 * i, 0, 30.3f), Quaternion.identity);
        }
        //TrapBの生成
        for (int i = 0; i < 16; i++)
        {
            Instantiate(TrapB, new Vector3(841.4f -24- 110 * i, 0, 30.3f), Quaternion.identity);
        }
        //TrapCの生成
        for (int i = 0; i < 5; i++)
        {
            Instantiate(TrapC, new Vector3(841.4f -20- 400 * i, 0, 30.3f), Quaternion.identity);
        }
        //TrapBossの生成
        Instantiate(TrapBoss, new Vector3(-1000, 1, 30.3f), Quaternion.identity);
    }
}


