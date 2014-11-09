using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float smoothTime = .2f;
	private Vector3 velocity;
	public GameObject target;


	void Start(){
		transform.parent = null;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + new Vector3(0, 10f, -6), ref velocity, smoothTime);
		Vector3 pos = transform.position;
		pos.y = 11f;
		transform.position = pos;
	}
}
