using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {
	
	public Light dayLight;
	public Light nightLight;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Jump")){
		
			if(dayLight.enabled){
				nightLight.enabled=true;
				dayLight.enabled=false;
			}else{
				
				nightLight.enabled=false;
				dayLight.enabled=true;
			}
		}
	}
}
