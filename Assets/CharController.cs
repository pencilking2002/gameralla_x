using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	
	public speed = 10f;
	public rotationSPeed = 100f;
	
	private float h;
	private float v;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Horizontal");
	}
}
