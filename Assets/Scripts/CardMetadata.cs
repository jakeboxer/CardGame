using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMetadata : MonoBehaviour {
	private CardModel cardModel;

	public CardModel CardModel {
		get {
			return cardModel;
		}
		set {
			cardModel = value;
			transform.Find("Title").GetComponent<Text>().text = cardModel.Title;
			transform.Find("Description").GetComponent<Text>().text = cardModel.Description;
			transform.Find("Energy Container").Find("Text").GetComponent<Text>().text = cardModel.EnergyCost.ToString();
			transform.Find("Art").GetComponent<Image>().sprite = cardModel.Sprite;
		}
	}
}
