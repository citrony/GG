using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    private Vector3 velocity;
    private Vector3 velocity2;
    private Vector3 velocity3;
    private Vector3 velocity4;
    private Vector3 velocity5;


    public GameObject Rock;
    private float chargeCount = 0;
    
    // Use this for initialization



    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, 0, 20);
        velocity2 = new Vector3(0, 10, 0);
        velocity3 = new Vector3(0, -10, 0);
        velocity4 = new Vector3(10, 0, 0);
        velocity5 = new Vector3(-10, 0, 0);

        transform.localPosition += velocity * Time.fixedDeltaTime;

        if (Input.GetKey("up"))
        {
            transform.localPosition += velocity2 * Time.fixedDeltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.localPosition += velocity3 * Time.fixedDeltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.localPosition += velocity4 * Time.fixedDeltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.localPosition += velocity5 * Time.fixedDeltaTime;
        }

        


        }

    
}

