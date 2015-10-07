using UnityEngine;
//using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem
{
	public class SCDatabase : ScriptableObject
	{
		[SerializeField]
		List<SpellCard> SCDB = new List<SpellCard>();



		public void AddNewCard(SpellCard item)
		{
			int _id = -1;
			foreach (SpellCard c in SCDB)
			{
				if (c.CID > _id)
					_id = c.CID;
			}
			item.CID = _id + 1;
			SCDB.Add(item);
//			EditorUtility.SetDirty(this);
		}


		public void DeleteCard(int index)
		{
			SCDB.RemoveAt(index);
//			EditorUtility.SetDirty(this);
		}
		
		
		public int Count
		{
			get { return SCDB.Count; }
		}


		public SpellCard Get(int i)
		{
			return SCDB.ElementAt(i);
		}

	}
}
