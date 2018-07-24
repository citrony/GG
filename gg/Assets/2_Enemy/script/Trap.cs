using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public GameObject EnemyObject;
    //Enemyの相対Position
	float[] positionsR = new float[3];
	float[] positionsL = new float[3];
    
	// Use this for initialization
	void Start () {
		//EnemyObject.SetActive(false);
		for (int i = 0; i < 3; i++)
		{
			positionsR[i] = Random.Range(9.0f,18.0f);
		}
		for (int i = 0; i < 3; i++)
        {
            positionsL[i] = Random.Range(-15.0f, -9.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player"){
			Quaternion quat = Quaternion.Euler(0, 180, 0);
			if (positionsR[0] >= 13.5)
			{
				Instantiate(EnemyObject, new Vector3(transform.position.x -100- positionsR[0], transform.position.y, transform.position.z + positionsR[2]), quat);
                //EnemyObject.SetActive(true);
			}else {
				Instantiate(EnemyObject, new Vector3(transform.position.x -100+ positionsL[0], transform.position.y, transform.position.z + positionsL[2]), quat);
			}    
			Debug.Log("hit");
		}
	}
}
