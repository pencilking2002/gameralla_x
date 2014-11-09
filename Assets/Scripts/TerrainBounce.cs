using UnityEngine;
using System.Collections;

public class TerrainBounce : MonoBehaviour {
	Vector3 basePosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		basePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//sets a baseposition variable incease along the x axis 
		basePosition += new Vector3( 0f, 0f, 0f);
		
		transform.position = basePosition + new Vector3(0f, Mathf.Sin( Time.time ) * 2f, 0f);
		//	transform.position = basePosition + new Vector3(0f, Mathf.Sin( Time.time *2f) * 10f, 0f);
	
	}

}
