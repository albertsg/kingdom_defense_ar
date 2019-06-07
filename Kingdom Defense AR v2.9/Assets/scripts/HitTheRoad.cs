using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTheRoad : MonoBehaviour {

	SphereCollider sc;
	BoxCollider bc;
	Rigidbody rb;

	private int fired;

	// Use this for initialization
	void Start () {
		sc = gameObject.GetComponent<SphereCollider> ();
		bc = gameObject.GetComponent<BoxCollider> ();
		rb = gameObject.GetComponent<Rigidbody> ();
		fired = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("ENTRAMOS AL TRIGGER");

		if (fired == 0) {
			fired = 1;
			rb.useGravity = false;
			sc.enabled = true;
			Debug.Log ("RB y SC modificados");
			if (gameObject.GetComponent<ShootEnemies> ()) { //Si hay ese componente
				gameObject.GetComponent<ShootEnemies> ().enabled = true;
				Debug.Log ("SCRIPT modificado");
			}
		}

	}


}
