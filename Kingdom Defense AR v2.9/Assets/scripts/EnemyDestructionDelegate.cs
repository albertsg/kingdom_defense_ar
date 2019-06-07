using UnityEngine;
using System.Collections;

public class EnemyDestructionDelegate : MonoBehaviour {
	public delegate void EnemyDelegate (GameObject EnemyDestructionDelegate);
	public EnemyDelegate enemyDelegate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onDestroy () {
		if (enemyDelegate != null) {
			enemyDelegate (gameObject);
		}

	}


}
