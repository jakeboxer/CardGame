using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class CardDatabase : MonoBehaviour {
}

public class CardModel {
    public int Id { get; set; }
    public string Title { get; set; }
    public int Attack { get; set; }

    public CardModel() {
        Id = -1;
    }

    public CardModel(JsonData data) {
        Id = (int)data["id"];
        Title = (string)data["title"];
        Attack = (int)data["attack"];
    }
}
