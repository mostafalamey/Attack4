using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Attack4.CardSystem
{
	[System.Serializable]
	public class PlayCard : Card 
	{
		[SerializeField] int _health;
		[SerializeField] int _attackTop;
		[SerializeField] int _attackBottom;
		[SerializeField] int _attackLeft;
		[SerializeField] int _attackRight;
		[SerializeField] int _gemSlotsCount;
		[SerializeField] List<GemSlot> _gemSlots;




		public PlayCard ()
		{ 
			_health = 2;
			_attackTop = _health;
			_attackBottom = _health;
			_attackLeft = _health;
			_attackRight = _health;
			_gemSlotsCount = 0;
			_gemSlots = new List<GemSlot>();

		}



		public PlayCard (int h, int at, int ab, int al, int ar, int gs, int i, int f, string n, string des, int psc, int lvl)
		{ 
			_health = h;
			_attackTop = at;
			_attackBottom = ab;
			_attackLeft = al;
			_attackRight = ar;
			_gemSlotsCount = gs;
			CID = i;
			CFaction = AssignFaction(f);
			CName = n;
			CDesc = des;
			CPieces = psc;
			CLevel = lvl;
			
		}


		//this is a constructor that is accepting an object of type
		//GenericCard and make the current object a clone of this object
		public PlayCard Copy (PlayCard PlayC)
		{
			PlayC.CID = this.CID;
			PlayC.CFaction = this.CFaction;
			PlayC.CName = this.CName;
			PlayC.CDesc = this.CDesc;
			PlayC.CPieces = this.CPieces;
			PlayC.CLevel = this.CLevel;
			PlayC.Health = this.Health;
			PlayC.AttackTop = this.AttackTop;
			PlayC.AttackBottom = this.AttackBottom;
			PlayC.AttackLeft = this.AttackLeft;
			PlayC.AttackRight = this.AttackRight;
			PlayC.GemSlotsCount = this.GemSlotsCount;
			PlayC._gemSlots = this._gemSlots;

			return PlayC;
		}

		public Factions AssignFaction(int f)
		{
			Factions fac = Factions.Egyptian;
			switch (f)
			{
			case 0:
				fac = Factions.Egyptian;
				break;
			case 1:
				fac = Factions.Greek;
				break;
			case 2:
				fac = Factions.Nors;
				break;
			case 3:
				fac = Factions.Hindo;
				break;
			}
			return fac;
		}

		public int AttackTop
		{
			get { return _attackTop; }
			set { _attackTop = value; }
		}

		public int AttackBottom
		{
			get { return _attackBottom; }
			set { _attackBottom = value; }
		}

		public int AttackLeft
		{
			get { return _attackLeft; }
			set { _attackLeft = value; }
		}

		public int AttackRight
		{
			get { return _attackRight; }
			set { _attackRight = value; }
		}

		public int Health
		{
			get { return _health; }
			set { _health = value; }
		}

		public int GemSlotsCount
		{
			get { return _gemSlotsCount; }
			set { _gemSlotsCount = value; }
		}

		public void AddNewGemSlot(GemSlot item)
		{
			_gemSlots.Add(item);
		}

		public GemSlot GetGemSlot (int i)
		{
			return _gemSlots.ElementAt(i);
		}
	}
}
