using UnityEngine;
using System.Collections;

public class camaraswitch : MonoBehaviour {

	private bool camswitch = false;
	public GameObject gameManager;
	private GameManagerBehavior gmb;
	[SerializeField]
	Camera camara3d;
	[SerializeField]
	Camera camara2d;


	// Use this for initialization
	void Start () {

		camara3d.GetComponent<Camera> ().enabled = true;
		camara2d.GetComponent<Camera> ().enabled = false;
		gmb = gameManager.GetComponent<GameManagerBehavior> ();
	}

	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.W) ) {
//			
//			camswitch = !camswitch;
//		}
		if (gmb.switchCam == 1 && !camswitch) {

			camswitch = !camswitch;
		}
        if (camswitch && gmb.switchCam == 0)
        {
            camswitch = !camswitch;
        }

		if (camswitch == false) {
			camara3d.GetComponent<Camera> ().enabled = true;
			camara2d.GetComponent<Camera> ().enabled = false;
		}

		if (camswitch == true) {
			camara3d.GetComponent<Camera> ().enabled = false;
			camara2d.GetComponent<Camera> ().enabled = true;
		}


	}

	public void switchCam() {
		camswitch = !camswitch;

	}
}
