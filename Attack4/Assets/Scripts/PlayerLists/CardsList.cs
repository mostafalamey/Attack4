using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem
{
	public class CardsList : ScriptableObject 
	{
		[SerializeField]
		List<PlayCard> PCDB = new List<PlayCard>();
		
		public void AddNewCard(PlayCard item)
		{
			int _id = -1;
			foreach (PlayCard c in PCDB)
			{
				if (c.CID > _id)
					_id = c.CID;
			}
			item.CID = _id + 1;
			PCDB.Add(item);
		}
		
		public void DeleteCard(int index)
		{
			PCDB.RemoveAt(index);
		}

		public void RemoveCard (PlayCard item)
		{
			PCDB.Remove(item);
		}
		
		
		public int Count
		{
			get { return PCDB.Count; }
		}
		
		public PlayCard Get(int i)
		{
			return PCDB.ElementAt(i);
		}

		public void Clear()
		{
			PCDB.Clear();
		}
	}
}
