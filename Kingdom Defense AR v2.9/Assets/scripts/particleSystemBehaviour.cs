using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemBehaviour : MonoBehaviour {
    private bool startedPlaying;
    ParticleSystem particleSys;

	// Use this for initialization
	void Start () {
        particleSys = this.GetComponent<ParticleSystem>();
        particleSys.Stop();
        startedPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startParticleSystem()
    {
        if (startedPlaying == false)
        {
            startedPlaying = true;
            //particleSys = this.GetComponent<ParticleSystem>();
            particleSys.Play();
        }
    }
}
