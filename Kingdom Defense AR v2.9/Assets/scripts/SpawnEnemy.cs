using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
	public GameObject[] enemyPrefab;
	public float spawnInterval = 2;
	public int maxEnemies = 20;
}
public class SpawnEnemy : MonoBehaviour {
	public GameObject[] waypoints;
	public GameObject testEnemyPrefab;

	public Wave[] waves;
	public int timeBetweenWaves = 5;

	private GameManagerBehavior gameManager;

	private float lastSpawnTime;
	private int enemiesSpawned = 0;

	private Random rnd = new Random();

    soundManager _soundManager;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.time;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();

    }

    // Update is called once per frame
    void Update () {
		/*
		 *	1. Get the index of the current wave, and check if it's the last one.
		 */ 
		int currentWave = gameManager.Wave;
		if (currentWave < waves.Length && gameManager.hasLoadedScenario) {
			/*
			 * 2. If so, calculate how much time passed since the last enemy soawn and whether it's time to spawn an enemy.
			 * Here you consider two cases. If it's the first enemy in the wave, you check whether timeInterval is bigger
			 * than timeBetweenWaves. Otherwise, you check wehther timeInterval is bigger than this wave's spawnInterval.
			 * In either case, you make sure you haven't spawned all the enemies for this wave.
			 */ 
			float timeInterval = Time.time - lastSpawnTime;
			float spawnInterval = waves [currentWave].spawnInterval;
			if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemiesSpawned < waves [currentWave].maxEnemies) {
				/*
				 * 3. If necesary, spawn an enemy by instantiating a copy of enemyPrefab. You also increase the enemiesSpawned count.
				 */ 
				lastSpawnTime = Time.time;


				int randomNumber = Random.Range (0, 9);

				if (randomNumber < 3) {
					if (randomNumber < 1) {
						GameObject newEnemy = (GameObject)Instantiate (waves [currentWave].enemyPrefab [1]);
						newEnemy.GetComponent<MoveEnemy> ().waypoints = waypoints;
						enemiesSpawned++;
					} else {
						GameObject newEnemy = (GameObject)Instantiate (waves [currentWave].enemyPrefab [2]);
						newEnemy.GetComponent<MoveEnemy> ().waypoints = waypoints;
						enemiesSpawned++;
					}
				} else {
					GameObject newEnemy = (GameObject)Instantiate (waves [currentWave].enemyPrefab [0]);
					newEnemy.GetComponent<MoveEnemy> ().waypoints = waypoints;
					enemiesSpawned++;
				}
			}
			/*
			 *	4. You also check the number of enemies on screen. If there are none and it was the last enemy in the wave you spawn the next wave.
			 *	You also give the player 10 percent of all gold left at the end of the wave.
			 */ 
			if (enemiesSpawned == waves [currentWave].maxEnemies && GameObject.FindGameObjectWithTag ("Enemy") == null) {
                _soundManager.playSoundEndRound();
				gameManager.Wave++;
				gameManager.Gold = Mathf.RoundToInt (gameManager.Gold * 1.1f);
				enemiesSpawned = 0;
				lastSpawnTime = Time.time;
			}
			/*
			 *	5. Upon beating the last wave this runs the game won animation.
			 */ 
		} else {
            /*
			 * gameOver stuff and text.
			 */
             if (gameManager.hasLoadedScenario) { 
                gameManager.gameOver = true;
                gameManager.hasLoadedScenario = false;
            }
        }
	}

}
