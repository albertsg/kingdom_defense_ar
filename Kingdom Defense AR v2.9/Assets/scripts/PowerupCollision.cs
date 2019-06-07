using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour {

	Rigidbody rb;
	float timeleft;
	bool started;

	// Use this for initialization
	void Start () {
		started = false;
		rb = GetComponent<Rigidbody> ();
		timeleft = 5.0f;
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
		Debug.Log ("Collision detected");
		started = true;
		if (col.gameObject.name == "Enemy1(Clone)") { 
			GameObject enemy = col.gameObject;
			MoveEnemy me = enemy.GetComponent<MoveEnemy> ();
			me.HitPowerup (timeleft);
			//col.gameObject.SendMessage("HitPowerup",timeleft);
			//Habrá que actualizar aquí el oro y todo eso
		}
		if (col.gameObject.name == "Enemy2(Clone)") { 
			GameObject enemy = col.gameObject;
			MoveEnemy me = enemy.GetComponent<MoveEnemy> ();
			me.HitPowerup (timeleft);
			//col.gameObject.SendMessage("HitPowerup",timeleft);
			//Habrá que actualizar aquí el oro y todo eso
		}
		if (col.gameObject.name == "Enemy3(Clone)") { 
			GameObject enemy = col.gameObject;
			MoveEnemy me = enemy.GetComponent<MoveEnemy> ();
			me.HitPowerup (timeleft);
			//col.gameObject.SendMessage("HitPowerup",timeleft);
			//Habrá que actualizar aquí el oro y todo eso
		}

	}

	public void activateTime(){
		started = true;
	}

	/*void OnTriggerEnter(Collider other){
		//first we make sure that the object that hit the powerup is the enemy1.
		if (other.name == "Enemy1(Clone)"){ 
			// This will search all enemy scripts for a function called "HitPowerup"
			print ("Powerup was hit by the enemy 1");
			other.gameObject.SendMessage("HitPowerup");
		}
	}*/
}
