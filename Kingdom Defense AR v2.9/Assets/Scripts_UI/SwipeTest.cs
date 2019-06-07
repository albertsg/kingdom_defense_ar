using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour {

	public GameObject gameManager;
	private GameManagerBehavior gmb;

	public float maxTime;
	public float minSwipeDist;

	Animator animator;
	Animator animatorRight;

	float startTime;
	float endTime;

	/*private float current_tower = 1; //1 is tower arrow, 2 is tower haldberd, 3 is tower crossbow, 4 is tower catapult and 5 is tower cannon
	private float current_powerup = 1; //*/

	Vector3 startPos;
	Vector3 endPos;
	float swipeDistance;
	float swipeTime;


	//TOWERS
	GameObject arrow;
	GameObject crossbow;
	GameObject cannon;
	GameObject catapult;
	GameObject haldberd;

	//POWERUPS
	GameObject fireball;
	GameObject barrier;
	GameObject damage;
	GameObject trap;
	//GameObject arrows;


	Vector3 initpos;
	Vector3 spawnpos;
	Vector3 temp;


	int first;
	//////////////////// 
    // GUSTAVO
    ButtonBehaviourScript buttonBehaviourScript;
    int currentPositionExtra = 1;
    Animator animatorLeftExtra;
    //

    soundManager _soundManager;


    // Use this for initialization
    void Start () {
		GameObject goRouletteLeft = GameObject.Find("roulette-left");
		animator = goRouletteLeft.GetComponent<Animator>();

		GameObject goRouletteRight = GameObject.Find("roulette-right");
		animatorRight = goRouletteRight.GetComponent<Animator>();

		gameManager = GameObject.Find ("GameManager");
		gmb = gameManager.GetComponent<GameManagerBehavior> ();


		crossbow = GameObject.Find ("Crossbow");
		cannon = GameObject.Find ("Cannon");
		arrow = GameObject.Find ("Arrow");
		catapult = GameObject.Find ("Catapult");
		haldberd = GameObject.Find ("Haldberd");


		fireball = GameObject.Find ("Fireball");
		barrier = GameObject.Find ("Barrier");
		damage = GameObject.Find ("Damage");
		trap = GameObject.Find ("Trap");
		first = 0;

        // GUSTAVO
        GameObject buttonBehaviour = GameObject.Find("ButtonBehaviour");
        buttonBehaviourScript = buttonBehaviour.GetComponent<ButtonBehaviourScript>();
        GameObject goRouletteLeftExtra = GameObject.Find("roulette-left-extra");
        animatorLeftExtra = goRouletteLeftExtra.GetComponent<Animator>();

        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
    }
	
	// Update is called once per frame
	void Update () {
		//Towers
		crossbow = GameObject.Find ("ImageTargetTowers/Crossbow");
		cannon = GameObject.Find ("ImageTargetTowers/Cannon");
		arrow = GameObject.Find ("ImageTargetTowers/Arrow");
		catapult = GameObject.Find ("ImageTargetTowers/Catapult");
		haldberd = GameObject.Find ("ImageTargetTowers/Haldberd");
		//Powerups
		fireball = GameObject.Find ("ImageTargetPowerup/Fireball");
		barrier = GameObject.Find ("ImageTargetPowerup/Barrier");
		damage = GameObject.Find ("ImageTargetPowerup/Damage");
		trap = GameObject.Find ("ImageTargetPowerup/Trap");

		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;

			} else if(touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;

				swipeDistance = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if (swipeTime < maxTime && swipeDistance > minSwipeDist) {
					swipe();
				}
			}


		}
	}


	void swipe() {

        float screen_width = Screen.width;
		float screen_height = Screen.height;

		//Debug.Log (screen_width);
		//Debug.Log (screen_height);

		Vector2 distance = endPos - startPos;
		//Debug.Log (startPos);

		if ((startPos.x < screen_width/2) && (endPos.x < screen_width/2)) {
			if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
				Debug.Log ("[LEFT] Vertical Swipe");
				if (distance.y > 0) {
                    //Debug.Log("Hola Mundo");
                    //Debug.Log(buttonBehaviourScript.activeTowerSelectionLeft);
                    //Debug.Log("Hola Mundo");
					if ((buttonBehaviourScript.activeTowerSelectionLeft == true) && (buttonBehaviourScript.activeExtraLeft == false))
                    {
                        if (gmb.currentTower == 1)
                        {
                            gmb.currentTower = 5;
                        }
                        else
                        {
                            gmb.currentTower = gmb.currentTower - 1;
                        }

                        /***/
                        placeTowers();
                        /***/

                        if (gmb.currentTower == 5)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-1rotcw");
                        }
                        if (gmb.currentTower == 4)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-2rotcw");
                        }
                        if (gmb.currentTower == 3)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-3rotcw");
                        }
                        if (gmb.currentTower == 2)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-4rotcw");
                        }
                        if (gmb.currentTower == 1)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-5rotcw");
                        }

                        Debug.Log("[LEFT] Up Swipe! current_tower = " + gmb.currentTower);
                    }
               
                    if ((buttonBehaviourScript.activeTowerSelectionLeft == false) && (buttonBehaviourScript.activeExtraLeft == true))
                    {
                        if (gmb.currentExtraPosition == 1)
                        {
                            gmb.currentExtraPosition = 3;
                        }
                        else
                        {
                            gmb.currentExtraPosition = gmb.currentExtraPosition - 1;
                        }

                        if (gmb.currentExtraPosition == 3)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-1rotccw");
                        }
                        if (gmb.currentExtraPosition == 2)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-2rotccw");
                        }
                        if (gmb.currentExtraPosition == 1)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-3rotccw");
                        }
                        Debug.Log("[LEFT] Up Swipe! current position extra = " + gmb.currentExtraPosition);
                    }

				} else if (distance.y < 0) {
                    if ((buttonBehaviourScript.activeTowerSelectionLeft == true) && (buttonBehaviourScript.activeExtraLeft == false))
                    {
                        if (gmb.currentTower == 5)
                        {
                            gmb.currentTower = 1;
                        }
                        else
                        {
                            gmb.currentTower = gmb.currentTower + 1;
                        }

                        /***/
                        placeTowers();
                        /***/

                        if (gmb.currentTower == 2)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-1rotccw");
                        }
                        if (gmb.currentTower == 3)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-2rotccw");
                        }
                        if (gmb.currentTower == 4)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-3rotccw");
                        }
                        if (gmb.currentTower == 5)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-4rotccw");
                        }
                        if (gmb.currentTower == 1)
                        {
                            _soundManager.playSoundSwipe();
                            animator.Play("left-tow-5rotccw");
                        }

                        Debug.Log("[LEFT] Down Swipe! current_tower = " + gmb.currentTower);
                    }
                    Debug.Log(buttonBehaviourScript.activeTowerSelectionLeft);
                    Debug.Log(buttonBehaviourScript.activeExtraLeft);
                    if ((buttonBehaviourScript.activeTowerSelectionLeft == false) && (buttonBehaviourScript.activeExtraLeft == true))
                    {
                        if (gmb.currentExtraPosition == 3)
                        {
                            gmb.currentExtraPosition = 1;
                        }
                        else
                        {
                            gmb.currentExtraPosition = gmb.currentExtraPosition + 1;
                        }

                        if (gmb.currentExtraPosition == 2)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-1rotcw");
                        }
                        if (gmb.currentExtraPosition == 3)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-2rotcw");
                        }
                        if (gmb.currentExtraPosition == 1)
                        {
                            _soundManager.playSoundSwipe();
                            animatorLeftExtra.Play("left-extra-3rotcw");
                        }
                        Debug.Log("[LEFT] Down Swipe! current_extra_position = " + gmb.currentExtraPosition);
                    }
				}
			}
		}

		if ((startPos.x > screen_width/2) && (endPos.x > screen_width/2)) {
			if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
				Debug.Log ("[RIGHT] Vertical Swipe");
				if (distance.y > 0) {

					if (gmb.currentPowerup == 5) {
						gmb.currentPowerup = 1;
					} else {
						gmb.currentPowerup = gmb.currentPowerup + 1;
					}

					/***/
					placePowerups ();
					/***/

					if (gmb.currentPowerup == 1) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-5rotccw");
					}
					if (gmb.currentPowerup == 2) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-1rotccw");
					}
					if (gmb.currentPowerup == 3) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-2rotccw");
					}
					if (gmb.currentPowerup == 4) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-3rotccw");
					}
					if (gmb.currentPowerup == 5) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-4rotccw");
					}
					Debug.Log ("[RIGHT] Up Swipe! current_powerup = "+gmb.currentPowerup);

				} else if (distance.y < 0) {
					if (gmb.currentPowerup == 1) {
						gmb.currentPowerup = 5;
					} else {
						gmb.currentPowerup = gmb.currentPowerup - 1;
					}

					/***/
					placePowerups ();
					/***/

					if (gmb.currentPowerup == 5) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-1rotcw");
					}
					if (gmb.currentPowerup == 4) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-2rotcw");
					}
					if (gmb.currentPowerup == 3) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-3rotcw");
					}
					if (gmb.currentPowerup == 2) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-4rotcw");
					}
					if (gmb.currentPowerup == 1) {
                        _soundManager.playSoundSwipe();
                        animatorRight.Play ("right-pow-5rotcw");
					}

					Debug.Log ("[RIGHT] Down Swipe! current_powerup = "+gmb.currentPowerup);


				}
			}
		}

		

		//GameObject sceneCamObj = GameObject.Find( "SceneCamera" );
		//if (sceneCamObj != null) {
		//	float true_screen_width = sceneCamObj.camera.pixelRect;
		//}

		/*
		Vector2 distance = endPos - startPos;
		if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y)) {
			Debug.Log ("Horizontal Swipe");
			if (distance.x > 0) {
				Debug.Log ("Right Swipe");
			}
			if (distance.x < 0) {
				Debug.Log ("Left Swipe");
			}
		} else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y)) {
			Debug.Log ("Vertical Swipe");
			if (distance.y > 0) {
				Debug.Log ("Up Swipe");
			}
			if (distance.y < 0) {
				Debug.Log ("Down Swipe");
			}
				
		}
		*/

	}
	
	void placeTowers(){
		switch(gmb.currentTower){
		case 1: //ARROW
			
			Debug.Log("ARROW TIME");
			temp = cannon.transform.localPosition;
			temp.y = (cannon.transform.localPosition.y + 4.0f);
			cannon.transform.localPosition = temp;

			temp = arrow.transform.localPosition;
			temp.y = (arrow.transform.localPosition.y - 4.0f);
			arrow.transform.localPosition = temp;

			temp = arrow.transform.localPosition;
			temp.y = 1.0f;
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = 5.0f;
			haldberd.transform.localPosition = temp;

			temp = crossbow.transform.localPosition;
			temp.y = 5.0f;
			crossbow.transform.localPosition = temp;

			temp = catapult.transform.localPosition;
			temp.y = 5.0f;
			catapult.transform.localPosition = temp;

			temp = cannon.transform.localPosition;
			temp.y = 5.0f;
			cannon.transform.localPosition = temp;


			break;
		case 2: //HALDBERD
			Debug.Log("HALDBERD TIME");

			temp = arrow.transform.localPosition;
			temp.y = (arrow.transform.localPosition.y + 4.0f);
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = (haldberd.transform.localPosition.y - 4.0f);
			haldberd.transform.localPosition = temp;

			temp = arrow.transform.localPosition;
			temp.y = 5.0f;
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = 1.0f;
			haldberd.transform.localPosition = temp;

			temp = crossbow.transform.localPosition;
			temp.y = 5.0f;
			crossbow.transform.localPosition = temp;

			temp = catapult.transform.localPosition;
			temp.y = 5.0f;
			catapult.transform.localPosition = temp;

			temp = cannon.transform.localPosition;
			temp.y = 5.0f;
			cannon.transform.localPosition = temp;

			break;
		case 3: //CROSSBOW
			Debug.Log("CROSSBOW TIME");


			temp = arrow.transform.localPosition;
			temp.y = 5.0f;
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = 5.0f;
			haldberd.transform.localPosition = temp;

			temp = crossbow.transform.localPosition;
			temp.y = 1.0f;
			crossbow.transform.localPosition = temp;

			temp = catapult.transform.localPosition;
			temp.y = 5.0f;
			catapult.transform.localPosition = temp;

			temp = cannon.transform.localPosition;
			temp.y = 5.0f;
			cannon.transform.localPosition = temp;

			break;
		case 4: //CATAPULT
			Debug.Log("CATAPULT TIME");

			temp = arrow.transform.localPosition;
			temp.y = 5.0f;
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = 5.0f;
			haldberd.transform.localPosition = temp;

			temp = crossbow.transform.localPosition;
			temp.y = 5.0f;
			crossbow.transform.localPosition = temp;

			temp = catapult.transform.localPosition;
			temp.y = 1.0f;
			catapult.transform.localPosition = temp;

			temp = cannon.transform.localPosition;
			temp.y = 5.0f;
			cannon.transform.localPosition = temp;

			break;
		default: //CANNON
			Debug.Log ("CANNON TIME");


			temp = arrow.transform.localPosition;
			temp.y = 5.0f;
			arrow.transform.localPosition = temp;

			temp = haldberd.transform.localPosition;
			temp.y = 5.0f;
			haldberd.transform.localPosition = temp;

			temp = crossbow.transform.localPosition;
			temp.y = 5.0f;
			crossbow.transform.localPosition = temp;

			temp = catapult.transform.localPosition;
			temp.y = 5.0f;
			catapult.transform.localPosition = temp;

			temp = cannon.transform.localPosition;
			temp.y = 1.0f;
			cannon.transform.localPosition = temp;
			break;
		}
	}

	void placePowerups(){
	
		switch (gmb.currentPowerup) {
		case 1: //BARRIER
			Debug.Log ("BARRIER TIME");

			temp = trap.transform.localPosition;
			temp.y = 5.0f;
			trap.transform.localPosition = temp;

			temp = fireball.transform.localPosition;
			temp.y = 5.0f;
			fireball.transform.localPosition = temp;

			/*temp = arrows.transform.localPosition;
			temp.y = 5.0f;
			arrows.transform.localPosition = temp;*/

			temp = barrier.transform.localPosition;
			temp.y = 2.0f;
			barrier.transform.localPosition = temp;

			temp = damage.transform.localPosition;
			temp.y = 5.0f;
			damage.transform.localPosition = temp;

			break;
		case 2: //DAMAGE
			Debug.Log ("DAMAGE TIME");

			temp = trap.transform.localPosition;
			temp.y = 5.0f;
			trap.transform.localPosition = temp;

			temp = fireball.transform.localPosition;
			temp.y = 5.0f;
			fireball.transform.localPosition = temp;

			/*temp = arrows.transform.localPosition;
			temp.y = 5.0f;
			arrows.transform.localPosition = temp;*/

			temp = barrier.transform.localPosition;
			temp.y = 5.0f;
			barrier.transform.localPosition = temp;

			temp = damage.transform.localPosition;
			temp.y = 2.0f;
			damage.transform.localPosition = temp;

            break;
		case 3: //TRAP
			Debug.Log ("TRAP TIME");

			temp = trap.transform.localPosition;
			temp.y = 2.0f;
			trap.transform.localPosition = temp;

			temp = fireball.transform.localPosition;
			temp.y = 5.0f;
			fireball.transform.localPosition = temp;

			/*temp = arrows.transform.localPosition;
			temp.y = 5.0f;
			arrows.transform.localPosition = temp;*/

			temp = barrier.transform.localPosition;
			temp.y = 5.0f;
			barrier.transform.localPosition = temp;

			temp = damage.transform.localPosition;
			temp.y = 5.0f;
			damage.transform.localPosition = temp;

            break;
		case 4: //ARROWS
			Debug.Log ("ARROWS TIME");

			temp = trap.transform.localPosition;
			temp.y = 5.0f;
			trap.transform.localPosition = temp;

			temp = fireball.transform.localPosition;
			temp.y = 5.0f;
			fireball.transform.localPosition = temp;

			/*temp = arrows.transform.localPosition;
			temp.y = 2.0f;
			arrows.transform.localPosition = temp;*/

			temp = barrier.transform.localPosition;
			temp.y = 5.0f;
			barrier.transform.localPosition = temp;

			temp = damage.transform.localPosition;
			temp.y = 5.0f;
			damage.transform.localPosition = temp;

            break;
		default: //FIREBALL
			Debug.Log ("FIREBALL TIME");

			temp = trap.transform.localPosition;
			temp.y = 5.0f;
			trap.transform.localPosition = temp;

			temp = fireball.transform.localPosition;
			temp.y = 2.0f;
			fireball.transform.localPosition = temp;

			/*temp = arrows.transform.localPosition;
			temp.y = 5.0f;
			arrows.transform.localPosition = temp;*/

			temp = barrier.transform.localPosition;
			temp.y = 5.0f;
			barrier.transform.localPosition = temp;

			temp = damage.transform.localPosition;
			temp.y = 5.0f;
			damage.transform.localPosition = temp;

            break;
		}
	}

}
