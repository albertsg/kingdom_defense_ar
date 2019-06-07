using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {

	//private MeshCollider mcol;

	// Use this for initialization
	void Start () {
		//mcol = gameObject.GetComponent<MeshCollider> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
	
		/*Debug.Log ("YOU HIT ME, BIATCH");
		//col.gameObject.SendMessage ("activateTower");


		Rigidbody rb = GetComponent<Rigidbody> ();
		SphereCollider sc = GetComponent<SphereCollider> ();

		rb.useGravity = false;
		sc.enabled = true;

		if (col.gameObject.GetComponent<ShootEnemies> ()) {
			col.gameObject.GetComponent<ShootEnemies> ().enabled = true;
		}*/

	}
}
