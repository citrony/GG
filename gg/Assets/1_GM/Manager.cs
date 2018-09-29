using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //ゲームステート
    public enum GameState
    {
        Opening,//プレイ開始前、スタート待ち状態　player_moveないの処理でPlayingに移行
        Playing,//プレイ中
        Clear,//ゲームクリア画面の状態
        Over//ゲームオーバー画面の表示
    }
    //今のステート
    public GameState currentState = GameState.Opening;
    //パネル
    private GameObject panel;
    //パネルタイトル
    private GameObject title;
    //パネルタイトルテキスト
    private TextMesh titleText;
    //パネルトータルスコア
    private GameObject yourScore;
    //パネルトータルスコアテキスト
    private TextMesh yourScoreText;
    //イグジットアイコン
    private GameObject exitIcon;
    //リトライアイコン
    private GameObject retryIcon;
    //スタートアイコン
    private GameObject startIcon;
    //スタートアイコンの入れ物
    private GameObject startIconbox;
    //倒した敵の数
    int countDestroyEnemy;
    //色相
    int hueTitle;
    int hueYourScore;
    //ゲーム中に得られたスコア
    int nowScore;
    //敵の存在の確認
    GameObject enemy;
    //時間のUI
    private GameObject timeUi;
    //スコアのUI
    private GameObject scoreUi;
    //スキップ用アイコン
