using UnityEngine;
using System.Collections;

public class GrassSpringUp : MonoBehaviour {
	
	public float finalScale = 1.2f;
	public float duration = 2.0f;
	public GameObject child;
	
	private bool sprung = false;
	
	void OnTriggerEnter(Collider collider)
	{
		if (!sprung)
		{
			//print(collider.gameObject.tag);
			LeanTween.scaleX(child, finalScale, duration).setEase(LeanTweenType.easeOutElastic);
			LeanTween.scaleY(child, finalScale, duration).setEase(LeanTweenType.easeOutElastic);
			LeanTween.scaleZ(child, finalScale, duration).setEase(LeanTweenType.easeOutElastic);
			
			//Set sprung to true so tweens don't try to execute again if player triggers another collision
			sprung = true;   
		}
		
		
	}
	
	
}
