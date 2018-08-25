using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            FindObjectOfType<player_move>().EventEnd();
        }
    }
}

