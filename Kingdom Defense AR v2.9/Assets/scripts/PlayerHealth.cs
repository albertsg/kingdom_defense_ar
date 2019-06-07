using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public float maxHealth = 100f;
	public float currentHealth = 100f;
	public GameObject healthBar;
	private float originalScale;
    

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		originalScale = healthBar.transform.localScale.x;
		//InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmpScale = gameObject.transform.localScale;
		tmpScale.x = currentHealth / maxHealth * originalScale;
		if (healthBar != null) {
			healthBar.transform.localScale = tmpScale;
		}
	}


	public void damagePowerup(){
		//DAMAGE (TRAMPA)
		Debug.Log ("BAJAMOS EL 30%!");
		currentHealth = currentHealth - (maxHealth * 0.3f); //Quitamos el 30%
	}

	public void decreaseTimeHealth(){
		currentHealth -= 2f;
	}

//	void decreaseHealth() {
//		current_health -= 2f;
//		float calc_Health = current_health / max_health; // if cur 80 / 100 = 0.8f 
//		setHealthBar(calc_Health);
//	}
//
//	public void setHealthBar(float myHealth) 
//	{
//		//myHealth value 0, 1
//		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(myHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
//	}


}
