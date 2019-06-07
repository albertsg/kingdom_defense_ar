using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.SceneManagement;

public class ButtonBehaviourScript_level2 : MonoBehaviour {

	public GameObject cameras;
	public GameObject gameManager;
	private GameManagerBehavior gmb;

	private GameObject img_power;
	private GameObject img_tower;
	private PowerUpsInit pups;
	private TowersInit_level2 tows;

    public bool activeTowerSelectionLeft = true;
    public bool activeExtraLeft = false;


	public int contador;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		gmb = gameManager.GetComponent<GameManagerBehavior> ();
		img_power = GameObject.Find ("ImageTargetPowerup");
		pups = img_power.GetComponent<PowerUpsInit> ();
		img_tower = GameObject.Find ("ImageTargetTowers");
		tows = img_tower.GetComponent<TowersInit_level2> ();

		//Contador para sacar una segunda torre (o más) en TowersInit
		contador = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clicked() {
		Debug.Log ("CLICKADO");
	}
	public void clickedTowerArrow() {
		
		Debug.Log ("Has Apretado Arrow");
		GameObject[] spawnTowerObjects;

		spawnTowerObjects = GameObject.FindGameObjectsWithTag ("TowerRespawn");

		foreach (GameObject spawn in spawnTowerObjects) {

			CreateTower createTower = spawn.GetComponent<CreateTower> ();
			if (createTower.readySpawn != false) {
				if (createTower.allowsArrow == true) {
					createTower.spawnTower (1);
					Destroy (spawn);
				}
			}
		}
	}
	public void clickedTowerCrossbow() {
		Debug.Log ("Has Apretado Crossbow");
		GameObject[] spawnTowerObjects;

		spawnTowerObjects = GameObject.FindGameObjectsWithTag ("TowerRespawn");

		foreach (GameObject spawn in spawnTowerObjects) {

			CreateTower createTower = spawn.GetComponent<CreateTower> ();
			if (createTower.readySpawn != false) {
				if (createTower.allowsCrosbow == true) {
					createTower.spawnTower (2);
					Destroy (spawn);
				}
			}
		}
	}
	public void clickedTowerHalberd() {
		Debug.Log ("Has Apretado Halberd");
		GameObject[] spawnTowerObjects;

		spawnTowerObjects = GameObject.FindGameObjectsWithTag ("TowerRespawn");

		foreach (GameObject spawn in spawnTowerObjects) {

			CreateTower createTower = spawn.GetComponent<CreateTower> ();
			if (createTower.readySpawn != false) {
				if (createTower.allowsHalberd == true) {
					createTower.spawnTower (3);
					Destroy (spawn);
				}
			}
		}
	}
	public void clickedTowerCannon() {
		Debug.Log ("Has Apretado Cannon");
		GameObject[] spawnTowerObjects;

		spawnTowerObjects = GameObject.FindGameObjectsWithTag ("TowerRespawn");

		foreach (GameObject spawn in spawnTowerObjects) {

			CreateTower createTower = spawn.GetComponent<CreateTower> ();
			if (createTower.readySpawn != false) {
				if (createTower.allowsCannon == true) {
					createTower.spawnTower (4);
					Destroy (spawn);
				}
			}
		}
	}

	public void clickedSwitchCam() {
		Debug.Log ("Switch Cam");
		if (gmb.switchCam == 0) {
			gmb.switchCam = 1;
			//VuforiaBehaviour.Instance.enabled = false;
		} else {
			gmb.switchCam = 0;
			//VuforiaBehaviour.Instance.enabled = true;
		}

		//GameObject cmrSwitchGM = GameObject.FindGameObjectWithTag ("CameraSwitchTag").gameObject;

		//camaraswitch cms = cameras.GetComponent<camaraswitch> ();
		//if (cms == null) {
		//	Debug.Log ("NO WXISTE 2");
		//} else {
		//	Debug.Log ("SI EXISTE 2");
		//}
		//cms.switchCam ();
	}


