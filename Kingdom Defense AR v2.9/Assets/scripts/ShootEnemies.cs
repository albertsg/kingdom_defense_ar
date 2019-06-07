using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEnemies : MonoBehaviour {

	public List<GameObject> enemiesInRange;
	public GameObject bullet;
	public float fireRate;
	private float lastShotTime;
    soundManager _soundManager;

	// Use this for initialization
	void Start () {
		enemiesInRange = new List<GameObject> ();
		lastShotTime = Time.time;

        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
    }

    // Update is called once per frame
    void Update () {
		GameObject target = null;
		/*
		 *	1. Determine the target of the monster. Start with the maximum possible distance in the minimaEnemyDistance
		 *	Iterate over all enemies in range and make an enemy the new target if its distance to the cookie is smaller than 
		 *	the current minimum.
		 */ 
		float minimalEnemyDistance = float.MaxValue;

		foreach (GameObject enemy in enemiesInRange) {
			if (enemy != null) {
				float distanceToGoal = enemy.GetComponent<MoveEnemy> ().distanceToGoal ();
				if (distanceToGoal < minimalEnemyDistance) {
					target = enemy;
					minimalEnemyDistance = distanceToGoal;
				}
			}
		}

		/*
		 *	2. Call Shoot if the time passed is greater than the fire rate of your monster and set lastShotTime to the current time.
		 */ 
		if (target != null) {
			if (Time.time - lastShotTime > fireRate) {

				Shoot (target.GetComponent<Collider> ());
				lastShotTime = Time.time;

			}
			/*
			 *	3. Calculate the rotation angle between the monster and its target. You set the rotation of the monster to this angle. Now 
			 *	it walways faces the target.
			 */ 
			Vector3 direction = gameObject.transform.position - target.transform.position;
			//Vector3 direction = target.transform.position - gameObject.transform.position;
//			direction.Normalize ();
//			forward_vec.Normalize ();
//			float dot_result = Vector3.Dot(direction, forward_vec);
//			float angle_rotation = Mathf.Acos(dot_result);
//			angle_rotation = angle_rotation * 180 / Mathf.PI;
//			gameObject.transform.Rotate(0, angle_rotation, 0, Space.Self);


			if (gameObject.tag.Equals("cannonTowerTag")) {
				Debug.Log ("Torre cannon");
				gameObject.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (0, 1, 0));
			}
			if (gameObject.tag.Equals ("crossbowTowerTag")) {
				//	Debug.Log ("Torre crossbow");
				gameObject.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (0, 1, 0));

				//GameObject crosbowBox = gameObje			ct.transform.GetChild (1).gameObject;
				//Vector3 direction2 = crosbowBox.transform.position - target.transform.position;
				//crosbowBox.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (0, 0, 1));
				//crosbowBox.transform.rotation = Quaternion.AngleAxis (-90.0f, new Vector3 (1, 0, 0));
			}

			if (gameObject.tag.Equals ("arrowTowerTag")) {
				gameObject.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (1, 0, 0));
			}

            if (gameObject.tag.Equals ("cattapultTowerTag")) {
				gameObject.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (0, 1, 0));
			}
		}
	}
	/*
	 * 	1. In OnEnemyDestroy, you remove the enemy from enemiesInRange. When an enemy walks on the trigger around your monster OnTriggerEnter3D is called.
	 */ 
	void OnEnemyDestroy (GameObject enemy) {
		enemiesInRange.Remove (enemy);
	}

	void OnTriggerEnter (Collider other) {
        //Debug.Log("ENTER COLIDER ");
        /*
		 *  2. You then add the enemy to the list of enemiesInRange and add OnEnemyDestroy to the EnemyDestructionDelegate. This makes sure that OnEnemyDestroy is called when the enemy is destroyed.
		 *     You don't want towers to waste ammo on dead enemies now.
		 */
        if (other.gameObject.tag.Equals ("Enemy")) {
			enemiesInRange.Add (other.gameObject);
			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
			del.enemyDelegate += OnEnemyDestroy;
		}
	}
	/*
	 * 	3. In OnTriggerExit you remove the enemy from the list and unregister your delegate. Now you know which enemies are in range.
	 */ 
	void OnTriggerExit (Collider other) {
        //Debug.Log("EXIT COLIDER ");
        if (other.gameObject.tag.Equals ("Enemy")) {
			enemiesInRange.Remove (other.gameObject);
			EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate> ();
			del.enemyDelegate -= OnEnemyDestroy;
		}
	}
    void FixedUpdate()
    {
        //Debug.Log(enemiesInRange);
    }

	void Shoot(Collider target) {
        _soundManager.playSoundArrowShoot();
        GameObject bulletPrefab = bullet;
		/*
		 *	1. Get the start and target positions of the bullet. Set the z-Position to that of bulletPrefab. Earlier, you set 
		 *	the bullet prefab's z position value to make sure the bullet appears ebhind the monster firing it, but in front of the enemies.
		 */ 
		//Vector3 startPosition = gameObject.transform.position;
		//Vector3 startPosition = (12.74f, 11.55f, 6.43f);

		GameObject aux =(GameObject)gameObject.transform.Find ("ProjectileInitPosition").gameObject;
		Vector3 startPosition = aux.transform.position;

		Vector3 targetPosition = target.transform.position;
		//startPosition.z = bulletPrefab.transform.position.z;
		//targetPosition.z = bulletPrefab.transform.position.z;

		/*
		 *	2. Instantiate a new bullet using the bulletPrefab for MonsterLevel. Assign the startPosition and targetPosition of the bullet.
		 */ 
		GameObject newBullet = (GameObject)Instantiate (bulletPrefab);
		newBullet.transform.position = startPosition;

		Vector3 direction = newBullet.transform.position - target.transform.position;
		//gameObject.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (direction.x, direction.z) * 180 / Mathf.PI + 180.0f, new Vector3 (0, 1, 0));


		BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior> ();
		bulletComp.target = target.gameObject;
		bulletComp.startPosition = startPosition;
		bulletComp.targetPosition = targetPosition;



		/*
		 *	3. Make the game juicier: Run a shoot animation and play a laser sound whenever the monster shoots.
		 */ 
		//TODO: Cosas de Animator y sonidos
	}


	//BETA
	void OnCollisionEnter (Collision col){ //Evitaremos que la torre se mueva al colisionar con enemigos
		Rigidbody rigid = gameObject.GetComponent<Rigidbody> ();

		if (col.gameObject.name == "Enemy1(Clone)") { 
			rigid.isKinematic = true;

		}
		if (col.gameObject.name == "Enemy2(Clone)") { 
			rigid.isKinematic = true;

		}
		if (col.gameObject.name == "Enemy3(Clone)") { 
			rigid.isKinematic = true;

		}
		if (col.gameObject.name == "3d_objects_scene") { 
			rigid.isKinematic = true;

		}
		//rigid.isKinematic = true;
		//rigid.useGravity = false;
	}
}
