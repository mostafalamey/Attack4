using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem
{
	public class DropCard : MonoBehaviour ,IDropHandler
	{
		public void OnDrop(PointerEventData data)
		{
			if (data.pointerDrag.gameObject.tag == "Card")
			{
				if (this.tag == "Hand")
					if (this.transform.childCount > 7)
						return;
				data.pointerDrag.GetComponent<GenericPlayCard>().parentToReturnTo = this.transform;
			}
		}

	}
}
