using UnityEngine;
using System.Collections;

public class LightFader : MonoBehaviour {

	public float intensitySmoothTime = .3f;
	public float intensityTarget;
	private float intensityVelocity = 0f;

	void Start(){
	}

	void Update(){
		light.intensity = Mathf.SmoothDamp(light.intensity, intensityTarget, ref intensityVelocity, intensitySmoothTime);
	}


}

