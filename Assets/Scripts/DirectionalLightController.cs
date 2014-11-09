using UnityEngine;
using System.Collections;

public class DirectionalLightController : MonoBehaviour {
	public static DirectionalLightController main;

	void Awake(){
		main = this;
	}

	public Light dirLight;

	public void IncreaseIntensity(float intensity){
		dirLight.intensity += intensity;
	}

}
