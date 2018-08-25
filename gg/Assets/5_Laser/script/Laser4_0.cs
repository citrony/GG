using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser4_0 : MonoBehaviour {

    private FoveInterfaceBase m_fovInterface;

    [SerializeField] private GameObject rPrefab;
    [SerializeField] private GameObject lPrefab;


    private GameObject rightLayser;
    private GameObject leftLayser;

    private Fove.Managed.EFVR_Eye m_state;

    // Use this for initialization
    void Start()
    {
        m_fovInterface = Camera.main.GetComponent<FoveInterface>();

        //rightRenderer.positionCount = 2;
        //leftRenderer.positionCount = 2;
        m_state = Fove.Managed.EFVR_Eye.Neither;
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

                    //発射音
                    //                    audioSource.clip = soundChargeShot;
                    //                    audioSource.PlayOneShot(soundChargeShot, 0.5f);
                    FindObjectOfType<SEController>().SeLaser();

                    //leftLayser.transform.parent = null;
                    Destroy(leftLayser, 20.0f);

                }
                break;

            case Fove.Managed.EFVR_Eye.Right:

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

                    //発射音
                    //                    audioSource.clip = soundChargeShot;
                    //                    audioSource.PlayOneShot(soundChargeShot, 0.5f);
                    FindObjectOfType<SEController>().SeLaser();

                    //rightLayser.transform.parent = null;
                    Destroy(rightLayser, 20.0f);

                }
                break;


            case Fove.Managed.EFVR_Eye.Neither:

                break;

            case Fove.Managed.EFVR_Eye.Both:

                break;

            default:
                break;
        }


        m_state = state;
    }
}

