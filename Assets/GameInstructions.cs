using UnityEngine;
using System.Collections;



public class GameInstructions : MonoBehaviour {
	public Font myFont;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI ()
	{
		//Set the GUIStyle style to be label
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.font = myFont;
		
		//Set the style font size to increase and decrease over time
		style.fontSize = 150;
		
		//Create a label and display with the current settings
		GUI.Label (new Rect (10, 10, 5000, 3000), "Move towards the light(s)");
		
	}
}
