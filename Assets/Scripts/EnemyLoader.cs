using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour {
	public int enemyId;
	public GameObject enemyPrefab;

	void Start () {
		EnemyDatabase enemyDatabase = GameObject.FindGameObjectWithTag("EnemyDatabase").GetComponent<EnemyDatabase>();
		EnemyModel enemyModel = enemyDatabase.FindEnemyModel(enemyId);
		GameObject enemyGameObject = Instantiate(enemyPrefab);
		enemyGameObject.GetComponent<EnemyMetadata>().EnemyModel = enemyModel;

		GameObject gamePanel = GameObject.FindGameObjectWithTag("GamePanel");
		enemyGameObject.transform.SetParent(gamePanel.transform, false);
		enemyGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
	}
}
