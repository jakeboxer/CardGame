using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IDropHandler, ICardContainer {
	public GameObject cardPrefab;
	private List<GameObject> cards = new List<GameObject>();

	void Start () {
		CardDatabase cardDatabase = GameObject.FindGameObjectWithTag("CardDatabase").GetComponent<CardDatabase>();

		foreach (CardModel cardModel in cardDatabase.GetAllCardModels()) {
			AddCard(cardModel);
		}

		UpdateCardPositions();
	}

	public void OnCardLeave (GameObject card, ICardContainer newContainer) {
		cards.Remove(card);
		UpdateCardPositions();
	}

	public void CancelCardLeave (GameObject card, ICardContainer cancelingContainer) {

	}

	public void OnDrop (PointerEventData eventData) {
		GameObject card = eventData.pointerDrag;
		CardDragger cardDragger = card.GetComponent<CardDragger>();

		if (cardDragger.CurrentCardContainer == (ICardContainer)this) {
			card.transform.SetParent(transform, false);
			UpdateCardPositions();
		} else {
			cardDragger.CurrentCardContainer.CancelCardLeave(card, this);
		}
	}

	private void AddCard (CardModel cardModel) {
		GameObject cardGameObject = Instantiate(cardPrefab);
		cardGameObject.GetComponent<CardModelComponent>().CardModel = cardModel;
		cardGameObject.GetComponent<CardDragger>().CurrentCardContainer = this;
		cardGameObject.transform.SetParent(transform, false);
		cards.Add(cardGameObject);
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