//    private GameObject naviSkip;


    // Use this for initialization
    void Start()
    {
        //exeのスピード調整
        Application.targetFrameRate = 60;
        //ステージ上のパネル上のUI系ゲームオブジェクトを取得(タグまとめとかもあり)
        panel = GameObject.Find("Panel");
        title = GameObject.Find("Title");
        yourScore = GameObject.Find("YourScore");
        exitIcon = GameObject.Find("ExitIcon");
        retryIcon = GameObject.Find("RetryIcon");
        startIconbox = GameObject.Find("start_iconbox");
        startIcon = startIconbox.transform.Find("start_icon").gameObject;
        timeUi = GameObject.Find("TimeUi");
        scoreUi = GameObject.Find("ScoreUi");
//        naviSkip = GameObject.Find("Naviskip");


        //パネルを非表示
        panel.SetActive(false);
        title.SetActive(false);
        yourScore.SetActive(false);
        exitIcon.SetActive(false);
        retryIcon.SetActive(false);
//        naviSkip.SetActive(false);

        //タイトルのテキスト
        titleText = title.GetComponent<TextMesh>();
        //トータルスコアのテキスト
        yourScoreText = yourScore.GetComponent<TextMesh>();
        //オープニング
        GameOpening();
        //倒した敵の数
        countDestroyEnemy = 0;
        //色相
        hueTitle = 0;
        hueYourScore = 0;
        //ゲーム中に得られたスコア
        nowScore = 0;
        //敵の存在の確認
        enemy = GameObject.Find("Enemy");
        StartCoroutine("StartNavi");
    }

    //スタートNavi
    private IEnumerator StartNavi()
    {
        yield return new WaitForSeconds(5.0f);
        FindObjectOfType<NaviController>().ChangeNavi1();
//        yield return new WaitForSeconds(2.0f);
        startIcon.SetActive(true);

        //        naviSkip.SetActive(true);
        //        yield return new WaitForSeconds(27.0f);
        //       if(naviSkip.activeSelf())
        //       {
        //            Prepstart();
        //       }
    }
    /*
        public void Prepstart()
        {
            startIcon.SetActive(true);
            naviSkip.SetActive(false);
        }
    */

    //ゲームクリアNavi//→アプリ終了
    private IEnumerator ClearNavi()
    {
        scoreUi.SetActive(false);
        timeUi.SetActive(false);
        FindObjectOfType<NaviController>().ChangeNavi10();
        FindObjectOfType<TestSoundManager>().ChangeBgm7();       
        yield return new WaitForSeconds(5.0f);
        FindObjectOfType<LaserController>().LaserEnd();
        exitIcon.SetActive(true);
        retryIcon.SetActive(true);
        FindObjectOfType<TestSoundManager>().ChangeBgm8();
//        yield return new WaitForSeconds(19.0f);
//        Application.Quit();
    }

    //ゲームオーバーTimeUp//→アプリ終了
    private IEnumerator GameOverTNavi()
    {
        timeUi.SetActive(false);
        scoreUi.SetActive(false);
        FindObjectOfType<NaviController>().ChangeNavi12();
        FindObjectOfType<TestSoundManager>().ChangeBgm9();
        yield return new WaitForSeconds(5.0f);
        FindObjectOfType<LaserController>().LaserEnd();
        exitIcon.SetActive(true);
        retryIcon.SetActive(true);
        //        yield return new WaitForSeconds(19.0f);
        //        Application.Quit();
    }


    public void Testexitretry()
    {
        exitIcon.SetActive(true);
        retryIcon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //トータルスコアの計算
    public void AddYourScore(int point)
    {
        yourScoreText.text = "Your Score:" + point;
    }
    //パネルUIの活性化
    void OpenPanel()
    {
        panel.SetActive(true);
        title.SetActive(true);
        yourScore.SetActive(true);
//        exitIcon.SetActive(true);
//        retryIcon.SetActive(true);
    }
    //パネルUIの非活性化
    void ClosePanel()
    {
        panel.SetActive(false);
        title.SetActive(false);
        yourScore.SetActive(false);
        exitIcon.SetActive(false);
        retryIcon.SetActive(false);
    }
    //オブジェクトやスコアを初期位置に戻す
    void AllInit()
    {
        //敵の初期化
        if (enemy != null)
        {
            FindObjectOfType<EnemyControl>().InitEnemy();
        }
        //カメラの初期化
        //FindObjectOfType<CameraControl>().InitCamera();
        //スコアの初期化
        FindObjectOfType<ScoreUi>().InitScore();
        //ライフの初期化
        //FindObjectOfType<LifeUi>().InitLife();
        //タイムの初期化
        FindObjectOfType<TimeUi>().InitTime();
        //プレイヤーの初期化？？
        //FindObjectOfType<PlayerControl>().InitPlayer();
    }
    //ステートによる、ゲーム画面の切り分け
    public void Dispatch(GameState state)
    {
        GameState oldState = currentState;
        currentState = state;
        switch (state)
        {
            case GameState.Opening:
                GameOpening();
                break;
            case GameState.Playing:
                if (oldState == GameState.Opening)
                {
                    GameStart();
                }
                break;
            case GameState.Clear:
                if (oldState == GameState.Playing)
                {
                    GameClear();
                }
                break;
            case GameState.Over:
                if (oldState == GameState.Playing)
                {
                    GameOver();
                }
                break;
        }
    }
    //オープニング処理
    public void GameOpening()
    {
        //ステート変更
        currentState = GameState.Opening;
        //ContinueとExit非表示
        exitIcon.SetActive(false);
        retryIcon.SetActive(false);
        //タイトルを表示する
        panel.SetActive(true);
        title.SetActive(true);
        hueTitle = 35;
        float hueTitleChanged = hueTitle / 360;
        SetTitle("Game Start", Color.HSVToRGB(0.3f, 1, 1));
        //トータルスコアの表示をかえる
        yourScore.SetActive(true);
        hueYourScore = 75;
        float hueYourScoreCanged = hueYourScore / 360;
        SetYourScoer("まばたきかSpaceキーを押してください", Color.HSVToRGB(0.1f, 1, 1));
        //オブジェクトやスコアを初期位置に戻す
        AllInit();
        ClosePanel();
    }
    //ゲームスタート処理
    void GameStart()
    {

    }
    //ゲームクリアー処理
    void GameClear()
    {
        //タイトルを変更する
        SetTitle("Game Clear!!", Color.HSVToRGB(0.2f, 1, 1));
        //トータルスコアを変更する
        nowScore = FindObjectOfType<ScoreUi>().score;
        SetYourScoer("Your Score:" + nowScore, Color.HSVToRGB(0.1f, 1, 1));
        //パネルを表示する
        OpenPanel();
        StartCoroutine("ClearNavi");
    }
    //ゲームオーバー処理
    public void GameOver()
    {
        //タイトルを変更する
        SetTitle("Game Over!!", Color.HSVToRGB(0, 1, 1));
        //トータルスコアを変更する
        nowScore = FindObjectOfType<ScoreUi>().score;
        SetYourScoer("Your Score:" + nowScore, Color.HSVToRGB(0.1f, 1, 1));
        //パネルを表示する
        OpenPanel();
        StartCoroutine("GameOverTNavi");
    }
    //パネルタイトルの変更
    void SetTitle(string message, Color color)
    {
        titleText.text = message;
        titleText.color = color;
    }
    void SetYourScoer(string message, Color color)
    {
        yourScoreText.text = message;
        yourScoreText.color = color;
    }
}