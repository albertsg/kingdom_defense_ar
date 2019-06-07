using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	CreateTower createTower;
    GameManagerBehavior gameManagerBehaviour;
    soundManager _soundManager;

	// Use this for initialization
	void Start () {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManagerBehaviour = gameManager.GetComponent<GameManagerBehavior>();

    }
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
                

				GameObject ARcamera = GameObject.Find ("ARCamera");
				GameObject gm_camera = ARcamera.transform.GetChild(0).gameObject;

				Camera camera = gm_camera.GetComponent<Camera> ();
				ray = camera.ScreenPointToRay (touch.position);

				Debug.DrawRay (ray.origin, ray.direction * 20f, Color.red);

				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					Debug.Log ("HIT SOMETHING TOUCH");
					GameObject objectHit = hit.transform.gameObject;
					if (objectHit.tag == "TowerRespawn") {
						createTower = objectHit.GetComponent<CreateTower>();
						//createTower.spawnTower ();


						GameObject[] spawnTowerObjects;

						spawnTowerObjects = GameObject.FindGameObjectsWithTag ("TowerRespawn");

						bool foundActiveRespawn = false;
						foreach (GameObject spawn in spawnTowerObjects) {

							CreateTower createTower2 = spawn.GetComponent<CreateTower> ();
							if (createTower2.readySpawn != false) {
								foundActiveRespawn = true;
							}
						}

						if (foundActiveRespawn == false) {
							createTower.changeTexture();
							createTower.sendInfoToCanvas ();
							createTower.readySpawn= true;
						}


						//BoxCollider boxcol = (BoxCollider)objectHit.GetComponent ("BoxCollider");
						//Vector3 box_center = boxcol.center;
						//GameObject towerPrefab = GameObject.FindGameObjectWithTag ("cannonTowerTag");
						//GameObject cubeTest = GameObject.FindGameObjectWithTag ("cubeTestTag");

						//GameObject cube2 = Resources.Load ("Cube") as GameObject;


						//Instantiate (cube2, box_center, Quaternion.Euler(0,0,0));
						//GameObject gotSpawned = (GameObject)Instantiate (towerPrefab, box_center, Quaternion.Euler(0,0,0));
						//gotSpawned.transform.localPosition = Vector3.zero;
						//towerPrefab.transform.TransformPoint (box_center);

						//cube2.transform.position = box_center;
						//Destroy (objectHit);
					}

                    if (((((objectHit.tag == "crossbowTowerTag") || (objectHit.tag == "cannonTowerTag")) || (objectHit.tag == "cattapultTowerTag")) || (objectHit.tag == "arrowTowerTag")) || (objectHit.tag == "halberdTowerTag"))
                    {
                        TowerData towerData = objectHit.GetComponent<TowerData>();
                        if (towerData.active == true) { 
                            Debug.Log("TOUCHED TOWER");
                            GameObject uiCanvasLeft = GameObject.Find("roulette-left");
                            CanvasGroup cnvGroupLeft = uiCanvasLeft.GetComponent<CanvasGroup>();
                            cnvGroupLeft.alpha = (float)0.0;
                            GameObject uiCanvasLeftExtra = GameObject.Find("roulette-left-extra");
                            CanvasGroup cnvGroupLeftExtra = uiCanvasLeftExtra.GetComponent<CanvasGroup>();
                            cnvGroupLeftExtra.alpha = (float)1.0;
                            GameObject buttonBehaviour = GameObject.Find("ButtonBehaviour");
                            ButtonBehaviourScript buttonBehaviourScript = buttonBehaviour.GetComponent<ButtonBehaviourScript>();
                            buttonBehaviourScript.activeTowerSelectionLeft = false;
                            buttonBehaviourScript.activeExtraLeft = true;

                            gameManagerBehaviour.towerTouched = objectHit;
                        }

                    }

				}
			}
				

		}

	
	}
}
