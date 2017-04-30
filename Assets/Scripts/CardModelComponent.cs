using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardModelComponent : MonoBehaviour {
	private CardModel cardModel;

	public CardModel CardModel {
		get {
			return cardModel;
		}
		set {
			cardModel = value;
			transform.FindChild("Title").GetComponent<Text>().text = cardModel.Title;
			transform.FindChild("Description").GetComponent<Text>().text = cardModel.Description;
			transform.FindChild("Energy Container").FindChild("Text").GetComponent<Text>().text = cardModel.EnergyCost.ToString();
			transform.FindChild("Art").GetComponent<Image>().sprite = cardModel.Sprite;
		}
	}
}
