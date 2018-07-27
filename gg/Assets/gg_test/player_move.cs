using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private void Start()
    {
        gazeImgTime = 0;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
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
                    FindObjectOfType<Manager>().Dispatch(Manager.GameState.Playing);
                }
            }
            else if (hit.transform.gameObject.tag == "Retry")
            {
                gazeImgTime += Time.deltaTime;
                if(gazeImgTime <= 2)
                {
                    imgRetry.fillAmount += 1.0f / 2 * gazeImgTime;
                }else if(gazeImgTime > 2)
                {
                    FindObjectOfType<Manager>().Dispatch(Manager.GameState.Opening);
                }
            }
            else if (hit.transform.gameObject.tag == "Exit")
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

        if (start == true)
        {
            velocity = new Vector3(-20, 0, 0);
            transform.localPosition += velocity * Time.fixedDeltaTime;
        }
    }
}