using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour {
	public Renderer rend;
	public bool readySpawn;
	public bool allowsArrow;
	public bool allowsCrosbow;
	public bool allowsHalberd;
	public bool allowsCannon;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		readySpawn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnTower(int towerPicked){
		Vector3 bboxcenter = gameObject.GetComponent<BoxCollider> ().center;
		Vector3 newTower_pos = gameObject.transform.position;



		if (towerPicked == 1) {
			GameObject gotSpawned = (GameObject)Instantiate (Resources.Load("prefabs/Tower_Arrow", typeof(GameObject)), newTower_pos, Quaternion.Euler(0,0,0)) as GameObject;
			GameObject parent = GameObject.Find ("escenary").gameObject;
			gotSpawned.transform.SetParent (parent.transform);
			defaultCanvas ();
			//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("arrowTowerTag");
			//GameObject gotSpawned = (GameObject)Instantiate(Resources.Load(""
		} else if (towerPicked == 2) {
			//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("cannonTowerTag");
			GameObject gotSpawned = (GameObject)Instantiate (Resources.Load("prefabs/Tower_Crossbow", typeof(GameObject)), newTower_pos, Quaternion.Euler(0,0,0)) as GameObject;
			GameObject parent = GameObject.Find ("escenary").gameObject;
			gotSpawned.transform.SetParent (parent.transform);
			defaultCanvas ();
			//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("crossbowTowerTag");
		} else if (towerPicked == 3) {
			GameObject gotSpawned = (GameObject)Instantiate (Resources.Load("prefabs/Tower_Halberd", typeof(GameObject)), newTower_pos, Quaternion.Euler(0,0,0)) as GameObject;
			GameObject parent = GameObject.Find ("escenary").gameObject;
			gotSpawned.transform.SetParent (parent.transform);
			defaultCanvas ();

			//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("halberdTowerTag");
		} else if (towerPicked == 4) {
			//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("cannonTowerTag");
			GameObject gotSpawned = (GameObject)Instantiate (Resources.Load("prefabs/Tower_Cannon", typeof(GameObject)), newTower_pos, Quaternion.Euler(0,0,0)) as GameObject;
			GameObject parent = GameObject.Find ("escenary").gameObject;
			gotSpawned.transform.SetParent (parent.transform);
			defaultCanvas ();

		}

		//gotSpawned.transform.localScale += new Vector3 (0.3895f, 0.3895f, 0.3895f);
		//Canvas canvas = (Canvas)GameObject.Find ("CanvasApp");



		GameObject ARcamera = GameObject.Find ("ARCamera");
		GameObject gm_camera = ARcamera.transform.GetChild(0).gameObject;

		Camera camera = gm_camera.GetComponent<Camera> ();

		Vector3 pos_transformation2 = camera.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 pos_transformation3 = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 pos_transformation = camera.WorldToViewportPoint (new Vector3 (0,0,0));
		//gotSpawned.transform.position += pos_transformation3;
		//Debug.Log(bboxcenter);

	}


	public void changeTexture() {
		Texture texture = (Texture)Resources.Load("respawnMarks_PICKED");
		if (texture) {
			Debug.Log ("Texture Loaded Succesfully...");
			rend.material.mainTexture = texture;
		} else {
			Debug.Log ("Unable to load texture...");
		}
	}


	public void sendInfoToCanvas() {
		GameObject canvasApp = GameObject.Find ("CanvasApp").gameObject;
		canvasBehaviour cnvB = canvasApp.GetComponent<canvasBehaviour> ();
		if (allowsArrow) {
			cnvB.changeScreen (1);
		}
		if (allowsCrosbow) {
			cnvB.changeScreen (2);
		}
		if (allowsHalberd) {
			cnvB.changeScreen (3);
		}
		if (allowsCannon) {
			cnvB.changeScreen (4);
		}
		if (allowsArrow && allowsHalberd) {
			cnvB.changeScreen (5);
		}
		if (allowsCrosbow && allowsCannon) {
			cnvB.changeScreen (6);
		}

	}

	public void defaultCanvas() {
		GameObject canvasApp = GameObject.Find ("CanvasApp").gameObject;
		canvasBehaviour cnvB = canvasApp.GetComponent<canvasBehaviour> ();
		cnvB.changeScreen (0);

	}
}
