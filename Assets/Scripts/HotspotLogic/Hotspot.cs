using UnityEngine;
using System.Collections;

public class Hotspot : MonoBehaviour {

	public float maxDist;
	public float activationDistance;

	private bool activated;

	private PlayerController player;
	private AudioSource aSource;
	private Light pointLight;

	private float lightPulsatingSpeed;
	private float lightPulsatingTimer;
	private bool pulsateUp;

	private LightFader lf;

	void Start(){
		player = PlayerController.main;
		aSource = gameObject.GetComponent<AudioSource>();
		lf = gameObject.AddComponent<LightFader>();
	}


	// Update is called once per frame
	void Update () {

		if (activated) return;

		if (pulsateUp){
			lightPulsatingTimer += Time.deltaTime;
			if (lightPulsatingTimer > 1){
				pulsateUp = !pulsateUp;
			}
		}
		else{
			lightPulsatingTimer -= Time.deltaTime;
			if (lightPulsatingTimer < 0){
				pulsateUp = !pulsateUp;
			}

		}

		float dist = Vector3.Distance(transform.position, player.transform.position);
		aSource.panLevel = Mathf.Lerp(0, 1f, dist/maxDist);
		lf.intensityTarget = Mathf.Lerp (.4f, .05f, dist/maxDist) * Mathf.Lerp(.8f, 1f, lightPulsatingTimer/1f);
		if (dist <= activationDistance){
			if (player.OnActivateHotspot(this)){
				aSource.panLevel = 0;
				activated = true;
				light.intensity = 4f;
				lf.intensityTarget = 0f;
			}
		}
	}

	public void Reset(){
		aSource.panLevel = 1;
		activated = false;
	}
}
