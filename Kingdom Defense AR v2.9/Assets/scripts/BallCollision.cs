using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

	float timeleft;
	bool started;
	// Use this for initialization
	void Start () {
		started = false;
		timeleft = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (started == true) {
			timeleft -= Time.deltaTime;
			if (timeleft < 0) {
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter (Collision col){
		started = true;
		if (col.gameObject.name == "Enemy1(Clone)") { 
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "Enemy2(Clone)") { 
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "Enemy3(Clone)") { 
			Destroy (col.gameObject);
		}

		if (col.gameObject.name == "3d_objects_scene") { 
			//Destroy (gameObject); 
		}
	}

}
