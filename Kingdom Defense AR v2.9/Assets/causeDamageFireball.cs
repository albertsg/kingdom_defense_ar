using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class causeDamageFireball : MonoBehaviour {

    public List<GameObject> enemiesInRange;
    private GameManagerBehavior gameManager;
    soundManager _soundManager;


    // Use this for initialization
    void Start () {
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playExplosionSoundEffect();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                PlayerHealth enemyHealth = enemy.GetComponent<PlayerHealth>();
                enemyHealth.currentHealth -= Mathf.Max(300, 0);
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

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    public void deactivateOn5seg()
    {
        Invoke("deactiveColliderAndScript", 5);
    }

    void deactiveColliderAndScript()
    {
        GameObject damageFireball = GameObject.Find("ETF_PowerUp_Light ");
        damageFireball.GetComponent<SphereCollider>().enabled = false;
        damageFireball.GetComponent<causeDamageFireball>().enabled = false;

    }
}
