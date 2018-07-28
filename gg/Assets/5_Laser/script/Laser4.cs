using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser4 : MonoBehaviour
{

    private FoveInterfaceBase m_fovInterface;

    [SerializeField] private GameObject rPrefab;
    [SerializeField] private GameObject lPrefab;
    [SerializeField] private GameObject cPrefab;
    //AudioSourceコンポーネント
    private AudioSource audioSource;
    //発射音
    public AudioClip soundShooting;
    //爆発音
    public AudioClip soundExplosion;

    private GameObject rightLayser;
    private GameObject leftLayser;
    private GameObject chargeLayser;

    //チャージカウント用変数
    private float c_count;

    // LineRenderer rightRenderer;
    //private LineRenderer leftRenderer;

    private Fove.Managed.EFVR_Eye m_state;

    // Use this for initialization
    void Start()
    {
        m_fovInterface = Camera.main.GetComponent<FoveInterface>();

        //rightRenderer.positionCount = 2;
        //leftRenderer.positionCount = 2;
        m_state = Fove.Managed.EFVR_Eye.Neither;

        //チャージカウントゼロをセット
        c_count = 0.0f;
        //AudioSourceコンポーネント
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        FoveInterfaceBase.EyeRays rays = m_fovInterface.GetGazeRays();
        var leftRayDirection = rays.left.direction.normalized;
        var rightRayDirection = rays.right.direction.normalized;

        var state = FoveInterface.CheckEyesClosed();

        switch (state)
        {
            case Fove.Managed.EFVR_Eye.Left:
                //左目閉じたらチャージカウントゼロ
                c_count = 0.0f;

                if (m_state != Fove.Managed.EFVR_Eye.Left)
                {
                    leftLayser = GameObject.Instantiate(lPrefab);
                    //leftLayser.transform.parent = this.transform;

                    leftLayser.transform.position = (rays.left.GetPoint(0.0f) + rays.right.GetPoint(0.0f)) / 2;
                    //leftLayser.transform.position = rays.left.GetPoint(0.0f);
                    //もしくは暫定的に 
                    //leftLayser.transform.localPosition = new Vector3(-0.03f, 0, 0);

                    leftLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    //leftLayser.transform.localEulerAngles = Vector3.zero;

                    leftLayser.transform.parent = GameObject.Find("Fove Rig").transform;
                    //leftLayser.transform.parent = this.transform;


                    //leftLayser.transform.parent = null;
                    Destroy(leftLayser, 20.0f);
                    //発射音
                    audioSource.Play();
                }
                break;

            case Fove.Managed.EFVR_Eye.Right:
                //右目閉じたらチャージカウントゼロ
                c_count = 0.0f;

                if (m_state != Fove.Managed.EFVR_Eye.Right)
                {
                    rightLayser = GameObject.Instantiate(rPrefab);
                    //rightLayser.transform.parent = this.transform;

                    rightLayser.transform.position = (rays.left.GetPoint(0.0f) + rays.right.GetPoint(0.0f)) / 2;
                    //rightLayser.transform.position = rays.right.GetPoint(0.0f);
                    //もしくは暫定的に 
                    //rightLayser.transform.localPosition = new Vector3(0.03f, 0, 0);

                    rightLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    //rightLayser.transform.localEulerAngles = Vector3.zero;

                    rightLayser.transform.parent = GameObject.Find("Fove Rig").transform;
                    //rightLayser.transform.parent = this.transform;

                    //rightLayser.transform.parent = null;
                    Destroy(rightLayser, 20.0f);
                    //発射音
                    audioSource.Play();
                }
                break;

            case Fove.Managed.EFVR_Eye.Neither:
                //両目開いてたら開いてた秒数分チャージ
                c_count += Time.deltaTime;

                //もし前のステートが両目開いてて、かつ3秒以上開いてたらチャージビーム放出→チャージカウントゼロ
                if (m_state == Fove.Managed.EFVR_Eye.Neither && c_count >= 2.0f)
                {
                    chargeLayser = GameObject.Instantiate(cPrefab);
                    //chargeLayser.transform.parent = this.transform;

                    chargeLayser.transform.position = (rays.left.GetPoint(0.0f) + rays.right.GetPoint(0.0f)) / 2;
                    //もしくは暫定的に 
                    //chargeLayser.transform.localPosition = Vector3.zero;

                    chargeLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                    //chargeLayser.transform.localEulerAngles = Vector3.zero;

                    chargeLayser.transform.parent = GameObject.Find("Fove Rig").transform;
                    //chargeLayser.transform.parent = this.transform;

                    //chargeLayser.transform.parent = null;
                    Destroy(chargeLayser, 20.0f);
                    c_count = 0.0f;
                    //発射音
                    audioSource.Play();
                }
                

                //両目開けたら、もし前のステートが両目閉じてて、かつ3秒以上閉じてたらチャージビーム放出→チャージカウントゼロ
                /*if (m_state == Fove.Managed.EFVR_Eye.Both && c_count >= 3.0f)
                {
                                     chargeLayser = GameObject.Instantiate(cPrefab);
                                     chargeLayser.transform.position = (rays.left.GetPoint(0.0f) + rays.right.GetPoint(0.0f)) / 2;
                                     chargeLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                                     Destroy(chargeLayser, 20.0f);
                                     c_count = 0.0f;
                }
                //それ以外で両目開けたら、チャージカウントゼロ

                else
                {
                    c_count = 0.0f;
                }
                */

                break;
                
            case Fove.Managed.EFVR_Eye.Both:
                //両目閉じたらチャージカウントゼロ
                c_count = 0.0f;
                //両目閉じたら閉じてた秒数分チャージ
                //c_count += Time.deltaTime;

                break;

            default:
                break;
        }


        m_state = state;
    }
    //爆発音がなる
    public void SeExplosion()
    {
        audioSource.clip = soundExplosion;
        audioSource.Play();
        //Debug.Log("ExplosionSoundPlay");
        audioSource.clip = soundShooting;
    }
}