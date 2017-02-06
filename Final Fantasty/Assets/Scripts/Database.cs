using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class Database : MonoBehaviour {
	public TextAsset InventoryAsset;
	public static List<Item> items = new List<Item>();
	public List<Item> inspectorItems = new List<Item>();

	private List<Dictionary<string, string>> itemsDict = newList<Dictionary<string, string>> ();
	private Dictionary<string, string> obj;

	void Start (){
		ReadItems ();
		for (int i = 0; i < items.Count; i++) {
			items.Add (new Item (itemsDict));
		}
		inspectorItems = items;
	}

	void ReadItems() {
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (InventoryAsset.text);
		XmlNode itemList = xmlDoc.GetElementsByTagName ("Item"); //look for the item tag in the xml file

		foreach(XmlNode itemInfo in itemList) { //store all the tag in a list
			XmlNodeList itemContent = itemInfo.ChildNodes;
			obj = newDictionary<string, string>();

			foreach(XmlNode content in itemContent){
				switch(GUIContent.Name){
				case "itemName":
					obj.Add ("itemName", content.InnerText);
					break;
				case "itemDescription":
					obj.Add ("itemDescription", content.InnerText);
					break;
				case "itemSweet":
					obj.Add ("itemSweet", content.InnerText);
					break;
				case "itemSour":
					obj.Add ("itemSour", content.InnerText);
					break;
				case "itemSalty":
					obj.Add ("itemSalty", content.InnerText);
					break;
				case "itemSpicy":
					obj.Add ("itemSpicy", content.InnerText);
					break;
				case "itemType":
					obj.Add ("itemType", content.InnerText);
					break;
				case "multiItems":
					obj.Add ("multiItems", content.InnerText);
					break;
				}
			}
			itemsDict.Add (obj);	//add tag to dict
		}
	}

	//check if item is stackable
	public static bool isItemMultiple(int id) {
		bool isMulti = false;
		for (int i = 0; i < items.Count; i++) { //loop through all the items in the game
			if (items [i].itemID == id) { 
				if (items [i].multiItems) { //if the multiItems in the database xml is true
					isMulti = true;
				}
			}
		}
		return isMulti;
	}

	//check if item is stackable
	public static bool isItemMultiple(int name) {
		bool isMulti = false;
		for (int i = 0; i < items.Count; i++) { //loop through all the items in the game
			if (items [i].itemName == name) { 
				if (items [i].multiItems) { //if the multiItems in the database xml is true
					isMulti = true;
				}
			}
		}
		return isMulti;
		}
		
	//return the name of the item
	public string getNameFromID(int id) { // if our items have ids
		for(int i = 0; i < items.Count; i++){
			if (Item [i].itemID == id) {
				return item [i].itemName;
			}
		}
		return "ERROR";
		Debug.LogError ("ERROR: ITEM NOT FOUND");
	}

	public static void copyItem(Item newItem, Item originalItem){
		Item tempItem = new Item ();
		tempItem = originalItem;

		newItem.itemName = tempItem.itemName;
		newItem.itemID = tempItem.itemID;
		newItem.itemDescription = tempItem.itemDescription;
		newItem.itemSweet = tempItem.itemSweet;
		newItem.itemSour = tempItem.itemSour;
		newItem.itemSalty = tempItem.itemSalty;
		newItem.itemSpicy = tempItem.itemSpicy;
		newItem.itemCounter = tempItem.itemCounter;
		newItem.multiItems = tempItem.multiItems;

	}

}
