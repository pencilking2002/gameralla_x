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
			// tween the GO up
			LeanTween.move (gameObject, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 2f).setEase(LeanTweenType.easeOutElastic);
			LeanTween.scaleX(gameObject, 1.2f, 2.0f).setEase(LeanTweenType.easeOutElastic);
			LeanTween.scaleZ(gameObject, 1.2f, 2.0f).setEase(LeanTweenType.easeOutElastic);
		}
	}
	
	
}
