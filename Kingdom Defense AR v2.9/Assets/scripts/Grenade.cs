using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Grenade : MonoBehaviour {
	[SerializeField]GameObject explosionParticleEffect;
	[SerializeField]float explosionRadius = 5f;
	[SerializeField]float explosionForce = 20f;
	[SerializeField]LayerMask effectedLayers;
    [SerializeField] float damageProjectile = 20.0f;
    public List<GameObject> enemiesInRange;

    private GameManagerBehavior gameManager;

    soundManager _soundManager;

    void OnCollisionEnter(Collision col)
	{
		Instantiate (explosionParticleEffect, col.contacts [0].point, col.transform.rotation);
        _soundManager.playExplosionSoundEffect();
		AddExplosiveForce (col.contacts [0].point);
		Destroy (gameObject);
		showNewProjectile ();
	}


	void AddExplosiveForce(Vector3 centerOfExplosion)
	{
		//get all of the colliders we hit with thsis explosion (OverlapSphere)
		Collider[] thingsIHit = UnityEngine.Physics.OverlapSphere(centerOfExplosion, explosionRadius, effectedLayers);

		//if what we hit has a Rigidbody, then add some force to it.
		foreach(Collider hit in thingsIHit){
			if (hit.GetComponent<Rigidbody> () != null) {
				hit.GetComponent<Rigidbody> ().AddExplosionForce (explosionForce, centerOfExplosion, explosionRadius, 1, ForceMode.Impulse); 
			}

		}

	}
	void showNewProjectile () {
		GameObject crossbow = GameObject.Find ("Crossbow");
		GameObject staticArrow = crossbow.gameObject.transform.GetChild (0).gameObject;
		Renderer rend = staticArrow.GetComponent<Renderer> ();
		rend.enabled = true;
	}

	// Use this for initialization
	void Start () {
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
    }

    // Update is called once per frame
    void Update () {
	    foreach (GameObject enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                PlayerHealth enemyHealth = enemy.GetComponent<PlayerHealth>();
                enemyHealth.currentHealth -= Mathf.Max(damageProjectile, 0);
                if (enemyHealth.currentHealth <= 0)
                {
                    MoveEnemy moveEnemy = enemy.GetComponent<MoveEnemy>();
                    gameManager.increaseGold(moveEnemy.gold);
                    gameManager.increaseManaEnemy(moveEnemy.mana);

                    Destroy(enemy);
                }
            }
        }
	}

    void OnEnemyDestroy (GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals ("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals ("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }   
    }




}
