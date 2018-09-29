using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_move : MonoBehaviour
{
    private Vector3 velocity;
    private GameObject gazeButton;
    bool start = false;
    //RetryとExitのアイコンのイメージコンポーネント(インスペクタで設定)
    public Image imgRetry;
    public Image imgExit;
    //RetryとExitのアイコンを見つめる時間
    private float gazeImgTime;

    //スタートフラグ
    private int startFlg = 0;
    //イベントフラグ
    private int eventFlg = 0;
    //ボス直前フラグ
    private int bossnearFlg = 0;
    //イベント終了用トリガー
    //    [SerializeField] GameObject eventEnd;

    //時間経過用
    private GameObject sun;
    private SunMove sunmove;


    private void Start()
    {
        gazeImgTime = 0;
//        eventEnd.SetActive(false);

        sun = GameObject.Find("Directional Light");
        sunmove = sun.GetComponent<SunMove>();
    }

    private IEnumerator ChangeNaviBGM1()
    {
        //ゲームスタート
        FindObjectOfType<NaviController>().ChangeNavi2();
        FindObjectOfType<TestSoundManager>().ChangeBgm1();
        yield return new WaitForSeconds(10.0f);
        FindObjectOfType<NaviController>().ChangeNavi3();
//        FindObjectOfType<Manager>().Testexitretry();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (startFlg == 0)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("GazeTarget"))
                {
                    gazeButton = hit.transform.gameObject;
                    gazeButton.transform.localScale = new Vector3(1.3f, 1.3f, 1.10f);
                    gazeButton.GetComponent<SpriteRenderer>().color = Color.red;
                    var state = FoveInterface.CheckEyesClosed();
                    if (state == Fove.Managed.EFVR_Eye.Right || state == Fove.Managed.EFVR_Eye.Left)
                    {
                        start = true;
                        startFlg = 1;
                        FindObjectOfType<Manager>().Dispatch(Manager.GameState.Playing);
                        sunmove.enabled = true;
                        StartCoroutine("ChangeNaviBGM1");
                    }
                }
/*
                else if (hit.transform.gameObject.tag == "NaviSkip")
                {
                    gazeButton = hit.transform.gameObject;
                    gazeButton.transform.localScale = new Vector3(1.3f, 1.3f, 1.10f);
//                    gazeButton.GetComponent<SpriteRenderer>().color = Color.red;
                    var state = FoveInterface.CheckEyesClosed();
                    if (state == Fove.Managed.EFVR_Eye.Right || state == Fove.Managed.EFVR_Eye.Left)
                    {                        
                        FindObjectOfType<Manager>().Prepstart();
                        FindObjectOfType<NaviController>().ChangeNaviskip();
                    }
                }
*/

                else
                {
                    gazeImgTime = 0;
                    if (gazeButton != null)
                    {
                        gazeButton.GetComponent<SpriteRenderer>().color = Color.white;
                        gazeButton.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
            }

            else if(startFlg == 1)
            {
                if (hit.transform.gameObject.tag == "Retry")
                {
                    gazeButton = hit.transform.gameObject;
                    gazeButton.transform.localScale = new Vector3(1.3f, 1.3f, 1.10f);
                    var state = FoveInterface.CheckEyesClosed();
                    if (state == Fove.Managed.EFVR_Eye.Right || state == Fove.Managed.EFVR_Eye.Left)
                    {
                        //string sceneName = SceneManager.GetActiveScene().name;
                        //SceneManager.LoadScene("gg_v1.0");
                        startFlg = 2;
                        StartCoroutine("RetryEnd");
                    }


                }
                else if (hit.transform.gameObject.tag == "Exit")
                {
                    gazeButton = hit.transform.gameObject;
                    gazeButton.transform.localScale = new Vector3(1.3f, 1.3f, 1.10f);
                    var state = FoveInterface.CheckEyesClosed();
                    if (state == Fove.Managed.EFVR_Eye.Right || state == Fove.Managed.EFVR_Eye.Left)
                    {
                        //UnityEditor.EditorApplication.isPlaying = false;

                        //Application.Quit();
                        startFlg = 2;
                        StartCoroutine("ExitEnd");
                    }

                }

                /*
                                {
                                   gazeImgTime += Time.deltaTime;
                                   if (gazeImgTime <= 2)
                                   {
                                       imgExit.fillAmount += 1.0f / 2 * gazeImgTime;
                                   }
                                   else if (gazeImgTime > 2)
                                   {
                                       FindObjectOfType<Manager>().Dispatch(Manager.GameState.Opening);
                                   }
                               }
                */


                else
                {
                    gazeImgTime = 0;
                    if (gazeButton != null)
                    {
                        gazeButton.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }

            }
        }

            if (start == true)
            {
            //            velocity = new Vector3(-20, 0, 0);
            //            transform.localPosition += velocity * Time.fixedDeltaTime;

                Vector3 p = transform.localPosition;
            if (eventFlg == 0)
            {
                if (p.x > 50f)
                {
                    velocity = new Vector3(-14.5f, 0, 0);
                    transform.localPosition += velocity * Time.fixedDeltaTime;

                }

                if ((p.x < 50f) && (p.x >= -1080f))
                {
                    velocity = new Vector3(-20.5f, 0, 0);
                    transform.localPosition += velocity * Time.fixedDeltaTime;
                    if ((p.x < -700f) && (bossnearFlg == 0))
                    {
                        FindObjectOfType<NaviController>().ChangeNavi7();
                        bossnearFlg = 1;
                    }
                }

                if (p.x < -1080f)
                {
                    velocity = new Vector3(-2, 0, 0);
                    transform.localPosition += velocity * Time.fixedDeltaTime;
                }
            }

            if (eventFlg == 1)
            {
                transform.Translate(new Vector3(0, -0.03f, 0));
                

            }

            if (eventFlg == 4)
            {
                transform.Translate(new Vector3(0, 0.1f, 0));
            }

        }
    }

    //イベントフラグ変更
    public void EventStart()
    {
        eventFlg = 1;
        Debug.Log("eventFlg = 1");
        FindObjectOfType<SEController>().SeEventStart();
        FindObjectOfType<NaviController>().ChangeNavi4();
        FindObjectOfType<TestSoundManager>().ChangeBgm2();
    }
    public void EventTutorial()
    {
        eventFlg = 2;
        Debug.Log("eventFlg = 2");
        FindObjectOfType<NaviController>().ChangeNavi5();
        FindObjectOfType<TestSoundManager>().ChangeBgm4();
        FindObjectOfType<LaserController>().LaserChange();
        //        FindObjectOfType<LaserController>().LaserChange01();
        //        StartCoroutine("WinkApply");
    }

/*
    private IEnumerator WinkApply()
    {
        yield return new WaitForSeconds(15.0f);
        FindObjectOfType<LaserController>().LaserChange();
    }
*/

    public void EventPlay()
    {
        eventFlg = 3;
        Debug.Log("eventFlg = 3");
//        FindObjectOfType<LaserController>().LaserChange();
    }
    public void EventClear()
    {
        eventFlg = 4;
        Debug.Log("eventFlg = 4");
        FindObjectOfType<NaviController>().ChangeNavi6();
        FindObjectOfType<TestSoundManager>().ChangeBgm5();
        //        eventEnd.SetActive(true);
        //        string eventEndActive = eventEnd.activeSelf.ToString();
        //        Debug.Log(eventEndActive);

    }
    public void EventEnd()
    {
        eventFlg = 0;
        Debug.Log("eventFlg = 0");
    }

    private IEnumerator RetryEnd()
    {
        FindObjectOfType<LaserController>().FadeOn();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("gg_v1.0");
    }

    private IEnumerator ExitEnd()
    {
        FindObjectOfType<LaserController>().FadeOn();
        yield return new WaitForSeconds(5.0f);
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

}