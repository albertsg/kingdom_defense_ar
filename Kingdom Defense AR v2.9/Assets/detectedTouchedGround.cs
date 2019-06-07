using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detectedTouchedGround : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HA TOCADO EL SUELO");
        SphereCollider scol = this.GetComponent<SphereCollider>();
        scol.enabled = true;
        GameObject tryOut = Instantiate(Resources.Load("Prefabs/ETF_Touches_Ground", typeof(GameObject))) as GameObject;
        tryOut.transform.position = this.transform.position;
        tryOut.transform.rotation = this.transform.rotation;
        ParticleSystem particleSys = tryOut.GetComponent<ParticleSystem>();
        particleSys.Play();
        //GameObject particleSystem = GameObject.Find("particleSystemManager").GetComponent<manageParticleSystems>().instantiateTowerParticleEffect;
        //GameObject shurikenPartSys = Instantiate(particleSystem, this.transform.position, this.transform.rotation);
        //shurikenPartSys.transform.position = this.transform.position;
        //particleSystem.GetComponent<particleSystemBehaviour>().startParticleSystem();
        //particleSystem.GetComponent<particleSystemBehaviour>().startParticleSystem();
    }
}
