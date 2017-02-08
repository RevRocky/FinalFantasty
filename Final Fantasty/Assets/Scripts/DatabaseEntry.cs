using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.XML;

// A tiny class for holding the database entry of a card!
// <3 Rocky
// TODO Write get and set methods!
public class DatabaseEntry {
	string name;
	string description;
	string type;
	string artLocation;						// For central card art
	string spriteLocation;					// For a completed sprite. Null if a meal card!
	string ingredientTag;					// Null if not an ingredient
	List<string> mechanics;				
	bool multiItems;
	fixed byte stats[6];					// Take note of the fact I'm storing this in a byte!

	/*
	 * Constructor takes an XML node and loops through sub-nodes assogning
	 * data to correct attributes!
	*/
	public DatabaseEntry(XmlNode card_info) {
		string[] python_List_Delimiters = {"[", ",", "]"}
		int i;

		foreach(XmlNode data in itemContent){
			switch(GUIContent.Name){
				case "Type":
					type = data.InnerText;
					// TODO Check for type and set multiItems appropriately
				break;
				case "Name":
					name = data.InnerText;
				break;
				case "Description":
					description = data.InnerText;
				break;
				case "Stats":
					string[] statString = data.InnerText.Split(python_List_Delimiters, 
											StringSplitOptions.RemoveEmptyEntries);		// Parsing into array of strings!
					for (i = 0; i < 6; i++) {
						stats[i] = Byte.Parse(statString[i]);		// Writing to stats array!
					}
				break;
				case "Mechanics":
					mechanics = data.InnerText.split(python_List_Delimiters, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
				break;
				case "Art":
					artLocation = content.InnerText;
					break;
				case "Picture Location":
					spriteLocation = content.InnerText;
				break;
				case "Ingredient Tag":
					ingredientTag = content.InnerText
				break;
			}
		}
	}

	// A constructor only used by the clone method to create a new Database Entry.
	// TODO use our set methods
	public DatabaseEntry(string name, string description, string type, string artLocation, string spriteLocation,
		string ingredientTag, List<string> mechanics, bool multiItems, byte[] stats) {

		// Check if the stats array is of the correct size
		if (stats.Length() != 6) {
			throw new Exception("Improper stat array given!");
		}
		this.name 			= name;
		this.description;	= description;
		this.type;			= type;
		this.artLocation;	= artLocation;						// For central card art
		this.spriteLocation = spriteLocation;					// For a completed sprite. Null if a meal card!
		this.ingredientTag	= ingredientTag;					// Null if not an ingredient
		this.mechanics	    = Mechanics;			
		this.multiItems		= multiItems;
		this.stats;			= stats;							// Take note of the fact I'm storing this in a byte!\
	}

	// Returns a deep copy of this database entry
	public DatabaseEntry clone() {
		return new DatabaseEntry(name, description, type, artLocation, 
			spriteLocation, ingredientTag, mechanics, multiItems, stats);	// Return a brand new DB entry with same type of info
	}
}