	public void touchedLeftButton() {
        Debug.Log("You touched the left button!");
        if ((activeTowerSelectionLeft == true) && (activeExtraLeft == false))
        {
            Debug.Log(gmb.currentTower);
            switch (gmb.currentTower)
            {
                case 1:
                    tows.Arrow();
                    break;
                case 2:
                    tows.Haldberd();
                    break;
                case 3: //Crossbow
                    tows.Crossbow();
                    break;
                case 4:
                    tows.Catapult();
                    break;
                default:
                    tows.Cannon();
                    break;
            }
        }
        if ((activeTowerSelectionLeft == false) && (activeExtraLeft == true))
        {
            Debug.Log("You touched the left button!");

            Debug.Log(gmb.currentExtraPosition);
            switch (gmb.currentExtraPosition)
            {
				case 1:
					Debug.Log ("Destruir TORRE");
	                
					//Devolvemos el oro
					TowerData td_ret = gmb.towerTouched.GetComponent<TowerData> (); //AQUÍ DA UN EXCEPTION QUE NO ACABO DE PILLAR
					gmb.increaseGold (td_ret.ret_gold);
						
					GameObject.Destroy(gmb.towerTouched);

					//AQUÍ DEBERÍA VOLVER A LA PRIMERA RULETA
										
                    break;
                case 2:
                    Debug.Log("Upgradear TORRE");
                    Transform positionLvlUpTwr = gmb.towerTouched.transform;
                    TowerData tdata = gmb.towerTouched.GetComponent<TowerData>();
                    //GameObject.Destroy(gmb.towerTouched);
                    bool lastLevel = true;
                    string tower_instantiate = "";
                    switch (tdata.type_tower)
                    {
                        case 1:
                            if (tdata.level == 1)
                            {
                                tower_instantiate = "Prefabs/Tower_Arrow_LVL2";
                                lastLevel = false;
                            }
                            else if (tdata.level == 2)
                            {
                                tower_instantiate = "Prefabs/Tower_Arrow_LVL3";
                                lastLevel = false;
                            } 
                            break;
                        case 2:
                            if (tdata.level == 1)
                            {
                                tower_instantiate = "Prefabs/Tower_Halberd_LVL2";
                                lastLevel = false;
                            }
                            else if (tdata.level == 2)
                            {
                                tower_instantiate = "Prefabs/Tower_Halberd_LVL3";
                                lastLevel = false;
                            } 
                            break;
                        case 3:
                            if (tdata.level == 1)
                            {
                                tower_instantiate = "Prefabs/TowerCrossbow_LVL2";
                                lastLevel = false;
                            }
                            else if (tdata.level == 2)
                            {
                                tower_instantiate = "Prefabs/TowerCrossbow_LVL3";
                                lastLevel = false;
                            } 
                            break;
                        case 4:
                            if (tdata.level == 1)
                            {
                                tower_instantiate = "Prefabs/TowerCannon_LVL2";
                                lastLevel = false;
                            }
                            else if (tdata.level == 2)
                            {
                                tower_instantiate = "Prefabs/TowerCannon_LVL3";
                                lastLevel = false;
                            } 
                            break;
                        default:
                            if (tdata.level == 1)
                            {
                                tower_instantiate = "Prefabs/TowerCatapult_LVL2";
                                lastLevel = false;
                            }
                            else if (tdata.level == 2)
                            {
                                tower_instantiate = "Prefabs/TowerCatapult_LVL3";
                                lastLevel = false;
                            } 
                            break;

                    }
                    if (lastLevel == false) {
					    GameObject aux_tower = Resources.Load (tower_instantiate, typeof(GameObject)) as GameObject;
						TowerData td_aux = aux_tower.GetComponent<TowerData> ();
						if (gmb.Gold >= td_aux.gold_cost) {

							GameObject.Destroy(gmb.towerTouched);
							
							Debug.Log(tower_instantiate);
							GameObject newTower = Instantiate(Resources.Load(tower_instantiate, typeof(GameObject))) as GameObject;
							//GameObject towIns = GameObject.Find(tower_instantiate);
							//GameObject newTower = Instantiate(towIns, positionLvlUpTwr.position, positionLvlUpTwr.rotation);

							GameObject parentTow = GameObject.Find("ImageTarget/escenary").gameObject;
							newTower.transform.SetParent(parentTow.transform, false); //False para mantener el tamaño
							newTower.transform.position = positionLvlUpTwr.position;
							newTower.transform.localScale = positionLvlUpTwr.localScale;

							gmb.towerTouched = newTower;

							//Restamos el oro de la actualización
							TowerData newtd = newTower.GetComponent<TowerData> ();
							gmb.decreaseGold (newtd.gold_cost);
							
						}   
                    }
                    break;
                default:
                    Debug.Log("Ir a seleccion de Torre");
                    GameObject uiCanvasLeft = GameObject.Find("roulette-left");
                    CanvasGroup cnvGroupLeft = uiCanvasLeft.GetComponent<CanvasGroup>();
                    cnvGroupLeft.alpha = (float)1.0;
                    GameObject uiCanvasLeftExtra = GameObject.Find("roulette-left-extra");
                    CanvasGroup cnvGroupLeftExtra = uiCanvasLeftExtra.GetComponent<CanvasGroup>();
                    cnvGroupLeftExtra.alpha = (float)0.0;

                    GameObject buttonBehaviour = GameObject.Find("ButtonBehaviour");
                    ButtonBehaviourScript buttonBehaviourScript = buttonBehaviour.GetComponent<ButtonBehaviourScript>();
                    buttonBehaviourScript.activeTowerSelectionLeft = true;
                    buttonBehaviourScript.activeExtraLeft = false;

                    Animator animatorLeftExtra;
                    GameObject goRouletteLeftExtra = GameObject.Find("roulette-left-extra");
                    animatorLeftExtra = goRouletteLeftExtra.GetComponent<Animator>();

                    animatorLeftExtra.Play("left-extra-default");
                    gmb.currentExtraPosition = 1;
                    break;
            }
        }
		
	}


	public void touchedRightButton() {
		Debug.Log ("You touched the right button!");
		Debug.Log (gmb.currentPowerup);
		switch(gmb.currentPowerup){
		case 1: //Barrier
			pups.Barrier();
			break;
		case 2: //Damage
			pups.Damage();
			break;
		case 3: //Slow (oil)
			pups.Trap();
			break;
		case 4: //Arrows
			pups.Arrows();
			break;
		default: //Fireball
			Debug.Log("TOCA FIREBALL");
			pups.Fireball();
			break;
		}
	}

	public void backToMenu(){
		SceneManager.LoadScene (0);
	}


}
