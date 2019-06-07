using UnityEngine;
using System.Collections;
using Vuforia;

public class BillboardScript : MonoBehaviour {
	public GameObject my_camera;
	//public Camera my_camera; 
	public Camera camera;


	void Start() {
		//print ("HOLA MUNDO");
		//my_camera = (GameObject)GameObject.Find ("ARCamera");
		//transform.LookAt (transform.position + my_camera.transform.rotation * Vector3.back, my_camera.transform.rotation * Vector3.down);
	
		GameObject ARcamera = GameObject.Find ("ARCamera");
		GameObject gm_camera = ARcamera.transform.GetChild(0).gameObject;

		camera = gm_camera.GetComponent<Camera> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 tmp = my_camera.transform.position;
		//print (" x: " + tmp.x + " y: " + tmp.y + " z: " + tmp.z);

		transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward,
			camera.transform.rotation * Vector3.up);
	}
}
