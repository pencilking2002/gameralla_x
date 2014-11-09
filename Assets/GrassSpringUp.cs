using UnityEngine;
using System.Collections;

public class GrassSpringUp : MonoBehaviour {
	
	public float finalScale = 1.2f;
	public float duration = 2.0f;
	
	public GameObject child;
	
	void OnTriggerEnter(Collider collider)
	{
		//print(collider.gameObject.tag);
		LeanTween.scaleX(child, finalScale, duration).setEase(LeanTweenType.easeOutElastic);
		LeanTween.scaleZ(child, finalScale, duration).setEase(LeanTweenType.easeOutElastic);
		
	}
	
	
}
