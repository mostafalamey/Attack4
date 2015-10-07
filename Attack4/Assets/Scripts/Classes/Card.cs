using UnityEngine;
using System.Collections;

namespace Attack4.CardSystem
{
	public enum Factions {Egyptian, Greek, Nors, Hindo}


	[System.Serializable]
	public class Card 
	{

		[SerializeField] int _id;
		[SerializeField] Factions _faction;
		[SerializeField] string _name;
		[SerializeField] string _desc;
		[SerializeField] int _pieces;
		[SerializeField] int _level;



		public Card()
		{
			_id = 0;
			_faction = Factions.Egyptian;
			_name = "";
			_desc = "Description";
			_pieces = 3;
			_level = 2;
		}

		public Card(int i, Factions fac, string n, string des, int psc, int lvl)
		{
			_id = i;
			_faction = fac;
			_name = n;
			_desc = des;
			_pieces = psc;
			_level = 0;
		}
		

		public int CID 
		{
			get { return _id; }
			set { _id = value; }
		}
		
		public Factions CFaction 
		{
			get { return _faction; }
			set { _faction = value; }
		}

		
		public string CName 
		{
			get { return _name; }
			set { _name = value; }
		}
		
		public string CDesc 
		{
			get { return _desc; }
			set { _desc = value; }
		}
		
		public int CPieces 
		{
			get { return _pieces; }
			set { _pieces = value; }
		}
		
		public int CLevel 
		{
			get { return _level; }
			set { _level = value; }
		}
	}
}
