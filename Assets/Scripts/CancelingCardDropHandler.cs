using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelingCardDropHandler : MonoBehaviour, IDropHandler {
	public void OnDrop (PointerEventData eventData) {
		GameObject card = eventData.pointerDrag;
		card.GetComponent<CardDragger>().CurrentCardContainer.CancelCardLeave(card, null);
	}
}
