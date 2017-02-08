using System;
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
	string artLocation;						// For central card art
	string spriteLocation;					// For a completed sprite. Null if a meal card!
	string ingredientTag;					// Null if not an ingredient
	string[] mechanics;						// TODO make sure we use .length instead of .count now.
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
					mechanics = data.InnerText.split(python_List_Delimiters, StringSplitOptions.RemoveEmptyEntries);
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
}