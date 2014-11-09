using UnityEngine;
using System.Collections;

public class MushroomSpringUp : MonoBehaviour {

	public Vector3 finalScale;
	public float finalPosY = -2.549794f;
	public float duration = 1.0f;
	public GameObject child;

	public void Start(){
		finalScale = transform.localScale;
		transform.localScale = Vector3.zero;
	}
		
	public void TweenMuchroom()
	{
		{
			//print(collider.gameObject.tag);
			LeanTween.scaleX(gameObject, finalScale.x, duration).setEase(LeanTweenType.easeInOutCubic);
			LeanTween.scaleY(gameObject, finalScale.y, duration).setEase(LeanTweenType.easeInOutCubic);
			LeanTween.scaleZ(gameObject, finalScale.z, duration).setEase(LeanTweenType.easeInOutCubic);

		}
	}
	//8.866213
}
