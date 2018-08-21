using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviController : MonoBehaviour {

    // [SerializeField] private AudioSource navi1;
    // [SerializeField] private AudioSource navi2;
    [SerializeField] private AudioClip navi1;
    [SerializeField] private AudioClip navi2;
    [SerializeField] private AudioClip navi3;
    [SerializeField] private AudioClip navi4;
    [SerializeField] private AudioClip navi5;
    [SerializeField] private AudioClip navi6;
    [SerializeField] private AudioClip navi7;
    [SerializeField] private AudioClip navi8;
    [SerializeField] private AudioClip navi9;
    [SerializeField] private AudioClip navi10;
    [SerializeField] private AudioClip navi11;
    [SerializeField] private AudioClip navi12;

    private AudioSource nowNavi;
    private float testTime;
    private int naviState;
    // Use this for initialization
    void Start()
    {
 //       nowNavi = gameObject.GetComponent<AudioSource>();
 //       nowNavi.clip = navi1;
 //       nowNavi.Play();
 //       Debug.Log("navi1 is played");
        testTime = 0;
        naviState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
		//以下テスト用
		testTime += Time.deltaTime;
		if(testTime >= 10){
			if (naviState == 0)
			{
				ChangeNavi();
			}
		}
        //ここまでテスト用
        */
    }

    //Naviをチェンジする関数
    public void ChangeNavi1()
    {
        nowNavi = gameObject.GetComponent<AudioSource>();
        nowNavi.clip = navi1;
        nowNavi.Play();
    }

    public void ChangeNavi2()
    {
        nowNavi.clip = navi2;
        nowNavi.Play();
        /*        if (naviState == 0)
                {
                    nowNavi.clip = navi2;
                    nowNavi.Play();
                    Debug.Log("navi2 is played");
                    naviState = 1;
                } else if (naviState == 1)
                {
                    nowNavi.clip = navi1;
                    nowNavi.Play();
                    naviState = 0;
                }
                */
    }

    public void ChangeNavi3()
    {
        nowNavi.clip = navi3;
        nowNavi.Play();
    }

    public void ChangeNavi4()
    {
        nowNavi.clip = navi4;
        nowNavi.Play();
    }

    public void ChangeNavi5()
    {
        nowNavi.clip = navi5;
        nowNavi.Play();
    }

    public void ChangeNavi6()
    {
        nowNavi.clip = navi6;
        nowNavi.Play();
    }

    public void ChangeNavi7()
    {
        nowNavi.clip = navi7;
        nowNavi.Play();
    }

    public void ChangeNavi8()
    {
        nowNavi.clip = navi8;
        nowNavi.Play();
    }

    public void ChangeNavi9()
    {
        nowNavi.clip = navi9;
        nowNavi.Play();
    }

    public void ChangeNavi10()
    {
        nowNavi.clip = navi10;
        nowNavi.Play();
    }

    public void ChangeNavi11()
    {
        nowNavi.clip = navi11;
        nowNavi.Play();
    }

    public void ChangeNavi12()
    {
        nowNavi.clip = navi12;
        nowNavi.Play();
    }
}