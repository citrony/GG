using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUi : MonoBehaviour
{
    private TextMesh timeUiText;
    private float time;
    //前のフレームの時間
    private float oldTime;

    // Use this for initialization
    void Start()
    {
        timeUiText = this.GetComponent<TextMesh>();
        time = 40.0f;
        oldTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //タイム表示の減算
        time -= Time.deltaTime;
        if (time != oldTime)
        {
            timeUiText.text = "Time:" + time.ToString() + "/40";
        }
        oldTime = time;

        //時間切れでゲームオーバーステートへ変更
        if (time <= 0)
        {
            FindObjectOfType<Manager>().Dispatch(Manager.GameState.Over);
        }
    }
    //タイムの初期化
    public void InitTime()
    {
        time = 40;
    }
}