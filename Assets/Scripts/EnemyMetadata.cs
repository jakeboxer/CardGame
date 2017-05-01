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
		transform.FindChild("Title").GetComponent<Text>().text = EnemyModel.Title;
		transform.FindChild("Drop Target").FindChild("Image").GetComponent<Image>().sprite = EnemyModel.Sprite;
		transform.FindChild("Health Amount").GetComponent<Text>().text = EnemyModel.CurrentHealth.ToString();
	}
}
