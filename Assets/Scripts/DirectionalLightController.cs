using UnityEngine;
using System.Collections;

public class DirectionalLightController : MonoBehaviour {
	public static DirectionalLightController main;


	public void SetIntensity(float intensity){
		light.intensity = intensity;
	}

}
