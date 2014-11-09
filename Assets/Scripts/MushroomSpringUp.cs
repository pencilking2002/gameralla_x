using UnityEngine;
using System.Collections;

public class MushroomSpringUp : MonoBehaviour {

	public float finalScaleX = 1.2f;
	public float finalScaleY = 1.2f;
	public float finalScaleZ = 1.2f;
	public float finalPosY = -2.549794f;
	public float duration = 2.0f;
	public GameObject child;
		
	public void TweenMuchroom()
	{
		{
			//print(collider.gameObject.tag);
			LeanTween.scaleX(child, finalScaleX, duration).setEase(LeanTweenType.easeInCubic);
			LeanTween.scaleY(child, finalScaleY, duration).setEase(LeanTweenType.easeInCubic);
			LeanTween.scaleZ(child, finalScaleZ, duration).setEase(LeanTweenType.easeInCubic);
			LeanTween.moveLocalY(child, finalPosY, duration).setEase(LeanTweenType.easeInCubic);
			
		}
	}
	//8.866213
}
