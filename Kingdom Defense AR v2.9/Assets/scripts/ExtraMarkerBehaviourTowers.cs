using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMarkerBehaviourTowers : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	GameObject originRayshoot;

	// Use this for initialization
	void Start () {
		originRayshoot = GameObject.Find("RayOriginTow");
		ray.origin = originRayshoot.transform.position;
		ray.direction = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("[G] Marker Towers. Ray Origin: " + ray.origin);
	}

	public void onPressedButtonInfo () {
		Debug.Log ("[G] Marker Towers. Ray Origin: " + ray.origin);
	}
}
