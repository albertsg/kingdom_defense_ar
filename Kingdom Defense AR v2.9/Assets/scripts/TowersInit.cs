using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersInit : MonoBehaviour {
	private GameObject crossbow;
	private GameObject arrow;
	private GameObject haldberd;
	private GameObject cannon;
	private GameObject catapult;


	private Rigidbody gravity;

	private BoxCollider bcol;
	private SphereCollider scol;

	private GameObject imgtar;
	private int c;

	private GameObject gameManager;
	private GameManagerBehavior gmb;

    soundManager _soundManager;


    // Use this for initialization
    void Start () {
		//crossbow = imgtar.GetComponentsInChildren
		crossbow = GameObject.Find ("ImageTargetTowers/Crossbow");
		crossbow = GameObject.Find ("ImageTargetTowers/Haldberd");
		crossbow = GameObject.Find ("ImageTargetTowers/Cannon");
		crossbow = GameObject.Find ("ImageTargetTowers/Arrow");
		crossbow = GameObject.Find ("ImageTargetTowers/Catapult");


		imgtar = GameObject.Find ("ImageTargetTowers");
		gravity = crossbow.GetComponent<Rigidbody> ();
		bcol = crossbow.GetComponent<BoxCollider>();
		scol = crossbow.GetComponent<SphereCollider>();

		gameManager = GameObject.Find ("GameManager");
		gmb = gameManager.GetComponent<GameManagerBehavior> ();

        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


	/*TOWERS*/
	/*Arrow  Haldberd - Crossbow - Catapult - Cannon*/

	public void Arrow(){
        //Arrow price = 20000;
        _soundManager.playSoundButton();
		arrow = GameObject.Find ("ImageTargetTowers/Arrow");//Para actualizar la crossbow a la que se hace referencia
		TowerData td = arrow.GetComponent<TowerData>();
		if (gmb.Gold >= td.gold_cost) {
			//arrow = GameObject.Find ("ImageTargetTowers/Arrow");//Para actualizar la crossbow a la que se hace referencia
			//Info sobre la crossbow, todos los elementos de dentro
			gravity = arrow.GetComponent<Rigidbody> ();
			bcol = arrow.GetComponent<BoxCollider>();
			scol = arrow.GetComponent<SphereCollider>();
			newArrow (); //Antes, así podemos usar las coordenadas de la torre anterior

			Debug.Log ("DENTRO DE ARROW!!!");
			GameObject parent = GameObject.Find ("escenary").gameObject;
			arrow.transform.SetParent (parent.transform);

			bcol.enabled = true;
			//scol.enabled = false;
			arrow.GetComponent<ShootEnemies> ().enabled = true;

			gravity.isKinematic = false;
			gravity.useGravity = true;
			//scol.enabled = true;
            TowerData towerData = arrow.GetComponent<TowerData>();
            towerData.active = true;

			gravity.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Debug.Log ("GRAVEDAD ACTIVADA");
            arrow.GetComponent<detectedTouchedGround>().enabled = true;
            

            //GameObject particleSysTouches = Instantiate(Resources.Load("Prefabs/ETF_Touches_Ground", typeof(GameObject))) as GameObject;
            //Instantiate(explosionParticleEffect, col.contacts[0].point, col.transform.rotation);
            // particleSysTouches.GetComponent<particleSystemBehaviour>().startParticleSystem();

            c++;
			Debug.Log (c);

			gmb.decreaseGold (td.gold_cost); //Estaría bien añadir el campo GOLD a la torre
			arrow = GameObject.Find ("ImageTargetTowers/Arrow");//Para actualizar la arrow a la que se hace referencia

		} else {
			
		}

	}

	public void Haldberd(){
        _soundManager.playSoundButton();
        haldberd = GameObject.Find ("ImageTargetTowers/Haldberd");//Para actualizar la crossbow a la que se hace referencia
		TowerData td = haldberd.GetComponent<TowerData>();
		//Haldberd price = 15000;
		if (gmb.Gold >= td.gold_cost) {
			//haldberd = GameObject.Find ("ImageTargetTowers/Haldberd");//Para actualizar la crossbow a la que se hace referencia
			//Info sobre la crossbow, todos los elementos de dentro
			gravity = haldberd.GetComponent<Rigidbody> ();
			bcol = haldberd.GetComponent<BoxCollider>();
			scol = haldberd.GetComponent<SphereCollider>();
			newHaldberd (); //Antes, así podemos usar las coordenadas de la torre anterior

			Debug.Log ("DENTRO DE HALDBERD!!!");
			GameObject parent = GameObject.Find ("escenary").gameObject;
			haldberd.transform.SetParent (parent.transform);

			bcol.enabled = true;
			//scol.enabled = false;
			//haldberd.GetComponent<ShootEnemies> ().enabled = true; -->ACTIVAR CUANDO SE LE AÑADA ESTE SCRIPT

			gravity.isKinematic = false;
			gravity.useGravity = true;
			//scol.enabled = true;
            TowerData towerData = haldberd.GetComponent<TowerData>();
            towerData.active = true;

            gravity.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Debug.Log ("GRAVEDAD ACTIVADA");

            haldberd.GetComponent<detectedTouchedGround>().enabled = true;


            c++;
			Debug.Log (c);

			gmb.decreaseGold (td.gold_cost);

			haldberd = GameObject.Find ("ImageTargetTowers/Haldberd");//Para actualizar la haldberd a la que se hace referencia

		} else {
			
		}

	}
	public void Catapult(){
        _soundManager.playSoundButton();
        catapult = GameObject.Find ("ImageTargetTowers/Catapult");//Para actualizar la crossbow a la que se hace referencia
		TowerData td = catapult.GetComponent<TowerData>();
		//Catapult price = 40000;
		if (gmb.Gold >= td.gold_cost) {
			//catapult = GameObject.Find ("ImageTargetTowers/Catapult");//Para actualizar la crossbow a la que se hace referencia
			//Info sobre la crossbow, todos los elementos de dentro
			gravity = catapult.GetComponent<Rigidbody> ();
			bcol = catapult.GetComponent<BoxCollider>();
			scol = catapult.GetComponent<SphereCollider>();
			newCatapult (); //Antes, así podemos usar las coordenadas de la torre anterior

			Debug.Log ("DENTRO DE CATAPULT!!!");
			GameObject parent = GameObject.Find ("escenary").gameObject;
			catapult.transform.SetParent (parent.transform);

			bcol.enabled = true;
			//scol.enabled = false;
			catapult.GetComponent<ShootEnemies> ().enabled = true;

			gravity.isKinematic = false;
			gravity.useGravity = true;
			//
            //scol.enabled = true;
            TowerData towerData = catapult.GetComponent<TowerData>();
            towerData.active = true;

            gravity.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Debug.Log ("GRAVEDAD ACTIVADA");

            catapult.GetComponent<detectedTouchedGround>().enabled = true;


            c++;
			Debug.Log (c);

			gmb.decreaseGold (td.gold_cost);

			catapult = GameObject.Find ("ImageTargetTowers/Catapult");//Para actualizar la catapult a la que se hace referencia

		} else {
			
		}

	}
	public void Cannon(){
        _soundManager.playSoundButton();
        cannon = GameObject.Find ("ImageTargetTowers/Cannon");//Para actualizar la crossbow a la que se hace referencia
		TowerData td = cannon.GetComponent<TowerData>();
		//Cannon price = 70000
		if (gmb.Gold >= td.gold_cost) {
			//cannon = GameObject.Find ("ImageTargetTowers/Cannon");//Para actualizar la crossbow a la que se hace referencia
			//Info sobre la crossbow, todos los elementos de dentro
			gravity = cannon.GetComponent<Rigidbody> ();
			bcol = cannon.GetComponent<BoxCollider>();
			scol = cannon.GetComponent<SphereCollider>();
			newCannon (); //Antes, así podemos usar las coordenadas de la torre anterior

			Debug.Log ("DENTRO DE CANNON!!!");
			GameObject parent = GameObject.Find ("escenary").gameObject;
			cannon.transform.SetParent (parent.transform);

			bcol.enabled = true;
			//scol.enabled = false;
			cannon.GetComponent<ShootEnemies> ().enabled = true; 

			gravity.isKinematic = false;
			gravity.useGravity = true;
			//scol.enabled = true;
            TowerData towerData = cannon.GetComponent<TowerData>();
            towerData.active = true;

            gravity.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Debug.Log ("GRAVEDAD ACTIVADA");

            cannon.GetComponent<detectedTouchedGround>().enabled = true;


            c++;
			Debug.Log (c);

			gmb.decreaseGold(td.gold_cost);

			cannon = GameObject.Find ("ImageTargetTowers/Cannon");//Para actualizar la arrow a la que se hace referencia

		} else {
			
		}

	}


	public void Crossbow(){
        _soundManager.playSoundButton();
        crossbow = GameObject.Find ("ImageTargetTowers/Crossbow");//Para actualizar la crossbow a la que se hace referencia
		TowerData td = crossbow.GetComponent<TowerData>();
		//Crossbow price = 30000
		if (gmb.Gold >= td.gold_cost) {
			//crossbow = GameObject.Find ("ImageTargetTowers/Crossbow");//Para actualizar la crossbow a la que se hace referencia
			//Info sobre la crossbow, todos los elementos de dentro
			gravity = crossbow.GetComponent<Rigidbody> ();
			bcol = crossbow.GetComponent<BoxCollider>();
			scol = crossbow.GetComponent<SphereCollider>();
			newCrossbow (); //Antes, así podemos usar las coordenadas de la torre anterior

			Debug.Log ("DENTRO DE CROSSBOW!!!");
			GameObject parent = GameObject.Find ("escenary").gameObject;
			crossbow.transform.SetParent (parent.transform);

			bcol.enabled = true;
			//scol.enabled = false;
			crossbow.GetComponent<ShootEnemies> ().enabled = true;

			gravity.isKinematic = false;
			gravity.useGravity = true;
			//scol.enabled = true;
            TowerData towerData = crossbow.GetComponent<TowerData>();
            towerData.active = true;


            gravity.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			Debug.Log ("GRAVEDAD ACTIVADA");

            crossbow.GetComponent<detectedTouchedGround>().enabled = true;


            c++;
			Debug.Log (c);

			gmb.decreaseGold (td.gold_cost);

			crossbow = GameObject.Find ("ImageTargetTowers/Crossbow");//Para actualizar la crossbow a la que se hace referencia



		} else {
		
		}
			
	}

	private void newCrossbow(){

		GameObject parentTow = GameObject.Find ("ImageTargetTowers").gameObject;
		GameObject newcross;
		newcross = Instantiate (crossbow, crossbow.transform.position, crossbow.transform.rotation) as GameObject; 
	
		newcross.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño
		newcross.transform.position = crossbow.transform.position;
	

		Rigidbody newrb = newcross.GetComponent<Rigidbody> ();
		newrb.useGravity = false;


		var pos = newcross.transform.position;
		pos.y += 1;
		newcross.transform.position = pos;

		BoxCollider bc;
		SphereCollider sc;

		bc = newcross.GetComponent<BoxCollider> ();
		sc = newcross.GetComponent<SphereCollider> ();

        newcross.GetComponent<detectedTouchedGround>().enabled = false;


        bc.enabled = false;
		sc.enabled = false;

		newcross.name = "Crossbow";

	}

	private void newHaldberd(){
		GameObject parentTow = GameObject.Find ("ImageTargetTowers").gameObject;
		GameObject newhaldberd;
		newhaldberd = Instantiate (haldberd, haldberd.transform.position, haldberd.transform.rotation) as GameObject; 

		newhaldberd.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño
		newhaldberd.transform.position = haldberd.transform.position;


		Rigidbody newrb = newhaldberd.GetComponent<Rigidbody> ();
		newrb.useGravity = false;


		var pos = newhaldberd.transform.position;
		pos.y += 1;
		newhaldberd.transform.position = pos;

		BoxCollider bc;
		SphereCollider sc;

		bc = haldberd.GetComponent<BoxCollider> ();
		sc = haldberd.GetComponent<SphereCollider> ();

        haldberd.GetComponent<detectedTouchedGround>().enabled = false;


        bc.enabled = false;
		sc.enabled = false;

		haldberd.name = "Haldberd";

	}

	private void newArrow(){
		GameObject parentTow = GameObject.Find ("ImageTargetTowers").gameObject;
		GameObject newarrow;
		newarrow = Instantiate (arrow, arrow.transform.position, arrow.transform.rotation) as GameObject; 

		newarrow.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño
		newarrow.transform.position = arrow.transform.position;


		Rigidbody newrb = newarrow.GetComponent<Rigidbody> ();
		newrb.useGravity = false;


		var pos = newarrow.transform.position;
		pos.y += 1;
		newarrow.transform.position = pos;

		BoxCollider bc;
		SphereCollider sc;

		bc = newarrow.GetComponent<BoxCollider> ();
		sc = newarrow.GetComponent<SphereCollider> ();

        newarrow.GetComponent<detectedTouchedGround>().enabled = false;


        bc.enabled = true;
		sc.enabled = false;

		newarrow.name = "Arrow";

	}

	private void newCatapult(){
		GameObject parentTow = GameObject.Find ("ImageTargetTowers").gameObject;
		GameObject newcatapult;
		newcatapult = Instantiate (catapult, catapult.transform.position, catapult.transform.rotation) as GameObject; 

		newcatapult.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño
		newcatapult.transform.position = catapult.transform.position;


		Rigidbody newrb = newcatapult.GetComponent<Rigidbody> ();
		newrb.useGravity = false;


		var pos = newcatapult.transform.position;
		pos.y += 1;
		newcatapult.transform.position = pos;

		BoxCollider bc;
		SphereCollider sc;

		bc = newcatapult.GetComponent<BoxCollider> ();
		sc = newcatapult.GetComponent<SphereCollider> ();

        newcatapult.GetComponent<detectedTouchedGround>().enabled = false;

        bc.enabled = false;
		sc.enabled = false;

		newcatapult.name = "Catapult";

	}

	private void newCannon(){
		GameObject parentTow = GameObject.Find ("ImageTargetTowers").gameObject;
		GameObject newcannon;
		newcannon = Instantiate (cannon, cannon.transform.position, cannon.transform.rotation) as GameObject; 

		newcannon.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño
		newcannon.transform.position = cannon.transform.position;


		Rigidbody newrb = newcannon.GetComponent<Rigidbody> ();
		newrb.useGravity = false;


		var pos = newcannon.transform.position;
		pos.y += 1;
		newcannon.transform.position = pos;

		BoxCollider bc;
		SphereCollider sc;

		bc = newcannon.GetComponent<BoxCollider> ();
		sc = newcannon.GetComponent<SphereCollider> ();

        newcannon.GetComponent<detectedTouchedGround>().enabled = false;

        bc.enabled = false;
		sc.enabled = false;

		newcannon.name = "Cannon";

	}



}
