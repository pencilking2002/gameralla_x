using UnityEngine;
using System.Collections;

public class FlickerHalo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = Mathf.Lerp(.5f, .55f, Random.value);
	}
}
