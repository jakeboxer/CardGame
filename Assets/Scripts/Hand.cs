using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
	public GameObject cardPrefab;
	private List<GameObject> cards = new List<GameObject>();

	private CardDatabase CardDatabase {
		get {
			return GameObject.FindGameObjectWithTag("CardDatabase").GetComponent<CardDatabase>();
		}
	}

	void Start () {
		foreach (CardModel cardModel in CardDatabase.GetAllCardModels()) {
			AddCard(cardModel);
		}

		UpdateCardPositions();
	}

	private void AddCard(CardModel cardModel) {
		GameObject cardGameObject = Instantiate(cardPrefab);
		cardGameObject.GetComponent<CardModelComponent>().CardModel = cardModel;
		cardGameObject.transform.SetParent(transform, false);
		cards.Add(cardGameObject);
	}

	private void UpdateCardPositions() {
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
