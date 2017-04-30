using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour {
	private Dictionary<int, EnemyModel> enemiesById = new Dictionary<int, EnemyModel>();

	void Start () {
		enemiesById.Add(1, new EnemyModel(1, "Skeleton", 10, "default"));
	}

	public EnemyModel FindEnemyModel(int id) {
		return enemiesById[id];
	}

	public ICollection<EnemyModel> GetAllEnemyModels() {
		return enemiesById.Values;
	}
}

public class EnemyModel {
	public int Id { get; set; }
	public string Title { get; set; }
	public int StartingHealth { get; set; }
	public Sprite Sprite { get; set; }
	public int CurrentHealth { get; set; }

	public EnemyModel () {
		Id = -1;
	}

	public EnemyModel (int id, string title, int startingHealth, string spriteFilename) {
		Id = id;
		Title = title;
		StartingHealth = startingHealth;
		Sprite = Resources.LoadAll<Sprite>("Sprites/EnemyArt/BODY_skeleton").Single(s => s.name == spriteFilename);

		CurrentHealth = startingHealth;
	}
}