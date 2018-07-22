using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    private Vector3 velocity;
    private GameObject gazeButton;
    bool start = false;

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
                var state = FoveInterface.CheckEyesClosed();
                if (state == Fove.Managed.EFVR_Eye.Right)
                {
                    start = true;
                }
            }
            else
            {
                if (gazeButton != null)
                {
                    gazeButton.GetComponent<SpriteRenderer>().color = Color.white;
                    gazeButton.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }

        if(start == true)
        {
            velocity = new Vector3(-20, 0, 0);
            transform.localPosition += velocity * Time.fixedDeltaTime;
        }
    }
}

