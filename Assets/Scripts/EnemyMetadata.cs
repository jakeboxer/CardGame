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
			transform.FindChild("Title").GetComponent<Text>().text = enemyModel.Title;
			transform.FindChild("Drop Target").FindChild("Image").GetComponent<Image>().sprite = enemyModel.Sprite;
			transform.FindChild("Health Amount").GetComponent<Text>().text = enemyModel.CurrentHealth.ToString();
		}
	}
}
