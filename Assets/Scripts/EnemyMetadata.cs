using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMetadata : MonoBehaviour {
	private EnemyModel enemyModel;

	public EnemyModel EnemyModel {
		get {
			return enemyModel;
		}
		set {
			enemyModel = value;
			UpdateDisplay();
		}
	}

	public void UpdateDisplay () {
		transform.Find("Title").GetComponent<Text>().text = EnemyModel.Title;
		transform.Find("Drop Target").Find("Image").GetComponent<Image>().sprite = EnemyModel.Sprite;

		string newHealth;

		if (EnemyModel.CurrentHealth > 0) {
			newHealth = EnemyModel.CurrentHealth.ToString();
		} else {
			newHealth = "Dead!";
		}

		transform.Find("Health Amount").GetComponent<Text>().text = newHealth;
	}
}
