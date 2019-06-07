using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMenuEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void returnToMenu(){
		SceneManager.LoadScene (0);
	}

    public void nextLevel()
    {
        SceneManager.LoadScene(4); //Level 2
    }
}
