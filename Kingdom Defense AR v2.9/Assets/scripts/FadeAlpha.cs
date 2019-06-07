using UnityEngine;
using System.Collections;

public class FadeAlpha : MonoBehaviour {
	public float timeStartFade;
	[SerializeField] private float fadePerSecond = 1.0f;
	private float fadingTimeTillDestruction;
	// Use this for initialization
	void Start () {
		fadingTimeTillDestruction = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		var material = GetComponent<Renderer>().material;
		var color = material.color;

		material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));

		if ((Time.time - timeStartFade) > fadingTimeTillDestruction) {
			Transform parent = gameObject.transform.parent;
			Destroy (parent.gameObject);
		}
	}
}
