using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class Database : MonoBehaviour {

	// TODO Tidy this up, what is this all doing?
	public TextAsset InventoryAsset;
	private List<Dictionary<string, string>> itemsDict = newList<Dictionary<string, DatabaseEntry>> ();

	// TODO We need to ensure this persists across scenes, otherwise there will be a signifigant overhead on game start
	void Start (){
		ReadItems ();		// We shouldn't need to do anything more. The database is a behind the scenes thing
	}

	/*
	 * Parses an XML file to create a hashtable mapping each unique card tag
	 * to its information associated with the card (also stored in the XML file)
	 */
	void ReadItems() {
		string itemTag;

		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (InventoryAsset.text);					 				// Loading the XML document
		XmlNode itemList = xmlDoc.GetElementsByTagName ("Card"); 				//look for the card tag in the xml file

		foreach(XmlNode itemInfo in itemList) { 
			XmlNodeList itemContent = itemInfo.ChildNodes;
			iemsDict.add(itemInfo.Item["Tag"], new DatabaseEntry(itemInfo));	// Associate the tag with a database entry read from the XML's node
			}
			itemsDict.Add (obj);	//add tag to dict
		}
	}
}