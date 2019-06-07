using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationParametersController : MonoBehaviour {
	GameObject leftRoulette;
	Animator anim;

	// Use this for initialization
	void Start () {
		leftRoulette = GameObject.Find("roulette-left");
		anim = leftRoulette.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setRotatecwFalse() 
	{
		anim.SetBool ("rotatecw", false);
	}

	void setRotateccwFalse() 
	{
		anim.SetBool ("rotateccw", false);
	}

	void setFlagCW1C_false() {
		//Debug.Log ("setFalseCCW1");
		anim.SetBool("rotate-cw1c", false);
	}

	void setFlagCW2C_false() {
		//Debug.Log ("setFalseCCW2");
		anim.SetBool ("rotate-cw2c", false);
	}

	void setFlagCW3C_false() {
		anim.SetBool("rotate-cw3c", false);
	}

	void setFlagCW4C_false() {
		anim.SetBool("rotate-cw4c", false);
	}

	void setFlagCW5C_false() {
		anim.SetBool("rotate-cw5c", false);
	}

	void setFlagCW6C_false() {
		anim.SetBool("rotate-reset-cw6c", false);
	}

	void setFlagReverse() {
		anim.SetBool ("rotate-ccw", false);
	}
}
