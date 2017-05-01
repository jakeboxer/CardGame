using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyDropTarget : MonoBehaviour, IDropHandler {
	public void OnDrop (PointerEventData eventData) {
		GameObject cardGameObject = eventData.pointerDrag;
		CardModel cardModel = cardGameObject.GetComponent<CardMetadata>().CardModel;
		EnemyMetadata enemyMetadata = GetComponentInParent<EnemyMetadata>();

		if (cardModel.effects.damage > 0) {
			enemyMetadata.EnemyModel.TakeDamage(cardModel.effects.damage);
		}

		if (cardModel.effects.heal > 0) {
			// Heal
			enemyMetadata.EnemyModel.Heal(cardModel.effects.heal);
		}

		enemyMetadata.UpdateDisplay();

		cardGameObject.GetComponent<CardDragger>().CurrentCardContainer.CancelCardLeave(cardGameObject, null);
	}
}
