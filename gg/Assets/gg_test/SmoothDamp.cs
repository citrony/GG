using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour {
    private Transform followTfm;

    float smoothTime = 0.5f;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        followTfm = GameObject.FindGameObjectWithTag("Follower").transform;
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        // 追従対象オブジェクトのTransformから、目的地を算出

        transform.Rotate(new Vector3(0f, 180f, 0f));
        Vector3 targetPos = followTfm.TransformPoint(new Vector3(0, 0, 0));

        // 移動
        transform.position =
            Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }
    
}
