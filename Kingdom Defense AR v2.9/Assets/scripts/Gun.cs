using UnityEngine;
using System.Collections;
using Text = UnityEngine.UI.Text;
using System;

public class Gun : MonoBehaviour {
	[SerializeField]float firePower = 50f;
	[SerializeField]GameObject projectilePrefab;
	[SerializeField]Transform launchFromPosition;

	private GameObject staticArrow;
	private Renderer rend;
    [SerializeField] float duration = 20.0f;
    float timer;

    public bool enableShooting;

    soundManager _soundManager;

	void Start() {
		staticArrow = this.gameObject.transform.GetChild (0).gameObject;
		rend = staticArrow.GetComponent<Renderer> ();
        timer = duration;
        _soundManager = GameObject.Find("AudioSource").GetComponent<soundManager>();
    }

    // Update is called once per frame
    void Update () {
        if (enableShooting == true)
        {
            timer = timer - Time.deltaTime;
            
            //Debug.Log("Timer GUN: " +timer);
            updateTimerUI((float)System.Math.Round(timer, 2));

            if (Input.touchCount > 0)
            {
                Debug.Log("[G] TOUCHED SCREEN GUN");
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _soundManager.playSoundArrowShoot();
                    shootProjectile();
                }
            }
        } 
        if ( timer < 0.0)
        {
            enableShooting = false;
            timer = duration;
            disableUIArrowsPowerUp();
            Debug.Log("ENDED TIMER");
        }
        

        /*
        if (Input.GetMouseButtonDown (0)) {
			rend.enabled = false;
			Debug.Log ("clicado");
			GameObject projectile = Instantiate(projectilePrefab, launchFromPosition.position, launchFromPosition.rotation) as GameObject;
			projectile.GetComponent<Rigidbody> ().AddForce (projectile.transform.forward * firePower, ForceMode.Impulse);

		}
        */
	
	}

    public void shootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchFromPosition.position, launchFromPosition.rotation) as GameObject;
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * firePower, ForceMode.Impulse);
    }


    void updateTimerUI(float timer)
    {
        GameObject crosshairTimeLabel = GameObject.Find("crosshair_timer_label");
        Text textCrosshairTimeLabel = crosshairTimeLabel.GetComponent<Text>();
        textCrosshairTimeLabel.text = timer.ToString();
    }

    public void showUIArrowsPowerUp()
    {
        GameObject crosshairGO = GameObject.FindGameObjectWithTag("powerUPArrowsUI");
        CanvasGroup cnvGroupCrosshair = crosshairGO.GetComponent<CanvasGroup>();
        cnvGroupCrosshair.alpha = 1.0f;
    }


    public void disableUIArrowsPowerUp()
    {
        GameObject crosshairGO = GameObject.FindGameObjectWithTag("powerUPArrowsUI");
        CanvasGroup cnvGroupCrosshair = crosshairGO.GetComponent<CanvasGroup>();
        cnvGroupCrosshair.alpha = 0.0f;
        GameObject crosshairTimer = crosshairGO.transform.GetChild(0).gameObject;
        Text textTimer = crosshairTimer.GetComponent<Text>();
        textTimer.text = timer.ToString();
    }

}
