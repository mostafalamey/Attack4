using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem.Editor
{
	public class PCDatabase : ScriptableObject 
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
			EditorUtility.SetDirty(this);
		}

		public void DeleteCard(int index)
		{
			PCDB.RemoveAt(index);
			EditorUtility.SetDirty(this);
		}


		public int Count
		{
			get { return PCDB.Count; }
		}

		public PlayCard Get(int i)
		{
			return PCDB.ElementAt(i);
		}
	}
}
