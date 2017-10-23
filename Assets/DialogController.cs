﻿using UnityEngine;
using UnityEngine.UI; // adding in the Unity UI library
using System.Collections;

public class DialogController : MonoBehaviour {
	
	public Text DialogBox;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {	
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell();
		} else if (myState == States.sheets_0) {
			state_sheets_0();
		}
	}
	
	void state_cell () {
		DialogBox.text = "You are a man or at least, that's what they've" + 
			" told you. You find yourself in a dark and dank" + 
				" prison cell. It is grim. Around you are just a" + 
				" few minor things: Some dirty sheets, a cracked" +
				" mirror and a solid steel, locked prison door.\n\n" +
				"Tap S to view the sheets, Tap M to view the mirror," +
				" Tap D to view the door.";
		if (Input.GetKeyDown (KeyCode.S)){
			myState = States.sheets_0;
		}
	}

		void state_sheets_0 () {
			DialogBox.text = "Nice sheets!\n\n" + "Tap R to return to your cell.";
			if (Input.GetKeyDown (KeyCode.R)){
				myState = States.cell;
			}
		}
	
}
