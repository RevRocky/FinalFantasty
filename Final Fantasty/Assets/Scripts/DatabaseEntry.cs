using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.XML;

// A tiny struct for holding the database entry of a card!
// <3 Rocky
public struct DatabaseEntry {
	string name;
	string description;
	string type;
	string artLocation;
	List<string> Mechanics;
	bool multiItems;
	int[6] stats;

	public DatabaseEntry() {
		;						// TODO Look over database and figure out least messy approach
	}
}