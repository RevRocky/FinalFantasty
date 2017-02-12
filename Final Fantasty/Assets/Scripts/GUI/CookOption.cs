using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookOption : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	// TODO Needs to know parent Itemstack
	public Text textBox;
	public string message;
	public IEnumerator messageRoutine;
	public Button buttonBox;

	// Use this for initialization
	void Start () {
		buttonBox.enabled = false;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}

		if (transform.childCount >= 2) {
			buttonBox.enabled = true;
		} else {
			buttonBox.enabled = false;
		}

	}

	public void OnDrop(PointerEventData eventData) {


		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {

			d.parentToReturnTo = this.transform;
		}


		if (transform.childCount >= 2) {
			buttonBox.enabled = true;
		} else {
			buttonBox.enabled = false;
		}



	}
}