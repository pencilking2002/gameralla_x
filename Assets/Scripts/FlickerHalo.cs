using UnityEngine;
using System.Collections;

public class FlickerHalo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = Mathf.Lerp(.17f, .19f, Random.value);
		if (Input.anyKeyDown){
			Debug.Log("DONE");
		}
	}
}
