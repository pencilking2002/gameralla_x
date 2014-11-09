using UnityEngine;
using System.Collections;

public class EndScreenScript : MonoBehaviour {
	public GameObject cameraTarget;
	private float timer = 4f;
	
	// Update is called once per frame
	void Update () {
		if (timer > 0){
			timer -= Time.deltaTime;
			return;
		}
		if (Input.anyKeyDown){
			cameraTarget.transform.position = new Vector3(0, -9f, 0f);
			Invoke("LoadGame", 2f);
			CameraFade.StartAlphaFade( Color.black, false, 2f, 2f);
		}
	}
	
	void LoadGame(){
		Application.LoadLevel(1);
	}
}
