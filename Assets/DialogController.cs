using UnityEngine;
using UnityEngine.UI; // adding in the Unity UI library
using System.Collections;

public class DialogController : MonoBehaviour {
	
	public Text DialogBox;
	
	// Use this for initialization
	void Start () {	
		// assigning the text to the dialog box
		DialogBox.text = "Hello World";
	
	}
	
	// Update is called once per frame
	void Update () {
		// if the user taps space, change the dialog text
		if (Input.GetKeyDown (KeyCode.Space)){
			DialogBox.text = "You are a man or at least, that's what they've" + 
							" told you. You find yourself in a dark and dank" + 
							" prison cell. It is grim. Around you are just a" + 
							" few minor things: Some dirty sheets, a cracked" +
							" mirror and a solid steel, locked prison door.\n\n" +
							"Tap S to view the sheets, Tap M to view the mirror," +
							" Tap D to view the door.";
		}
	
	}
}
