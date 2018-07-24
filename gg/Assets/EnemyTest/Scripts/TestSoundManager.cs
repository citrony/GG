using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundManager : MonoBehaviour {
    // [SerializeField] private AudioSource bgm1;
    // [SerializeField] private AudioSource bgm2;
    [SerializeField] private AudioClip bgm1;
	[SerializeField] private AudioClip bgm2;
    private AudioSource nowBgm;
	private float testTime;
	private int bgmState;
    // Use this for initialization
    void Start () {
		nowBgm = gameObject.GetComponent<AudioSource>();
        nowBgm.clip = bgm1;
        nowBgm.Play();
        Debug.Log("bgm1 is played");
		testTime = 0;
		bgmState = 0;
	}

	// Update is called once per frame
	void Update () {
		/*
		//以下テスト用
		testTime += Time.deltaTime;
		if(testTime >= 10){
			if (bgmState == 0)
			{
				ChangeBgm();
			}
		}
        //ここまでテスト用
        */
    }
    //BGmをチェンジする関数
    public void ChangeBgm()
    {
        if (bgmState == 0)
        {
            nowBgm.clip = bgm2;
			nowBgm.Play();
			Debug.Log("bgm2 is played");
			bgmState = 1;
		} else if (bgmState == 1)
        {
            nowBgm.clip = bgm1;
			nowBgm.Play();
			bgmState = 0;
        }
    }

}