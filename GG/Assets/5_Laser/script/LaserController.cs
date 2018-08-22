using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    private Laser4_0 laser4_0;
    private Laser4 laser4;

	// Use this for initialization
	void Start () {
        laser4_0 = GetComponent<Laser4_0>();
        laser4 = GetComponent<Laser4>();
        StartCoroutine("LaserStart");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //オープニングでレーザー撃てるようにする
    private IEnumerator LaserStart()
    {
        yield return new WaitForSeconds(32.0f);
        laser4_0.enabled = true;
    }

    //チャージショット許可
    public void LaserChange()
    {
        laser4_0.enabled = false;
        laser4.enabled = true;
    }

    //ゲーム終了時
    public void LaserEnd()
    {
//        laser4_0.enabled = false;
       laser4.enabled = false;
    }

}
