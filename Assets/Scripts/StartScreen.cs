﻿using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			Invoke("LoadGame", 0f);
		}
	}

	void LoadGame(){
		Application.LoadLevel(1);
	}
}
