using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    [SerializeField] private Renderer fade;

    //フェードアウト時のalpha値
    private float alpha = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alpha < 255.0f)
        {
            alpha += 3f;
            var color = Color.black;
            color.a = alpha / 255.0f;
            fade.material.color = color;
        }
    }

}