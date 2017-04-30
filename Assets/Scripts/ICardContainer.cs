using System;
using UnityEngine;

public interface ICardContainer {
	void OnCardLeave(GameObject card, ICardContainer newContainer);
	void CancelCardLeave(GameObject card, ICardContainer cancelingContainer);
}
