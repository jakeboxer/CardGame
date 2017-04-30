using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LitJson;
using System.IO;

public class CardDatabase : MonoBehaviour {
	private Dictionary<int, CardModel> cardsById = new Dictionary<int, CardModel>();

	void Start() {
		string jsonPath = Application.dataPath + "/StreamingAssets/cards.json";
		JsonData cardJson = JsonMapper.ToObject(File.ReadAllText(jsonPath));

		foreach(JsonData cardData in cardJson) {
			CardModel cardModel = new CardModel(cardData);
			cardsById.Add(cardModel.Id, cardModel);
		}
	}

	public CardModel FindCardModel(int id) {
		return cardsById[id];
	}

	public ICollection<CardModel> GetAllCardModels() {
		return cardsById.Values;
	}
}

public class CardModel {
    public int Id { get; set; }
    public string Title { get; set; }
	public string Description { get; set; }
	public int EnergyCost { get; set; }
	public Sprite Sprite { get; set; }

    public CardModel() {
        Id = -1;
    }

    public CardModel(JsonData data) {
        Id = (int)data["id"];
        Title = (string)data["title"];
		Description = (string)data["description"];
		EnergyCost = (int)data["energy_cost"];

		string spriteFilename = (string)data["sprite_filename"];
		Sprite[] itemSprites = Resources.LoadAll<Sprite>("Sprites/CardArt/roguelike_items");
		Sprite = itemSprites.Single(s => s.name == spriteFilename);
    }
}
