using UnityEngine;
using System.Collections;

public class ColorFader : MonoBehaviour {

	public float fadeTime = .4f;
	public Color fullColor;
	private Vector4 fadeVelocity = Vector4.zero;
	public bool forceFullColor;
	public bool isHalo;
	public bool alphaFadeOnly;
	public float delay;
	public bool unScaledTime;
	private ColorOscillator colorOscillator;
	public bool oscillate;



	public void OscillateColor(float speed, Color startColor){
		if (colorOscillator == null)
			colorOscillator = gameObject.AddComponent<ColorOscillator>();
		colorOscillator.currentColor = startColor;
		colorOscillator.oscillationSpeed = speed;
		fadeTime = .01f;
		oscillate = true;
	}

	// Use this for initialization
	void Start () {
		if (alphaFadeOnly){
			Color oldColor;
			if (isHalo) oldColor = renderer.material.GetColor("_TintColor");
			else oldColor = renderer.material.color;
			fullColor.r = oldColor.r;
			fullColor.g = oldColor.g;
			fullColor.b = oldColor.b;
		}
		if (forceFullColor) return;
		Color rldColor;
		if (isHalo){
			fullColor = renderer.material.GetColor("_TintColor");
			rldColor = fullColor;
		}
		else{
			fullColor = renderer.material.color;
			rldColor = renderer.material.color;
		}
		rldColor.a = 0;
		if (isHalo){
			renderer.material.SetColor("_TintColor", rldColor);
		}
		else
			renderer.material.color = rldColor;
	}


	
	// Update is called once per frame
	void Update () {
		if (delay > 0){
			if (unScaledTime){
				delay -= Time.unscaledDeltaTime;
			}
			else
				delay -= Time.deltaTime;
			return;
		}
		Color newColor;
		if (oscillate){
			if (colorOscillator == null) OscillateColor(.5f, Color.red);
			fullColor = colorOscillator.currentColor;
		}
	
		if (isHalo){
			if (unScaledTime){
				newColor = Utilities.Vector4SmoothDampUnScaled (renderer.material.GetColor ("_TintColor"), fullColor, ref fadeVelocity, fadeTime);
			}
			else
				newColor = Utilities.Vector4SmoothDamp (renderer.material.GetColor ("_TintColor"), fullColor, ref fadeVelocity, fadeTime);
		}
		else {
			if (unScaledTime){
				newColor = Utilities.Vector4SmoothDampUnScaled (renderer.material.color, fullColor, ref fadeVelocity, fadeTime);
			}
			else
				newColor = Utilities.Vector4SmoothDamp (renderer.material.color, fullColor, ref fadeVelocity, fadeTime);
		}

		if (isHalo){
			if(renderer.material.GetColor("_TintColor") != fullColor)
				renderer.material.SetColor("_TintColor", newColor);
		}
		else if(renderer.material.color != fullColor)
				renderer.material.color = newColor;
	}

	void OnDestroy(){
		if(oscillate){
			Destroy(colorOscillator);
		}
	}
}
