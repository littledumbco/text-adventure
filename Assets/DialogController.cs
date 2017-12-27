using UnityEngine;
using UnityEngine.UI; // adding in the Unity UI library
using System.Collections;

public class DialogController : MonoBehaviour {
	
	public Text DialogBox;
	// Used this to set up some basic list of states
	private enum States {cell, mirror, sheets, door, sheets_key, cell_key, mirror_lock, sheets_lock, door_lock, door_key, cell_escape};
	private States myState;
	
	// Use this for initialization
	void Start () { myState = States.cell; }
	
	// Setting the basic States and assigning it to the relevant function
	void Update () {
	
		// Used to have a print function here, but was overloading the console so I removed it.
		if (myState == States.cell) { state_cell (); } 
		else if (myState == States.sheets)		{ state_sheets (); } 
		else if (myState == States.mirror)		{ state_mirror (); } 
		else if (myState == States.door)		{ state_door (); } 
		else if (myState == States.sheets_key)	{ state_sheets_key (); } 
		else if (myState == States.cell_key) 	{ state_cell_key (); } 
		else if (myState == States.sheets_lock) { state_sheets_lock (); } 
		else if (myState == States.mirror_lock) { state_mirror_lock (); } 
		else if (myState == States.door_lock)	{ state_door_lock (); } 
		else if (myState == States.door_key)	{ state_door_key (); } 
		else if (myState == States.cell_escape) { state_cell_escape (); }
	}
	
	// Here I'm setting up the content of each state, so if you are in the state 'cell' the DialogBox will be updated to display
	// the relevant text.
	void state_cell () {
		DialogBox.text = 	"You find yourself in a dark and dank" + 
							" prison cell. It is <i>grim</i>. Around you are just a" + 
							" few minor things: Some dirty sheets, a cracked" +
							" mirror and a solid steel, locked prison door.\n\n" +
							"Tap <b>[ M ]</b> to look at the mirror\n\nTap <b>[ D ]</b> to look at the door \n\n" +
							"Tap <b>[ S ]</b> to look at the sheets";
		if 		(Input.GetKeyDown (KeyCode.S))	{ myState = States.sheets; } 
		else if (Input.GetKeyDown (KeyCode.M))	{ myState = States.mirror; } 
		else if (Input.GetKeyDown (KeyCode.D))	{ myState = States.door; }
	}
	
	// Another state example here to show the user they've moved to the 'sheets' state and the relevant key to return.
	void state_sheets () {
		DialogBox.text = 	"Your eyes look the sheets up and down as a sigh escapes your lips. " +
							"The sheets are covered in blood, but unbeknowst to you and due to your recent " +
							"unconcious state, you don't know if it's yours or perhaps a previous unlucky captive.\n\n" +
							"You snap out of that gruesome thought as you quickly notice an outline of an object under the sheet.\n\n" +
							"Tap <b>[ F ]</b> to flick the sheets over \n\nTap <b>[ C ]</b> to continue to explore your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell; } 
		else if (Input.GetKeyDown (KeyCode.F))	{ myState = States.sheets_key; }
	}

	// Users first look at the mirror
	void state_mirror () {
		DialogBox.text = 	"As you stare longingly into the imperfect mirror, you reflect on " +
							"what you've ultimately become; rather unsightly. And, <i>much</i> like the " +
							"perfect metaphor this mirror lays out before you, this has primarily been down " +
							"to your long, unhealthy relationship with crack.\n\n" +
							"Tap <b>[ C ]</b> to continue to explore your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell; }
	}

	// Users first look at the door
	void state_door () {
		DialogBox.text = 	"It's a door. It's locked.\n\n" + "Tap <b>[ C ]</b> to continue exploring your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell; }
	}

	// User interacts with sheets and can pick up the key
	void state_sheets_key () {
		DialogBox.text = 	"As you flick the sheets back in one swift motion, the object quickly becomes " + 
							"readily apparant; a rusty, unique looking key. You ponder on the thought of a prison guard " +
							"potentially being this useless.\n\n" + 
							"\"Surely this is a trap?\" you unashamedly and openly ask yourself.\n\n" +
							"Tap <b>[ T ]</b> to take the key";
		if 		(Input.GetKeyDown (KeyCode.T))	{ myState = States.cell_key; }
	}

	// New state for the cell where the key is now essentially in the user's invisible inventory
	void state_cell_key () {
		DialogBox.text = 	"You step back and consider your options. What now?\n\n" + "Tap <b>[ M ]</b> to look at the mirror \n\n" +
							"Tap <b>[ D ]</b> to try the door \n\nTap <b>[ S ]</b> to oogle the sheets";
		if 		(Input.GetKeyDown (KeyCode.M))	{ myState = States.mirror_lock; } 
		else if (Input.GetKeyDown (KeyCode.S))	{ myState = States.sheets_lock; } 
		else if (Input.GetKeyDown (KeyCode.D))	{ myState = States.door_lock; }
	}
	
	void state_mirror_lock () {
		DialogBox.text = 	"Mirror again.\n\n" + "Tap <b>[ C ]</b> to continue exploring your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell_key; }
	}
	
	void state_sheets_lock () {
		DialogBox.text = 	"Sheets again.\n\n" + "Tap <b>[ C ]</b> to continue exploring your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell_key; }
	}

	void state_door_lock () {
		DialogBox.text = 	"Door lock time.\n\n" + "Tap <b>[ K ]</b> to try the key on the door \n\nTap " +
							"<b>[ C ]</b> to continue exploring your cell";
		if 		(Input.GetKeyDown (KeyCode.C))	{ myState = States.cell_key; } 
		else if (Input.GetKeyDown (KeyCode.K))	{ myState = States.door_key; }
	}
	
	void state_door_key () {
		DialogBox.text = 	"Door unlocked.\n\n" + "Tap <b>[ E ]</b> to escape your imprisonment";
		if 		(Input.GetKeyDown (KeyCode.E))	{ myState = States.cell_escape; }
	}
	
	void state_cell_escape () {
		DialogBox.text = 	"You've escaped!\n\n" + "Tap <b>[ P ]</b> to play again";
		if 		(Input.GetKeyDown (KeyCode.P))	{ myState = States.cell; }
	}
			
}