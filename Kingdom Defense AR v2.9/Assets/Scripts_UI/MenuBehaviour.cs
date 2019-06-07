using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class MenuBehaviour : MonoBehaviour {

	GameObject principal;
	Canvas canvas;

	GameObject credits;
	Canvas c_canvas;

	GameObject markers;
	Canvas m_canvas;

	GameObject loading;
	Canvas l_canvas;

	// Use this for initialization
	void Start () {
		principal = GameObject.Find ("Canvas");
		canvas = principal.GetComponent<Canvas> ();

		credits = GameObject.Find ("Canvas_credits");
		c_canvas = credits.GetComponent<Canvas> ();

		markers = GameObject.Find ("Canvas_markers");
		m_canvas = markers.GetComponent<Canvas> ();

		loading = GameObject.Find ("Canvas_loading");
		l_canvas = loading.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayGame(){
        soundManager _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playSoundButton();
		l_canvas.enabled = true;
		canvas.enabled = false;
		SceneManager.LoadScene (1);
		Debug.Log ("Loading game...");
	}

	public void Credits(){
        soundManager _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playSoundButton();
        canvas.enabled = false;
		c_canvas.enabled = true;
	}

	public void ReturnMenu(){
        soundManager _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playSoundButton();
        c_canvas.enabled = false;
		m_canvas.enabled = false;
		canvas.enabled = true;
	}

	public void DownloadMarker(){
        soundManager _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playSoundButton();
        Application.OpenURL("http://kingdomdefensear.esy.es/marker/kingdomdefensear.pdf");
    }

    public void Quit(){
        soundManager _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
        _soundManager.playSoundButton();
        Application.Quit(); 
	}

}
