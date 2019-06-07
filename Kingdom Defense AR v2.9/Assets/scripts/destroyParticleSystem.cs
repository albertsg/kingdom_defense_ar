using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticleSystem : MonoBehaviour {

    public float destroyParticleTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyParticleTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
