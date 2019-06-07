using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	public float speed = 10;
	public int damage;
	public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;

	private float distance;
	private float startTime;

	private GameManagerBehavior gameManager;

    soundManager _soundManager;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		distance = Vector3.Distance (startPosition, targetPosition);
		GameObject gm = GameObject.Find ("GameManager");
		gameManager = gm.GetComponent<GameManagerBehavior> ();
        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();

    }

    // Update is called once per frame
    void Update () {
		/*
		 * 1. You calculate the new bullet positin using Vector3.Lerp to interpolate between start and end positions.
		 */ 
		float timeInterval = Time.time - startTime;
		gameObject.transform.position = Vector3.Lerp (startPosition, targetPosition, timeInterval * speed / distance);

		/*
		 * 2. If the bullet reaches the targetPosition, you verify that target still exists.
		 */ 

		if (gameObject.transform.position.Equals (targetPosition)) {
			//Debug.Log ("Target Position: " + targetPosition + " TARGET: " + target);
			if (target != null) {

				/*
				 * 3. You retrieve the target's HealthBar component and reduce its health by the bullet's damage
				 */ 
				//Transform healthVarTransform = target.transform.FindChild ("healthbar");
				//HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar> ();

				PlayerHealth playerHealth = target.gameObject.GetComponent<PlayerHealth> ();
				playerHealth.currentHealth -= Mathf.Max (damage, 0);
				/*
				 * 4. If the health of the enemy falls to zero, you destroy it, play a sound effect and reward the player for markmanship.
				 */ 
				if (playerHealth.currentHealth <= 0) {
					GameObject target_child = target.transform.GetChild (0).gameObject;
                    //					target_child.AddComponent<FadeAlpha>();
                    //					FadeAlpha fadeAlpha = target_child.GetComponent<FadeAlpha> ();
                    //					fadeAlpha.timeStartFade = Time.time;
                    //					if (target != null) {
                    //						GameObject target_health = target.transform.GetChild (1).gameObject;
                    //						Destroy (target_health);
                    //					}
                    MoveEnemy moveEnemy = target.gameObject.GetComponent<MoveEnemy>();
                   
                    gameManager.increaseGold(moveEnemy.gold);
                    gameManager.increaseManaEnemy(moveEnemy.mana);

                    _soundManager.playSoundMoneyGained();

                    Destroy(target);

                    //TODO: Cosas de audio
                    
				}
			}
			Destroy (gameObject);

		}
	}
}
