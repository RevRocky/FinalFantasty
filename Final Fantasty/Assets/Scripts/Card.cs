using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is intended to be a rough sketch of
 * card implementation only
 */
public class Card : MonoBehaviour {

	public const int NUM_STATS = 6;

	private string Name;
	private Sprite graphic;
	private Mechanic MechanicOne;
	private Mechanic MechanicTwo;
	private Mechanic MechanicThree;
	private int[] stats;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Fetch method for stats
	public int[] getStats() {return stats;}

	// Sets stats to be the supplied array
	// If supplied array is not of correct size, it will simply preserve the current set of stats
	public void setStats(int[] newStats) {
		if (newStats.Length == NUM_STATS) {
			stats = newStats;
		}
		return;
	}
}
