using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem.Editor
{
	public partial class CardDBEditor 
	{
		void AddSpellCardToDatabase()
		{
			GUILayout.Label("Add New Spell Card", EditorStyles.boldLabel);
			SCselectedItem.CFaction =(Factions) EditorGUILayout.EnumPopup("Faction:", SCselectedItem.CFaction);
			
			switch (SCselectedItem.CFaction)
			{
			case (Factions.Egyptian):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _egyptianSpells);
				SCselectedItem.CName = _egyptianSpells [_cardNameIndex];
				break;
				
			case (Factions.Greek):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _greekSpells);
				SCselectedItem.CName = _greekSpells [_cardNameIndex];
				break;
				
			case (Factions.Nors):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _norsSpells);
				SCselectedItem.CName = _norsSpells [_cardNameIndex];
				break;
			}
			
			SCselectedItem.CLevel = EditorGUILayout.IntSlider("Level:", SCselectedItem.CLevel, 0,12);
			SCselectedItem.CDesc = EditorGUILayout.TextArea(SCselectedItem.CDesc, GUILayout.Height(45));
			SCselectedItem.CPieces = EditorGUILayout.IntSlider("Number of pieces:", SCselectedItem.CPieces, 2,12);

			GUILayout.Label("Type: ", GUILayout.MaxWidth(80), GUILayout.MinWidth(20));
			SCselectedItem.SCType =(SpellTypes) EditorGUILayout.EnumPopup(SCselectedItem.SCType);

			GUILayout.BeginHorizontal();
			GUILayout.Label("Power: ", GUILayout.MaxWidth(80), GUILayout.MinWidth(20));
			SCselectedItem.SCPower = EditorGUILayout.IntSlider(SCselectedItem.SCPower, 1,12);
			GUILayout.EndHorizontal();


			//Add new Card Button
			if (_editSwitch)
			{
				if (GUILayout.Button("ِSave Card"))
				{
					if (SCselectedItem == null)
						return;
					
					_cardNameIndex = 0;
					SCselectedItem = new SpellCard();
					_editSwitch = false;
				}
				
			}
			else
			{
				if (GUILayout.Button("ِAdd New Card"))
				{
					if (SCselectedItem == null)
						return;

					scdb.AddNewCard(SCselectedItem);
					_cardNameIndex = 0;
					SCselectedItem = new SpellCard();
				}
			}

		}
	}
}
