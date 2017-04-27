using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPresenter : MonoBehaviour {
	public GameObject cardPrefab;
	private CardDatabase cardDatabase;
	
	void Start () {
		cardDatabase = GetComponent<CardDatabase>();
		Debug.Log(cardDatabase.GetAllCardModels().Count);

		foreach(CardModel cardModel in cardDatabase.GetAllCardModels()) {
			GameObject cardGameObject = Instantiate(cardPrefab);
			Transform cardTransform = cardGameObject.transform;
			cardTransform.SetParent(transform);

			cardTransform.FindChild("Title").GetComponent<Text>().text = cardModel.Title;
			cardTransform.FindChild("Description").GetComponent<Text>().text = cardModel.Description;
			cardTransform.FindChild("Energy Container").FindChild("Text").GetComponent<Text>().text = cardModel.EnergyCost.ToString();
			cardTransform.FindChild("Art").GetComponent<Image>().sprite = cardModel.Sprite;
		}
	}
}
