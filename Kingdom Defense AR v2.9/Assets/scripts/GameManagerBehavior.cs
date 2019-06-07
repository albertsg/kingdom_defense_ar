using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class GameManagerBehavior : MonoBehaviour {
    public static int level = 0;

	public int currentTower; //1 is tower arrow, 2 is tower haldberd, 3 is tower crossbow, 4 is tower catapult and 5 is tower cannon
	public int currentPowerup;

    public Image BarMana;
    public Image BarHealth;

    public float max_health = 1000f;
    public float cur_health = 0f;

    public float max_mana = 1000f;
    public float cur_mana = 0f;

    public Text goldLabel;
    //public Text goldLabel;
    private int gold;
	public int switchCam;
	public int Gold {
		get { return gold; }
		set {
			gold = value;
			goldLabel.GetComponent<Text> ().text = " " + gold;
		}
	}
	public Text waveLabel;
	public GameObject[] nextWaveLabels;
	public bool gameOver = false;

	private int wave;
	public int Wave {
		get { return wave; }
		set {
			wave = value;
			if (!gameOver) {
                waveLabel.GetComponent<Text>().text = " " + wave;
                
				for (int i = 0; i < nextWaveLabels.Length; i++) {
					nextWaveLabels [i].GetComponent<Animator> ().SetTrigger ("nextWave");
				}
				
            }
			waveLabel.text = (wave + 1)+"/4";


		}


	}

    // GUSTAVO
    public int currentExtraPosition;
    public GameObject towerTouched;

    public bool hasLoadedScenario = false;

    /*
    private struct TowersInfo
    {
        public GameObject LVL1;
        public GameObject LVL2;
        public GameObject LVL3;
    }
    */
    
    public struct TowersInfo
    {
        public GameObject LVL1, LVL2, LVL3;

        public TowersInfo(GameObject LVL1, GameObject LVL2, GameObject LVL3)
        {
            this.LVL1 = LVL1;
            this.LVL2 = LVL2;
            this.LVL3 = LVL3;
        }
    }


    // GUSTAVO
    //public List<GameObject> enemiesInRange;
    private List<TowersInfo> towerInfo;
    public GameObject TextLabelInfoRightTower;
    public GameObject TextLabelInfoRightCost;

    public float fireball_powerup_cost;
    public float damage_powerup_cost;
    public float barrier_powerup_cost;
    public float trap_powerup_cost;
    public float arrows_powerup_cost;

    // Use this for initialization
    void Start () {
		Gold = 100000;
		Wave = 0;
		switchCam = 0;

		currentTower = 1;
		currentPowerup = 1;
        currentExtraPosition = 1;

        InvokeRepeating("increaseMana", 0f, 1f);
        SetHealth(0f);

        towerInfo = new List<TowersInfo>();
        initializeTowerInfo();
    }

    public void decreseHealth(float damage)
    {

        cur_health += damage;
        float calc_health = cur_health / 1000f;
        SetHealth(calc_health);
    }

    public void increaseGold(int enemyGold)
    {

        Gold += enemyGold;
        
    }

    public void decreaseGold(int towerGold)
    {
        Debug.Log("Me has restado Gold: " + towerGold); 
       
        if (Gold >= towerGold)
        {
            Gold -= towerGold;
        }else
        {
            //TODO nopuedes
        }

    }

    public void increaseMana( )
    {
        if (cur_mana + 25f < 1000f) { 
            cur_mana += 25f;
            float calc_mana = cur_mana / 1000f;
            SetMana(calc_mana);
        }
    }

    public void decreaseMana(float decreaseMana)
    {
        if (cur_mana > decreaseMana)
        {
            cur_mana -= decreaseMana;
            float calc_mana = cur_mana / 1000f;
            SetMana(calc_mana);
        }else
        {
            //TODO no puedes man
        }
    }

    public void increaseManaEnemy(float enemyMana)
    {
        if (cur_mana + enemyMana < 1000f)
        {
            cur_mana += enemyMana;
            float calc_mana = cur_mana / 1000f;
            SetMana(calc_mana);
        }
    }

    void SetHealth(float myHealth)
    {
        BarHealth.fillAmount = myHealth;
    }
    
    void SetMana(float myHealth)
    {
        BarMana.fillAmount = myHealth;
    }

    // Update is called once per frame
    void Update () {
		if (switchCam == 1) {
			//VuforiaBehaviour.Instance.enabled = false;

		} else {
			//VuforiaBehaviour.Instance.enabled = true;

		}

		if (gameOver == true) {
			endGame (1);
		}
		if (gameOver == false && cur_health >= 1000) {
			endGame (0);
		}

        showInfoHealthAndMoral();
        showInfoCanvas();

	}

	void endGame(int how){
		if (how == 0) {
			//Lose
			SceneManager.LoadScene (2); //2 = GameOver
		} else {
			//Win
            if (level == 0)
            {
                SceneManager.LoadScene(5);
            } else if (level == 1)
            {
                SceneManager.LoadScene(3); //3 = Victory
            }
            level += 1;
		}
	}

    public void hasDetectedScenario()
    {
        hasLoadedScenario = true;
    }

    public void showInfoCanvas()
    {
        ButtonBehaviourScript buttonBehaviourScript = GameObject.Find("ButtonBehaviour").GetComponent<ButtonBehaviourScript>();
        if (buttonBehaviourScript.activeTowerSelectionLeft == true)
        {
            switch (currentTower)
            {
                case 1:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 1");
                        TowerData towerData = towerInfo[0].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Tower Arrow";
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = true;
                        textLabelCost.text = towerData.gold_cost.ToString();
                        if (Gold < towerData.gold_cost)
                        {
                            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        else
                        {
                            Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = true;
                    }
                    break;
                case 2:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 2");
                        TowerData towerData = towerInfo[1].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Tower Halberd";                  
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = true;
                        textLabelCost.text = towerData.gold_cost.ToString();
                        if (Gold < towerData.gold_cost)
                        {
                            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        else
                        {
                            Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = true;
                    }
                    break;
                case 3:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 3");
                        TowerData towerData = towerInfo[2].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Tower Crossbow";
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = true;
                        textLabelCost.text = towerData.gold_cost.ToString();
                        if (Gold < towerData.gold_cost)
                        {
                            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        else
                        {
                            Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = true;
                    }
                    break;
                case 4:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 4");
                        TowerData towerData = towerInfo[3].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Tower Cannon";
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = true;
                        textLabelCost.text = towerData.gold_cost.ToString();
                        if (Gold < towerData.gold_cost)
                        {
                            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        else
                        {
                            Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = true;
                    }
                    break;
                case 5:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 5");
                        TowerData towerData = towerInfo[4].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Tower Catapult";
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = true;
                        textLabelCost.text = towerData.gold_cost.ToString();
                        if (Gold < towerData.gold_cost)
                        {
                            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        else
                        {
                            Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                            textLabelCost.color = color;
                        }
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = true;
                    }
                    break;
            }
        }

        if (buttonBehaviourScript.activeExtraLeft == true)
        {
            switch (currentExtraPosition)
            {
                case 1:
                    {
                        if (towerTouched != null)
                        {
                            TowerData towerDataAux = towerTouched.GetComponent<TowerData>();
                            TowerData towerData = null;
                            if (towerDataAux.level == 1)
                            {
                                towerData = towerInfo[(towerDataAux.type_tower - 1)].LVL2.GetComponent<TowerData>();
                                Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                                textLabelTower.text = "Tower Arrow (Level 2)";
                            }
                            if (towerDataAux.level == 2)
                            {
                                towerData = towerInfo[(towerDataAux.type_tower - 1)].LVL3.GetComponent<TowerData>();
                                Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                                textLabelTower.text = "Tower Arrow (Level 3)";
                            }
                            Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                            textLabelCost.enabled = true;
                            textLabelCost.text = towerData.gold_cost.ToString();
                            if (Gold < towerData.gold_cost)
                            {
                                Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                                textLabelCost.color = color;
                            }
                            else
                            {
                                Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                                textLabelCost.color = color;
                            }
                            Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                            textLabelCostFixed.enabled = true;
                        }
                    }
                    break;
                case 2:
                    {
                        //Debug.Log("[G] ENTRA EN CASE 2");
                        //TowerData towerData = towerInfo[1].LVL1.GetComponent<TowerData>();
                        Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                        textLabelTower.text = "Back";
                        Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                        textLabelCost.enabled = false;
                        Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                        textLabelCostFixed.enabled = false;
                    }
                    break;
                case 3:
                    {
                        if (towerTouched != null)
                        {
                            TowerData towerDataAux = towerTouched.GetComponent<TowerData>();
                            Text textLabelTower = TextLabelInfoRightTower.GetComponent<Text>();
                            textLabelTower.text = "Destroy Tower Arrow (Level " + towerDataAux.level.ToString() + ")";
                            Text textLabelCost = TextLabelInfoRightCost.GetComponent<Text>();
                            textLabelCost.enabled = true;
                            textLabelCost.text = towerDataAux.ret_gold.ToString();
                            Color color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                            textLabelCost.color = color;
                            Text textLabelCostFixed = GameObject.Find("TextLabelLeftLine2").GetComponent<Text>();
                            textLabelCostFixed.enabled = true;
                        }
                        
                    }
                    break;
            }


        }
        

        switch (currentPowerup)
        {
            case 1:
                { 
                    Text textLabelRightInfoPowerUp = GameObject.Find("TextLabelRightLine1").GetComponent<Text>();
                    textLabelRightInfoPowerUp.text = "Barrier";
                    Text textLabelRightCostPowerUp = GameObject.Find("TextLabelRightLine2Cost").GetComponent<Text>();
                    if (cur_mana > barrier_powerup_cost)
                    {
                        Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = barrier_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    } else
                    {
                        Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = barrier_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                }
                break;
            case 2:
                { 
                    Text textLabelRightInfoPowerUp = GameObject.Find("TextLabelRightLine1").GetComponent<Text>();
                    textLabelRightInfoPowerUp.text = "Damage";
                    Text textLabelRightCostPowerUp = GameObject.Find("TextLabelRightLine2Cost").GetComponent<Text>();
                    if (cur_mana > damage_powerup_cost)
                    {
                        Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = damage_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                    else
                    {
                        Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = damage_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                }
                break;
            case 3:
                { 
                    Text textLabelRightInfoPowerUp = GameObject.Find("TextLabelRightLine1").GetComponent<Text>();
                    textLabelRightInfoPowerUp.text = "Trap";
                    Text textLabelRightCostPowerUp = GameObject.Find("TextLabelRightLine2Cost").GetComponent<Text>();
                    if (cur_mana > trap_powerup_cost)
                    {
                        Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = trap_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                    else
                    {
                        Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = trap_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                }
                break;
            case 4:
                { 
                    Text textLabelRightInfoPowerUp = GameObject.Find("TextLabelRightLine1").GetComponent<Text>();
                    textLabelRightInfoPowerUp.text = "Arrow Storm";
                    Text textLabelRightCostPowerUp = GameObject.Find("TextLabelRightLine2Cost").GetComponent<Text>();
                    if (cur_mana > arrows_powerup_cost)
                    {
                        Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = arrows_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                    else
                    {
                        Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = arrows_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                }
                break;
            case 5:
                { 
                    Text textLabelRightInfoPowerUp = GameObject.Find("TextLabelRightLine1").GetComponent<Text>();
                    textLabelRightInfoPowerUp.text = "Fireball";
                    Text textLabelRightCostPowerUp = GameObject.Find("TextLabelRightLine2Cost").GetComponent<Text>();
                    if (cur_mana > fireball_powerup_cost)
                    {
                        Color color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = fireball_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                    else
                    {
                        Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        textLabelRightCostPowerUp.text = fireball_powerup_cost.ToString();
                        textLabelRightCostPowerUp.color = color;
                    }
                }
                break;
        }

            
        //currentTower
    }

    void showInfoHealthAndMoral()
    {
        Text textLabelHealth = GameObject.FindGameObjectWithTag("textLabelLifeQuantity").GetComponent<Text>();
        textLabelHealth.text = (max_health - cur_health).ToString() + "/" + max_health;
        Text textLabelMoral = GameObject.FindGameObjectWithTag("textLabelMoralQuantity").GetComponent<Text>();
        textLabelMoral.text = (cur_mana).ToString() + "/" + max_mana;
    }


    void initializeTowerInfo()
    {
        

        Debug.Log("HOLA");
        GameObject LVL1 = Resources.Load("Prefabs/Tower_Arrow", typeof(GameObject)) as GameObject;
        GameObject LVL2 = Resources.Load("Prefabs/Tower_Arrow_LVL2", typeof(GameObject)) as GameObject;
        GameObject LVL3 = Resources.Load("Prefabs/Tower_Arrow_LVL3", typeof(GameObject)) as GameObject;
        TowersInfo towerInfoData = new TowersInfo(LVL1, LVL2, LVL3);

        Debug.Log("HOLA2");

        towerInfo.Add(towerInfoData);
        
        LVL1 = Resources.Load("Prefabs/Tower_Halberd", typeof(GameObject)) as GameObject;
        LVL2 = Resources.Load("Prefabs/Tower_Halberd_LVL2", typeof(GameObject)) as GameObject;
        LVL3 = Resources.Load("Prefabs/Tower_Halberd_LVL3", typeof(GameObject)) as GameObject;
        towerInfoData = new TowersInfo(LVL1, LVL2, LVL3);
        towerInfo.Add(towerInfoData);
        

        LVL1 = Resources.Load("Prefabs/TowerCrossbowLVL1", typeof(GameObject)) as GameObject;
        LVL2 = Resources.Load("Prefabs/TowerCrossbowLVL2", typeof(GameObject)) as GameObject;
        LVL3 = Resources.Load("Prefabs/TowerCrossbowLVL3", typeof(GameObject)) as GameObject;
        towerInfoData = new TowersInfo(LVL1, LVL2, LVL3);
        towerInfo.Add(towerInfoData);

        
        LVL1 = Resources.Load("Prefabs/TowerCannonLVL1", typeof(GameObject)) as GameObject;
        LVL2 = Resources.Load("Prefabs/TowerCannonLVL2", typeof(GameObject)) as GameObject;
        LVL3 = Resources.Load("Prefabs/TowerCannonLVL3", typeof(GameObject)) as GameObject;
        towerInfoData = new TowersInfo(LVL1, LVL2, LVL3);
        towerInfo.Add(towerInfoData);

        LVL1 = Resources.Load("Prefabs/TowerCatapultLVL1", typeof(GameObject)) as GameObject;
        LVL2 = Resources.Load("Prefabs/TowerCatapultLVL2", typeof(GameObject)) as GameObject;
        LVL3 = Resources.Load("Prefabs/TowerCatapultLVL3", typeof(GameObject)) as GameObject;
        towerInfoData = new TowersInfo(LVL1, LVL2, LVL3);
        towerInfo.Add(towerInfoData);
        
        Debug.Log("Initialized Tower Info");
    }
}
