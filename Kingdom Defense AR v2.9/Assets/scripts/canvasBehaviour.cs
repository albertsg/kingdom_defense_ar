using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canvasBehaviour : MonoBehaviour {
	GameObject gmimg;
	Image myImageComponent;

	public Sprite option0;
	public Sprite option1;
	public Sprite option2;
	public Sprite option3;
	public Sprite option4;
	public Sprite option5;
	public Sprite option6;

	// Use this for initialization
	void Start () {
		//Transform gmimg2 = gameObject.transform.GetChild (0);
		//gmimg = (GameObject)gmimg2;

		gmimg = GameObject.FindGameObjectWithTag ("MainCanvas");
		Transform imgTr = gmimg.transform.Find ("ImageCanvas");
		myImageComponent = imgTr.GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScreen(int option) {
		if (option == 0) {
			myImageComponent.sprite = option0;
		}
		if (option == 1) {
			myImageComponent.sprite = option1;
		}
		if (option == 2) {
			myImageComponent.sprite = option2;
		}
		if (option == 3) {
			myImageComponent.sprite = option3;
		}
		if (option == 4) {
			myImageComponent.sprite = option4;
		}
		if (option == 5) {
			
			myImageComponent.sprite = option5;
		}
		if (option == 6) {
			myImageComponent.sprite = option6;
		}


	}
}
