using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragger : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {
	private ICardContainer currentCardContainer;
	public ICardContainer CurrentCardContainer {
		get {
			return currentCardContainer;
		}

		set {
			if (currentCardContainer != null && currentCardContainer != value) {
				currentCardContainer.OnCardLeave(gameObject, value);
			}

			currentCardContainer = value;
		}
	}

	private Transform parentWhileDragging;
	private Vector2 mouseOffset = Vector2.zero;
	private CardModel CardModel {
		get {
			return GetComponent<CardModelComponent>().CardModel;
		}
	}

	void Start () {
		parentWhileDragging = GameObject.FindGameObjectWithTag("GamePanel").transform;
	}

	public void OnPointerDown (PointerEventData eventData) {
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		mouseOffset = eventData.position - new Vector2(transform.position.x, transform.position.y);

		transform.SetParent(parentWhileDragging, false);
		transform.position = eventData.position - mouseOffset;
	}

	public void OnDrag (PointerEventData eventData) {
		transform.position = eventData.position - mouseOffset;
	}

	public void OnEndDrag (PointerEventData eventData) {
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		mouseOffset = Vector2.zero;
	}
}
