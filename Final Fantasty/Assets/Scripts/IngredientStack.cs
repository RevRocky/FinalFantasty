using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;
using System.IO;


/* This is a class that contains some static methods that will permit the
 * generation of meal card images based upon the stats of the generated card.
*/
public static class IngredientStack : MonoBehaviour{

	private List<Card> theCards;
	public const int NUM_STATS=6;
	public const string MEAL_IMAGE_DIRECTORY =  "..";

	public void Start() {
		theCards = new List<Card>();
	}

	public void Update() {
		if (theCards.length > 0) {
			// Display Update Button. Ensuring that the button has access to this instances classes
		}
	}

	/*
	 * Dynamically combines the stack of cards in to one meal card and delivers that object to where
	 * it needs to go.
	 * Presently assumes that card stats are in a 6-tuple and that tags of meal cards are listed in sorted order.
	 */
	public Card combineCards() {
		// TODO: Verify that the above assumptions are correct
		int[NUM_STATS] sumStats 	= {0, 0, 0, 0, 0, 0};
		string[theCards.length] tags;									// The tags for each card
		list<Mechanic> mechanicList = new List<Mechanic> mechanicList;
		int j;
		string searchTag;
		Card mealCard;
		BitMap cardArt;													// Obtained either through DB retrieval or combination of images

		// Loop over cumulating mechanics, stats and tags for each of our cards
		foreach (Card card in theCards) {
			for (j = 0; j < NUM_STATS; j++) {
				sumStats[j] += card.stats[j]							// Taking the sum of each stat
			}
			tags[i] = card.tag;											// Adding the tag to the list
			foreach (Mechanic mechanic in card.Mechanics) {
				if (! mechanic.inheritable) {
					mechanicList.Add(mechanic);							// If the mechanic can be inherited add it. TODO: Check for duplicates?				
				}
			}
		}
		Array.sort(tags);												// Sort dem tags
		foreach (string tag in tags) {
			searchTag += tag 											// Combine those tags
		}
		try {
			DatabaseEntry mealEntry = DB.seach(searchTag);				// Returns a clone of the database entry
			cardArt = Image.FromFile(Path.Combine(MEAL_IMAGE_DIRECTORY, mealEntry.artLocation);

		}


	}
}
