using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * An abstract class outlining the basics of what mechanics can do.
 * For the time being, each type of method activation will be defined in
 * all of the mechanics but, in the actual implementation activation methods 
 * which do not apply will be nothing more than stubs.
 * 
 * Version 0.1 (Mostly a demonstration. I will rework this from a software archetecture point of view.
 * 
 * Author: Rocky Petkov
 */
public abstract class Mechanic : MonoBehaviour {


	private bool activated;			// Tracks whether the mechanic has been activated yet.
	private string toolTip;			// A tooltip associated with the mechanic. May be useful for a hover over dialogue
	private Card parent;			// Allows a mechanic to access information pertaining to the card it belongs to!
	public bool inheritable;		// Tracks if the mechanic is able to be passed down to meals with this card


	public void init(Card parentCard, string description, bool inheritable) {
		parent = parentCard;
		toolTip = description;
		activated = false;
		this.inheritable = inheritable;

	}

	// This method will contain any effects that happen when a card is drawn into a player's hand
	public abstract void onDraw ();

	// Contains any effects that happen when a card enters play
	public abstract void onPlayEnter ();

	// Contains any effects that happens when ingredients containing this card are combined. 
	public abstract void onCombine ();

	// Contains any effects that are triggered when a card is "stacked" upon another
	public abstract void onStack (); 

	// Accessor for parent card object
	public Card getParent() {
		return parent;
	}

	// Accessor for tool tip
	public string getToolTip() {
		return toolTip;
	}

	// Accessor for the activated property
	public bool getActivated() {
		return activated;
	}

	// Flips the activated property from False to True
	public void activate() {
		if (! activated) {
			activated = true;		// Flip that!
		}
	}
}