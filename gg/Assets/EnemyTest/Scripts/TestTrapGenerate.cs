using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrapGenerate : MonoBehaviour
{

    public GameObject TrapA;
    public GameObject TrapB;
    public GameObject TrapC;
    public GameObject TrapD;
    public GameObject TrapE;

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
        for (int i = 1; i < 12; i++)
        {
            Instantiate(TrapC, new Vector3(841.4f -37 - 150 * i, 0, 30.3f), Quaternion.identity);
        }
        //TrapDの生成
        for (int i = 1; i < 8; i++)
        {
            Instantiate(TrapD, new Vector3(841.4f - 57 - 230 * i, 0, 30.3f), Quaternion.identity);
        }
        //TrapEの生成
        for (int i = 2; i < 5; i++)
        {
            Instantiate(TrapE, new Vector3(841.4f - 20 - 400 * i, 0, 30.3f), Quaternion.identity);
        }


        //TrapBossの生成
        Instantiate(TrapBoss, new Vector3(-1060, 1, 30.3f), Quaternion.identity);
    }
}


