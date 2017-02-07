using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;												// TODO find System.Drawing alternative or set up unity to work with it!
using System.IO;


/* This is a class that contains some static methods that will permit the
 * generation of meal card images based upon the stats of the generated card.
*/
public static class IngredientStack : MonoBehaviour {

	private List<Card> theCards;
	public const int NUM_STATS=6;
	public const string MEAL_IMAGE_DIRECTORY =  "..";

	public void Start() {
		theCards = new List<Card>();
	}

	public void Update() {
		if (theCards.Count > 0) {
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
		int sumStats = new int[NUM_STATS]  {0, 0, 0, 0, 0, 0};
		string tags = new string [theCards.Count];						// The tags for each card
		List<Mechanic> mechanicList = new List<Mechanic> ();
		int j;
		string searchTag;
		Card mealCard;
		BitMap cardArt;													// Obtained either through DB retrieval or combination of images

		// Loop over cumulating mechanics, stats and tags for each of our cards
		foreach (Card card in theCards) {
			int i = 0;													// TODO Fix this garbage
			for (j = 0; j < NUM_STATS; j++) {
				sumStats [j] += card.stats [j];							// Taking the sum of each stat
			}
			tags[i] = card.tag;											// Adding the tag to the list
			foreach (Mechanic mechanic in card.mechanics) {
				if (! mechanic.inheritable) {
					mechanicList.Add(mechanic);							// If the mechanic can be inherited add it. TODO: Check for duplicates?				
				}
			}
			i++;
		}
		Array.Sort(tags, StringComparer.InvariantCulture);				// Sort dem tags
		foreach (string tag in tags) {
			searchTag += tag; 											// Combine those tags
		}
		try {
			DatabaseEntry mealEntry = DB.seach(searchTag);				// Returns a clone of the database entry
			cardArt = Image.FromFile(Path.Combine(MEAL_IMAGE_DIRECTORY, mealEntry.artLocation));
			mealEntry.stats = combineStatsGood(mealEntry.stats, sumStats);
			mealEntry.mechanics = combineMechanicsGood(mealEntry.mechanics, mechanicList);
		}
		catch (ItemNotFound e) {
			cardArt = ImageProcessing.hybridCardArt(theCards);			// A static method which will create a hybrid card art quickly and efficiently!
			int[] mealStats = combineStatsBad(sumStats);		// Combines the stats and adds heavy penalty to the stats
			mechanicList = addBadMechanic(mechanicList);
			// TODO: Create DataBaseEntry Struct
		}
		// TODO: Create new card from DB entry
	}

	// Combines stats of the ingredients with the bonuses bestowed by the meal card
	private int[] combineStatsGood(int[] baseStats, int[] ingredientStats) {
		int j;
		for (j = 0; j < NUM_STATS; j++) {
			baseStats[j] += ingredientStats[j];			// Taking the sum of each stat
		}
		return baseStats;								// I want to make the assignment explicit above											
	}

	// Adds some hefty negative stats to the meals created by the ingredients
	private int[] combineStatsBad(int[] baseStats) {
		return baseStats; 								// TODO What stat penalties should be applied
	}

	// Combines any mechanics the ingredients have with the list of mechanics of the meal.
	private List<Mechanic> combineMechanicsGood(List<Mechanic> baseMechanics, List<Mechanic> ingredientMechanics) {
		List<Mechanic> newMechanics = new List<Mechanic>(baseMechanics.Count + ingredientMechanics.Count);			// Creating a static sized buffer
		newMechanics.AddRange(baseMechanics);
		newMechanics.AddRange(ingredientMechanics);
		return newMechanics;
	}

	// Randomly adds a negative side-effect to
	private List<Mechanic> addBadMechanic(List<Mechanic> ingredientMechanics) {
		;		// TODO Come up with negative side-effects
	}

}
