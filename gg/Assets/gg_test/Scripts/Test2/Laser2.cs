using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour {

    private FoveInterfaceBase m_fovInterface;

    [SerializeField] private GameObject rPrefab;
    [SerializeField] private GameObject lPrefab;

    private GameObject rightLayser;
    private GameObject leftLayser;

    // LineRenderer rightRenderer;
    //private LineRenderer leftRenderer;

    private Fove.Managed.EFVR_Eye m_state;

    // Use this for initialization
    void Start () {
        m_fovInterface = Camera.main.GetComponent<FoveInterface>();
        
        //rightRenderer.positionCount = 2;
        //leftRenderer.positionCount = 2;
        m_state = Fove.Managed.EFVR_Eye.Neither;
    }
	
	// Update is called once per frame
	void Update () {

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
                    leftLayser.transform.position = rays.left.GetPoint(0.0f);
                    leftLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                }
                break;
            case Fove.Managed.EFVR_Eye.Right:
                if (m_state != Fove.Managed.EFVR_Eye.Right)
                {
                    rightLayser = GameObject.Instantiate(rPrefab);
                    rightLayser.transform.position = rays.right.GetPoint(0.0f);
                    rightLayser.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                }
                break;
            default:
                break;
        }
        

        m_state = state; 
	}
}
