using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDamage : MonoBehaviour {

	float timeleft;
	bool started;

	// Use this for initialization
	void Start () {
		started = false;
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
		Rigidbody rigid = gameObject.GetComponent<Rigidbody> ();
		BoxCollider box = gameObject.GetComponent<BoxCollider> ();

		box.isTrigger = true; //Para detectar más de una collision

		const float ySize = 5.0f;
		box.size = new Vector3(box.size.x, ySize, box.size.z);
		started = true;

		//col.gameObject.SendMessage("damagePowerup"); //Sale un error sobre el SendMessage pero funciona, habrá que consultar
		if (col.gameObject.name == "Enemy1(Clone)") { 
			GameObject enemy = col.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (col.gameObject.name == "Enemy2(Clone)") { 
			GameObject enemy = col.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (col.gameObject.name == "Enemy3(Clone)") { 
			GameObject enemy = col.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (col.gameObject.name == "3d_objects_scene") { 
			rigid.isKinematic = true;

		}

	}

	void OnTriggerEnter(Collider other) {
		Rigidbody rigid = gameObject.GetComponent<Rigidbody> ();
		//started = true;
		//col.gameObject.SendMessage("damagePowerup"); //Sale un error sobre el SendMessage pero funciona, habrá que consultar
		if (other.gameObject.name == "Enemy1(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "Enemy2(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "Enemy3(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "3d_objects_scene") { 
			rigid.isKinematic = true;

		}
	}

	/*void OnTriggerStay(Collider other) {
		Rigidbody rigid = gameObject.GetComponent<Rigidbody> ();
		//started = true;
		//col.gameObject.SendMessage("damagePowerup"); //Sale un error sobre el SendMessage pero funciona, habrá que consultar
		if (other.gameObject.name == "Enemy1(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "Enemy2(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "Enemy3(Clone)") { 
			GameObject enemy = other.gameObject;
			PlayerHealth ph = enemy.GetComponent<PlayerHealth> ();
			ph.damagePowerup ();
			rigid.isKinematic = true;
		}
		if (other.gameObject.name == "3d_objects_scene") { 
			rigid.isKinematic = true;

		}
	}*/
}
