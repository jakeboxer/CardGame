﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyDropTarget : MonoBehaviour, IDropHandler {
	public void OnDrop (PointerEventData eventData) {
		GameObject cardGameObject = eventData.pointerDrag;
		CardModel cardModel = cardGameObject.GetComponent<CardModelComponent>().CardModel;
		EnemyMetadata enemyMetadata = GetComponentInParent<EnemyMetadata>();

		if (cardModel.effects.damage > 0) {
			// Take damage
			enemyMetadata.EnemyModel.CurrentHealth -= cardModel.effects.damage;
		}

		if (cardModel.effects.heal > 0) {
			// Heal
			enemyMetadata.EnemyModel.CurrentHealth += cardModel.effects.heal;
		}

		enemyMetadata.UpdateDisplay();

		cardGameObject.GetComponent<CardDragger>().CurrentCardContainer.CancelCardLeave(cardGameObject, null);
	}
}