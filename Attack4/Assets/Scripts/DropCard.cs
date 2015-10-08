using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem
{
	public class DropCard : MonoBehaviour ,IDropHandler
	{
		public CardGenerator cardsInventory;

		public void OnDrop(PointerEventData data)
		{
			if (data.pointerDrag.gameObject.tag == "Card")
			{
				if (this.tag == "Hand")
					if (this.transform.childCount > 7)
						return;
				GenericPlayCard cardScript = data.pointerDrag.GetComponent<GenericPlayCard>();
				cardScript.parentToReturnTo = this.transform;
				cardScript._myCard.Hand = this.GetComponent<CreateCards>().hand;
				cardsInventory.UpdateCardList();
			}
		}

	}
}
