using UnityEngine;
using System.Collections;

public class PositionFader : MonoBehaviour {

	public float delay;

	public bool fadePosition;
	public Vector3 offsetTarget;
	private Vector3 positionTarget;
	private Vector3 positionVelocity = Vector3.zero;
	public float positionSmoothTime;

	public bool continuousFade = true;
	public bool fadeScale;
	public Vector3 scaleTarget;
	private Vector3 scaleVelocity;
	public float scaleSmoothTime;
	public bool unScaledTime = true;
	public bool localPositionFade = false;
	public Vector3 beginPosition;
	public Vector3 beginScale;
	public bool oscillate;
	public float oscillationDelay;

	// Use this for initialization
	void Start () {
		if (offsetTarget != Vector3.zero){
			transform.position -= offsetTarget;
			positionTarget = transform.position + offsetTarget;
		}
		if (localPositionFade){
			transform.localPosition -= offsetTarget;
			positionTarget = transform.localPosition + offsetTarget;
		}
	}

	public void FadeScale(Vector3 scaleTarget, float scaleSmoothTime){
		this.scaleTarget = scaleTarget;
		this.scaleSmoothTime = scaleSmoothTime;
		fadeScale = true;
	}

	public void FadePosition(Vector3 positionTarget, float smoothTime, float delay){
		this.delay = delay;
		FadePosition(positionTarget, smoothTime);
	}

	public void FadePosition(Vector3 positionTarget, float smoothTime){
		this.positionTarget = positionTarget;
		this.positionSmoothTime = smoothTime;
		fadePosition = true;
	}

	// Update is called once per frame
	void Update () {
		if (delay > 0){
			if (unScaledTime)
				delay -= Time.deltaTime;
			else delay -= Time.unscaledDeltaTime;
			return;
		}
	
		if (fadePosition){
			if (localPositionFade){
				if (transform.localPosition != positionTarget){
					if (unScaledTime)
						transform.localPosition = Vector3.SmoothDamp(transform.localPosition, positionTarget, ref positionVelocity, positionSmoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
					else
						transform.localPosition = Vector3.SmoothDamp(transform.localPosition, positionTarget, ref positionVelocity, positionSmoothTime);
				}
				if (Vector3.Distance(transform.localPosition, positionTarget) < .01f){
					transform.localPosition = positionTarget;
					if (!continuousFade)
					fadePosition = false;
					if (oscillate){
						positionTarget = beginPosition;
						beginPosition = transform.localPosition;
						fadePosition = true;
					}
				}
			}
			else{
				if (transform.position != positionTarget){
					if (unScaledTime)
						transform.position = Vector3.SmoothDamp(transform.position, positionTarget, ref positionVelocity, positionSmoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
					else
						transform.position = Vector3.SmoothDamp(transform.position, positionTarget, ref positionVelocity, positionSmoothTime);
				}
				if (Vector3.Distance(transform.position, positionTarget) < .01f){
					transform.position = positionTarget;
					if (!continuousFade)
						fadePosition = false;
					if (oscillate){
						positionTarget = beginPosition;
						beginPosition = transform.position;
						fadePosition = true;
					}
				}
			}
		}

		if (fadeScale){
			if (transform.localScale != scaleTarget){
				if (unScaledTime)
					transform.localScale = Vector3.SmoothDamp(transform.localScale, scaleTarget, ref scaleVelocity, scaleSmoothTime, Mathf.Infinity, Time.unscaledDeltaTime);
				else
					transform.localScale = Vector3.SmoothDamp(transform.localScale, scaleTarget, ref scaleVelocity, scaleSmoothTime);
			}
			if (Vector3.Distance(transform.localScale, scaleTarget) < .01f){
				transform.localScale = scaleTarget;
				if (!continuousFade)
					fadeScale = false;
					if (oscillate){
						scaleTarget = beginScale;
						beginScale = transform.localScale;
						fadeScale = true;
					}
			}
		}
	}
}
