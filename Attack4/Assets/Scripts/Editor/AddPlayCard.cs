using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem.Editor
{
	public partial class CardDBEditor 
	{
		void AddCardToDatabase()
		{
			GUILayout.Label("Add New Play Card", EditorStyles.boldLabel);
			selectedItem.CFaction =(Factions) EditorGUILayout.EnumPopup("Faction:", selectedItem.CFaction);
			
			switch (selectedItem.CFaction)
			{
			case (Factions.Egyptian):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _egyptianGods);
				selectedItem.CName = _egyptianGods [_cardNameIndex];
				break;
				
			case (Factions.Greek):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _greekGods);
				selectedItem.CName = _greekGods [_cardNameIndex];
				break;
				
			case (Factions.Nors):
				_cardNameIndex = EditorGUILayout.Popup("Name: ", _cardNameIndex, _norsGods);
				selectedItem.CName = _norsGods [_cardNameIndex];
				break;
			}
			
			selectedItem.CLevel = EditorGUILayout.IntSlider("Level:", selectedItem.CLevel, 0,12);
			selectedItem.CDesc = EditorGUILayout.TextArea(selectedItem.CDesc, GUILayout.Height(45));
			selectedItem.CPieces = EditorGUILayout.IntSlider("Number of pieces:", selectedItem.CPieces, 2,12);


			selectedItem.GemSlotsCount = EditorGUILayout.IntSlider("Number of Gem Slots:", selectedItem.GemSlotsCount, 0,2);
			
			if (selectedItem.GemSlotsCount>0) 
			{
				tempSlots[0].SlotShape = (GemSlot.SlotShapes)EditorGUILayout.EnumPopup ("Slot#1 Shape:", tempSlots[0].SlotShape);
			}
			if (selectedItem.GemSlotsCount>1) 
			{
				tempSlots[1].SlotShape = (GemSlot.SlotShapes)EditorGUILayout.EnumPopup ("Slot#2 Shape:", tempSlots[1].SlotShape);
			}
			
			
			GUILayout.BeginHorizontal();
			

			GUILayout.BeginVertical();
			
				GUILayout.BeginHorizontal();
				
				GUILayout.Space(68);
				selectedItem.AttackTop = EditorGUILayout.IntField(selectedItem.AttackTop, GUILayout.Width(40));
				
				GUILayout.EndHorizontal();
			
			GUILayout.Space(20);
			
				GUILayout.BeginHorizontal();
				
				selectedItem.AttackLeft = EditorGUILayout.IntField(selectedItem.AttackLeft, GUILayout.Width (40));
				GUILayout.Space(20);
				selectedItem.Health = EditorGUILayout.IntField(selectedItem.Health, GUILayout.Width (40), GUILayout.Height(40));
				GUILayout.Space(20);
				selectedItem.AttackRight = EditorGUILayout.IntField(selectedItem.AttackRight, GUILayout.Width(40));
				
				GUILayout.EndHorizontal();
			
			GUILayout.Space(20);
			
				GUILayout.BeginHorizontal();
				
				GUILayout.Space(68);
				selectedItem.AttackBottom = EditorGUILayout.IntField(selectedItem.AttackBottom, GUILayout.Width(40));
				
				GUILayout.EndHorizontal();
			
			GUILayout.EndVertical();
			
			GUILayout.EndHorizontal();

			
			
			//Add new Card Button
			if (_editSwitch)
			{
				if (GUILayout.Button("ِSave Card"))
				{
					if (selectedItem == null)
						return;
					
					_cardNameIndex = 0;
					tempSlots[0] = new GemSlot();
					tempSlots[1] = new GemSlot();
					selectedItem = new PlayCard();
					_editSwitch = false;
				}
				
			}
			else
			{
				if (GUILayout.Button("ِAdd New Card"))
				{
					if (selectedItem == null)
						return;
					
					for (int i = 0; i < selectedItem.GemSlotsCount; i++)
					{
						selectedItem.AddNewGemSlot(tempSlots[i]);
					}
					
					pcdb.AddNewCard(selectedItem);
					_cardNameIndex = 0;
					tempSlots[0] = new GemSlot();
					tempSlots[1] = new GemSlot();
					selectedItem = new PlayCard();
				}
			}
			
		}

	}
}