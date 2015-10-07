using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Attack4.CardSystem
{
	public enum SpellTypes {Ice, Fire}



	[System.Serializable]
	public class SpellCard : Card 
	{
		[SerializeField] int _power;
		[SerializeField] SpellTypes _spellType;



		//Constructor
		public SpellCard()
		{
			_power = 1;
			_spellType = SpellTypes.Fire;
		}



		//Setters&Getters
		public int SCPower 
		{
			get { return _power; }
			set { _power = value; }
		}
		
		public SpellTypes SCType 
		{
			get { return _spellType; }
			set { _spellType = value; }
		}



		//Methods
		public void ApplySpell (PlayCard _card)
		{
			switch (_spellType)
			{

			case (SpellTypes.Ice):
				if (_card.CFaction == this.CFaction)
					_card.Health += _power;
				else
					_card.Health -= _power;
				break;

			case (SpellTypes.Fire):
				if (_card.CFaction == this.CFaction)
				{
					_card.AttackTop += _power;
					_card.AttackRight += _power;
					_card.AttackLeft += _power;
					_card.AttackBottom += _power;
				}
				else
				{
					_card.AttackTop -= _power;
					_card.AttackRight -= _power;
					_card.AttackLeft -= _power;
					_card.AttackBottom -= _power;
				}
				break;
			}

		}
	}
}
