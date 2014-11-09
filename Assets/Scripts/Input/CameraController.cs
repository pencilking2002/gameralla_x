using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float smoothTime = .2f;
	private Vector3 velocity;
	public GameObject target;
	public Vector3 offset = new Vector3(0f, 10f, -6f);
	public bool lockY = true;


	void Start(){
		transform.parent = null;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref velocity, smoothTime);
		if (lockY){
			Vector3 pos = transform.position;
			pos.y = 11f;
			transform.position = pos;
		}
	}
}
