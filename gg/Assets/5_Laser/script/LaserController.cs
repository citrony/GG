using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    private Laser4_0 laser4_0;
    private Laser4_1 laser4_1;
    private Laser4 laser4;
    private FadeController fade;

    // Use this for initialization
    void Start () {
        laser4_0 = GetComponent<Laser4_0>();
        laser4_1 = GetComponent<Laser4_1>();
        laser4 = GetComponent<Laser4>();
        fade = GetComponent<FadeController>();
        StartCoroutine("LaserStart");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //オープニングでレーザー撃てるようにする
    private IEnumerator LaserStart()
    {
        yield return new WaitForSeconds(5.0f);
        //        yield return new WaitForSeconds(32.0f);
        laser4_0.enabled = true;
    }

    //チャージショット許可
    public void LaserChange01()
    {
        laser4_0.enabled = false;
        laser4_1.enabled = true;
    }

    //両方許可
    public void LaserChange()
    {
        laser4_0.enabled = false;
        //        laser4_1.enabled = false;
        laser4.enabled = true;
    }

    //ゲーム終了時
    public void LaserEnd()
    {
//        laser4_0.enabled = false;
        laser4.enabled = false;
    }

    public void FadeOn()
    {
        fade.enabled = true;
    }
}
