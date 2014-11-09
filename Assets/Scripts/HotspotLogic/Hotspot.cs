using UnityEngine;
using System.Collections;

public class Hotspot : MonoBehaviour {

	public float maxDist;
	public float activationDistance;

	private bool activated;

	private PlayerController player;
	private AudioSource aSource;

	void Start(){
		player = PlayerController.main;
		aSource = gameObject.GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update () {

		if (activated) return;

		float dist = Vector3.Distance(transform.position, player.transform.position);
		aSource.panLevel = Mathf.Lerp(0, 1, dist/maxDist);
		if (dist <= activationDistance){
			if (player.OnActivateHotspot(this)){
				aSource.panLevel = 0;
				activated = true;
			}
		}

	}
}
