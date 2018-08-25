using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shake : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Bossが振動する
        iTween.ShakePosition(this.gameObject, iTween.Hash("x", 2f, "y", 2f, "z", 2f, "time", 1.0f * Time.deltaTime));
    }
}