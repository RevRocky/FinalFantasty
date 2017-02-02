﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Implements the AlDente functionality
 * On activate it will have a timer tick down.
 * Should the card containing this be combined before the timer
 * reaches zero, it will cause a positive effect on the resulting meal
 * 
 * Version: 0.1
 * Author: Rocky Petkov 
 */
public class AlDente : Mechanic {

	public const int NUM_STATS = 6;
	public  const string DESCRIPTION = "Combine this card into a meal before time is up for Great Rewards";


	/*
	 * Constructs an AlDente mechanic
	 * ParentCard, description are both passed to
	 * the constructor of the parent class
	 */
	public AlDente(Card parentCard) : base(parentCard, DESCRIPTION) {
		;
	}

	// This method will contain any effects that happen when a card is drawn into a player's hand
	public override void onDraw () {
		;									// It does nothing when drawn in to one's hand
	}

	// When we enter play we want to activate the effect as well as create a timer near the card
	public override void onPlayEnter () {
		activate();							// Activate that sonuvabitch
		// Create a new timer!
	}

	// If there is still time left when the card is combined, we augment the stats of the parent
	public override void onCombine () {
		if (timer.timeRemaining > 0.00) {
				getParent().setStats(boostStats());
			}
		}

	// Boosts the stats of the parent card by 1 each. 2 for the highest stat
	// Accurate only for a test implementation
	private int[] boostStats() {
		int[] newStats = getParent().getStats();				// Getting the parent's stats
		int maxStatIndex = maxIndex(newStats);			// Index of the highest stat!
		int i;											// A loop counter
		for (i = 0; i < NUM_STATS; i++) {
			if (i == maxStatIndex) {
				newStats[i] += 2;						// Increment biggest stat by 2
			}
			else {
				newStats[i] += 1;						// Increment other stats by 1
			}
		}
		return newStats;
	}

	// Contains any effects that are triggered when a card is "stacked" upon another
	public override void onStack () {
		;												// Nothing happens if we stack a card!
	}
}
