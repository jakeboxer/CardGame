using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour, IDropHandler, ICardContainer {
	private List<GameObject> cards = new List<GameObject>();

	public void OnDrop (PointerEventData eventData) {
		GameObject card = eventData.pointerDrag;

		if (!cards.Contains(card)) {
			cards.Add(card);
		}

		card.GetComponent<CardDragger>().CurrentCardContainer = this;

		card.transform.SetParent(transform, false);
		UpdateCardPositions();
	}

	public void OnCardLeave(GameObject card, ICardContainer newContainer) {

	}

	public void CancelCardLeave(GameObject card, ICardContainer cancelingContainer) {
		card.transform.SetParent(transform, false);
		UpdateCardPositions();
	}

	private void UpdateCardPositions () {
		if (cards.Count > 0) {
			float cardWidth = cards[0].GetComponent<RectTransform>().sizeDelta.x;

			for (int i = 0; i < cards.Count; i++) {
				GameObject card = cards[i];
				card.GetComponent<RectTransform>().anchoredPosition = new Vector2(
					(cardWidth * i) - (cardWidth * (cards.Count - 1) * 0.5f),
					0
				);
			}
		}
	}
}
