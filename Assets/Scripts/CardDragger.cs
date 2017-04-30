using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragger : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {
	private Vector2 mouseOffset = Vector2.zero;
	private CardModel CardModel {
		get {
			return GetComponent<CardModelComponent>().CardModel;
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		mouseOffset = eventData.position - new Vector2(transform.position.x, transform.position.y);

		transform.position = eventData.position - mouseOffset;
	}

	public void OnDrag(PointerEventData eventData) {
		transform.position = eventData.position - mouseOffset;
	}

	public void OnEndDrag(PointerEventData eventData) {
		mouseOffset = Vector2.zero;
	}
}
