using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoveController : MonoBehaviour
    {
        public FoveInterfaceBase foveInterface;
        public GameObject myCube;

        // Update is called once per frame
        void Update()
        {
            myCube = GameObject.Find("Cube");

            Fove.Managed.EFVR_Eye state = FoveInterface.CheckEyesClosed();

            switch (state)
            {
                case Fove.Managed.EFVR_Eye.Left:
                myCube.GetComponent<Renderer>().material.color = Color.red;
                break;
            }
            
           

        }
    }

