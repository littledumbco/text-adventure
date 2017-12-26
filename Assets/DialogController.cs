using UnityEngine;
using UnityEngine.UI; // adding in the Unity UI library
using System.Collections;

public class DialogController : MonoBehaviour {
	
	public Text DialogBox;
	// Used this to set up some basic list of states
	private enum States {cell, cell_1, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {	
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0) {
			state_sheets_0 ();
		} else if (myState == States.mirror) {
			state_mirror ();
		} else if (myState == States.sheets_1) {
			state_sheets_1 ();
		}
	}
	
	// Here I'm setting up the content of each state, so if you are in the state 'cell' the DialogBox will be updated to display
	// the relevant text.
	void state_cell () {
			DialogBox.text = "You find yourself in a dark and dank" + 
			" prison cell. It is <i>grim</i>. Around you are just a" + 
			" few minor things: Some dirty sheets, a cracked" +
			" mirror and a solid steel, locked prison door.\n\n" +
			"Tap <b>S</b> to stare at the sheets, Tap <b>M</b> to look into the mirror," +
			" Tap <b>D</b> to view the door.";
			if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		
	}
	
	// Another state example here to show the user they've moved to the 'sheets' state and the relevant key to return.
		void state_sheets_0 () {
			DialogBox.text = "Your eyes look the sheets up and down as a sigh escapes your lips. " +
			"The sheets are covered in blood, but unbeknowst to you and due to your recent " +
			"unconcious state, you don't know if it's yours or perhaps a previous unlucky captive.\n\n" +
			"You snap out of that gruesome thought as you quickly notice an outline of an object under the sheet.\n\n" +
			"Tap <b>F</b> to flick the sheet over or tap <b>C</b> to continue to explore your cell.";
			if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.sheets_1;
			}
		}

		void state_sheets_1 () {
			DialogBox.text = "As you flick the sheets back in one swift motion, the object quickly becomes " + 
			"readily apparant; a rusty, unique looking key. You ponder on the thought of a prison guard " +
			"potentially being this useless.\n\n" + 
			"\"Surely this is a trap?\" you unashamedly and openly ask yourself.\n\n" +
			"Tap <b>T</b> to take the key or tap <b>L</b> to leave it be and return to exploring.";
			if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.cell;
			} else if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_1;
			}
		}

		void state_mirror () {
			DialogBox.text = "As you stare longingly into the imperfect mirror, you reflect on " +
			"what you've ultimately become; rather unsightly. And, <i>much</i> like the " +
			"perfect metaphor this mirror lays out before you, this has primarily been down " +
			"to your long, unhealthy relationship with crack.\n\n" +
			"Tap <b>C</b> to continue to explore your cell.";
			if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.cell;
		}
			
	}
	
}
