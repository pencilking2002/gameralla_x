using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F))
		{
			// Fade GO in from 0 to 1, but it doesn't work?
			LeanTween.alpha(gameObject, 0f, 1f);
		}
	}
	
	
}
