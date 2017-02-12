using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is intended to be a rough sketch of
 * card implementation only
 */
public class Card : MonoBehaviour {

	public const int NUM_STATS = 6;
	public GameObject CardPrefab;													// Drag this over in the editor

	private string name;
	private string type;
	private Sprite graphic;
	private List<Mechanic> mechanics;
	private byte[] stats;


	// Use this for initialization
	void Start () {
		
	}

	// Instantiates a new card prefab object and returns reference to its card script
	public Card instantiateCard() {
		Card newCard = (Card)Instantiate(CardPrefab);								// TODO Ask the location manager where to put the card!								
	}

	// Initialises a card from a database entry
	// TODO Make compataible with DatabaseEntry accessors
	void Init(DatabaseEntry cardInfo) {
		name = cardInfo.name;
		type = cardInfo.type;
		stats = cardInfo.stats;
		mechanics = instantiateMechanics(cardInfo.mechanics);
		graphic =	// TODO load a sprite from memory
	}

	/*
	 * Reads through a supplied list of mechanics and adding instantiated
	 * copies of each mechanic to a list of mechanics that is then returned
	 * to the calling environment
	 */
	private List<Mechanic> instantiateMechanics(List<string> mechanicStrings) {
		List<Mechanic> mechanicList = new List<Mechanic>(mechanicStrings.Count);
		foreach(string mechanic in mechanicStrings) {
			try {
				Mechanic newMechanic = gameObject.AddComponent(mechanic);						// Adding the mechanic by its name to the list
				newMechanic.init(this);															// Polymorphism should run the method on the /actual/ mechanic
				mechanicList.Add(newMechanic);													// Adding the new mechanic to the list
			}
			catch (Exception e) {
				Debug.Log("Mechanic {0} is not implemented. Double check database", mechanic);	// If the mechanic doesn't exist print to debug log and move on
			}
		}
		return mechanicList;
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
