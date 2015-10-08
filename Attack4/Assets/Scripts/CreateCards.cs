using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Attack4.CardSystem
{
	public class CreateCards : MonoBehaviour 
	{
		public GameObject _genericPC;
		public int hand;


		public void CreateSomeCards(CardsList _cardsToGenerate)
		{
			for (int i = 0; i < _cardsToGenerate.Count; i++)
			{
				if (_cardsToGenerate.Get(i).Hand == hand)
				{
					GameObject _tempCard = Instantiate(_genericPC) as GameObject;
					_tempCard.transform.SetParent(this.transform);
					_tempCard.transform.localScale = Vector3.one;
					_tempCard.GetComponent<GenericPlayCard>()._myCard = _cardsToGenerate.Get(i);
					_tempCard.name = _tempCard.GetComponent<GenericPlayCard>()._myCard.CName;
				}
			}

			for (int i = 0; i < this.transform.childCount; i++)
			{
				this.transform.GetChild(i).transform.position = this.transform.position + new Vector3((i*2f),(i*2f), 0f);
			}
		}
	}
}
