using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour {

    //AudioSourceコンポーネント
    private AudioSource audioSource;
    //レーザー発射音
    public AudioClip soundLaser;
    //チャージショット発射音
    public AudioClip soundChargeShot;
    //敵爆発音
    public AudioClip soundExplosion;
    //ボスダメージ
    public AudioClip soundDamage;
    //ボス爆発音
    public AudioClip soundExplosion1000;



    // Use this for initialization
    void Start () {
        //AudioSourceコンポーネント
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = soundShooting;
        //AudioSource[] audioSources = GetComponents<AudioSource>();
        //audioSources[0].clip = soundLaser;
        //audioSources[1].clip = soundChargeShot;		
    }

    // Update is called once per frame
    void Update () {
		
	}

    //レーザー発射音がなる
    public void SeLaser()
    {
        audioSource.clip = soundLaser;
        audioSource.PlayOneShot(soundLaser, 0.5f);
    }

    //チャージショット発射音がなる
    public void SeChargeShot()
    { 
        audioSource.clip = soundChargeShot;
        audioSource.PlayOneShot(soundChargeShot, 0.5f);
    }

    //敵爆発音がなる
    public void SeExplosion()
    {
        audioSource.clip = soundExplosion;
        audioSource.PlayOneShot(soundExplosion, 0.5f);

        // Debug.Log("ExplosionSoundPlay");
        //audioSource.clip = soundShooting;
    }

    //ボスダメージ音がなる
    public void SeDamage()
    {
        audioSource.clip = soundDamage;
        audioSource.PlayOneShot(soundDamage, 0.5f);
    }

    //ボス爆発音がなる
    public void SeExplosion1000()
    {
        audioSource.clip = soundExplosion1000;
        audioSource.PlayOneShot(soundExplosion1000, 0.5f);
    }

}

