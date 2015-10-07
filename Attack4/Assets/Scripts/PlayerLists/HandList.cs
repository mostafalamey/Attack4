using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem
{
	public class HandList : ScriptableObject 
	{
		[SerializeField]
		List<PlayCard> hand = new List<PlayCard>();
		
		public void AddNewCard(PlayCard item)
		{
			int _id = -1;
			foreach (PlayCard c in hand)
			{
				if (c.CID > _id)
					_id = c.CID;
			}
			item.CID = _id + 1;
			hand.Add(item);
		}
		
		public void DeleteCard(int index)
		{
			hand.RemoveAt(index);
		}
		
		
		public int Count
		{
			get { return hand.Count; }
		}
		
		public PlayCard Get(int i)
		{
			return hand.ElementAt(i);
		}
	}
}