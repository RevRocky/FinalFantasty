using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class Database : MonoBehaviour {
	public TextAsset InventoryAsset;
	public static List<Item> items = new List<Item>();
	public List<Item> inspectorItems = new List<Item>();

	private List<Dictionary<string, string>> itemDict = newList<Dictionary<string, string>> ();
	private Dictionary<string, string> obj;

	void ReadItems() {
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (InventoryAsset.text);
		XmlNode itemList = xmlDoc.GetElementsByTagName ("Item"); //look for the item tag in the xml file

		foreach(XmlNode itemInfo in itemList) {
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
				
		}
	}



		
}
