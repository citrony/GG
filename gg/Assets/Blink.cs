using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Blink : MonoBehaviour
{
    private float nextTime;
    public float interval = 1.0f;   // 点滅周期

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            var renderComponent = GetComponent<Renderer>();
            renderComponent.enabled = !renderComponent.enabled;

            nextTime += interval;
        }
    }
}