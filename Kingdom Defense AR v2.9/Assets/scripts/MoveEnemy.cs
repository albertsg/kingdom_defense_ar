using UnityEngine;
using System.Collections;



public class MoveEnemy : MonoBehaviour {
	[HideInInspector]
	public GameObject[] waypoints;
	private int currentWaypoint = 0;
	private float lastWaypointSwitchTime;
	public float speed = 1.0f;

	public bool stop;

	private float timeleft;

    public GameObject gameManager;
    private GameManagerBehavior gmb;

    public float damage;
    public float mana;
    public int gold;
    // Use this for initialization
    void Start () {
		lastWaypointSwitchTime = Time.time;
		stop = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (stop == false) {
			/*
			 * 1. From the waypoints array, you retrieve the start and end position for the current path segment.
			 */ 
			Vector3 startPosition = waypoints [currentWaypoint].transform.position;
			Vector3 endPosition = waypoints [currentWaypoint + 1].transform.position;

			/*
			 * 2. Calculate the time needed for the whole distance with the formula time = distance/speed, 
			 * then determine the current time on the path. Using Vector3.Lerp, you interpolate the current 
			 * position of the enemy between the segment's start and end positions.
			 */
			float pathLength = Vector3.Distance (startPosition, endPosition);
			float totalTimeForPath = pathLength / speed;
			float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
			gameObject.transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
			/*
			 * 3. Check whether the enemy has reached the endPosition. If yes, handle these two possible scenarios:
			 */ 
			if (gameObject.transform.position.Equals (endPosition)) {
				if (currentWaypoint < waypoints.Length - 2) {
					/*
					 * 3.a. The enemy is not yet at the last waypoint, so increase currentWaypoint and update lastWaypointSwitchTime. 
					 * Later, you'll add code to rotate the enemy so it points in the direction it's moving too.
					 */ 
					currentWaypoint++;
					lastWaypointSwitchTime = Time.time;
					RotateIntoMoveDirection ();
				} else {
                    /*
					 * 3.b The enemy reached the last waypoint, so this destroys it and triggers a sound effect. Later you'll add
					 * code to decrease the player's health, too.
					 */
                    gameManager = GameObject.Find("GameManager");
                    gmb = gameManager.GetComponent<GameManagerBehavior>();

                    Destroy(gameObject);
                    gmb.decreseHealth(damage);


                    //TODO: AudioSource Stuff
                    /* 
					 * AudioSource audioSource = gameObject.GetComponent<AudioSource>();
					 * AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
					 */
                    //TODO: deduct health

                }
            }

			//		if (currentWaypoint == 1) {
			//			Vector3 temp = new Vector3 (0.0f, 5.0f, 0.0f);
			//			gameObject.transform.position += temp; 
			//		}
			//		if (currentWaypoint == 1) {
			//			Vector3 temp = new Vector3 (0.0f, 5.0f, 0.0f);
			//			gameObject.transform.position -= temp; 
			//		}

		} else {

			timeleft -= Time.deltaTime;
			if (timeleft < 0) {
				stop = false;
			}

		}

	}

	private void RotateIntoMoveDirection() {
		/*
		 * 1. It calculates the bug's current movement direction by substracting
		 * the current waypoint's position from that of the next waypoint;
		 */ 
		Vector3 newStartPosition = waypoints [currentWaypoint].transform.position;
		Vector3 newEndPosition = waypoints [currentWaypoint + 1].transform.position;
		Vector3 newDirection = (newEndPosition - newEndPosition);

		/*
		 * 2. It uses Mathf.Atan2 to determine the angle toward which newDirection
		 * points, in radians, assuming zero points to the right. Multiplying the
		 * result by 180 / Mathf.PI converts the angle to degrees.
		 */ 
		float x = newDirection.x;
		float z = newDirection.z;
		float rotationAngle = Mathf.Atan2 (z, x) * 180 / Mathf.PI;

		/*
		 * 3. Finally it retrieves the child named mesh and rotates it rotationAngle
		 * degrees along the z-axis. Note that you rotate the child instead of the parent so the health bar
		 * -you'll add soon- remains horizontal.
		 */

		if (gameObject.name == "Enemy1") {
			GameObject mesh = (GameObject)gameObject.transform.Find ("Enemy1_mesh").gameObject;
			mesh.transform.Rotate(0,0, rotationAngle, Space.Self);
		}

		if (gameObject.name == "Enemy2") {
			GameObject mesh = (GameObject)gameObject.transform.Find ("Enemy2_mesh").gameObject;
			mesh.transform.Rotate(0,rotationAngle, 0, Space.Self);
		}
		//mesh.transform.rotation = Quaternion.AngleAxis (rotationAngle, new Vector3(0,1,0));

	}	

	public float distanceToGoal() {
		float distance = 0;
		distance += Vector3.Distance (gameObject.transform.position, waypoints [currentWaypoint + 1].transform.position);
		for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++) {
			Vector3 startPosition = waypoints [i].transform.position;
			Vector3 endPosition = waypoints [i + 1].transform.position;
			distance += Vector3.Distance (startPosition, endPosition);
		}
		return distance;
	}


	public void HitPowerup(float tiempo){

		//BARRIER

		/*GameObject newenemy = Instantiate (gameObject, gameObject.transform.position, gameObject.transform.rotation) as GameObject; 

		//newenemy.transform.SetParent (parentTow.transform, false); //False para mantener el tamaño --> Enemy no tiene parent (objetos del juego)
		newenemy.transform.position = gameObject.transform.position;*/


		/*Vector3 auxpos = gameObject.transform.position;
		speed = 0.5f;
		gameObject.transform.position = auxpos;*/
		Debug.Log ("TE PARAS PUES!");

		if (stop == false) {
			stop = true;
			timeleft = tiempo;
		}



	}


}
