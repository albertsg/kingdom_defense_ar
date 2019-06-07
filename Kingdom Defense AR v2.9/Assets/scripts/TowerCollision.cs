using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCollision : MonoBehaviour {

	private Rigidbody rb;
	private SphereCollider sc;
	Vector3 original_pos;
	Vector3 moving_pos;
	Vector3 aux_pos;


	/*Prueba correción lanzamiento torres*/
	private int fired;
	private int fin;
	/********/
	// Use this for initialization
	void Start () {
		original_pos = gameObject.transform.position;
		rb = GetComponent<Rigidbody> ();
		sc = GetComponent<SphereCollider> ();
		fired = 0;
		fin = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((gameObject.transform.position != original_pos) && fin == 0) {
			if (fired == 0) { //Primera vez que cae
				aux_pos = gameObject.transform.position;
				fired = 1;
			} else {
				moving_pos = gameObject.transform.position;
				if (moving_pos == aux_pos) { //Ya está quieto
					FixTower();
				}
			}
		}
		
	}


	void FixTower(){
		Debug.Log ("fix tower");
		Rigidbody rb = GetComponent<Rigidbody> ();
		SphereCollider sc = GetComponent<SphereCollider> ();

		rb.useGravity = false;
		sc.enabled = true;

		GetComponent<ShootEnemies> ().enabled = true;

	}
		

}
