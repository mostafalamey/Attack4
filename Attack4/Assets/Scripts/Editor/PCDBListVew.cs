using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem.Editor
{
	public partial class CardDBEditor 
	{
		Vector2 _scrollPosPC;

		void ListView()
		{

			GUI.enabled = (!_editSwitch);
			_scrollPosPC = EditorGUILayout.BeginScrollView( _scrollPosPC, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			DisplayCards();
			EditorGUILayout.EndScrollView();
			
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.Height(24));
			
			EditorGUILayout.LabelField("Total Play Cards: " + pcdb.Count);
			
			GUILayout.EndHorizontal();
		}


		void DisplayCards()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Faction", EditorStyles.boldLabel, GUILayout.MaxWidth(190), GUILayout.MinWidth(90));
			GUILayout.Label("Name", EditorStyles.boldLabel, GUILayout.MaxWidth(160), GUILayout.MinWidth(60));
			GUILayout.Label("Level", EditorStyles.boldLabel, GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
			GUILayout.Label("Pieces", EditorStyles.boldLabel, GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
			GUILayout.Label("Gems", EditorStyles.boldLabel, GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
			GUILayout.Label("Health", EditorStyles.boldLabel, GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
			GUILayout.Label("", GUILayout.MinWidth(24));
			GUILayout.Label("", GUILayout.MinWidth(24));
			GUILayout.EndHorizontal();

			for ( int i = 0; i < pcdb.Count; i++)
			{
				GUILayout.BeginHorizontal("Box");
				GUILayout.Label(pcdb.Get(i).CFaction.ToString(), "Box", GUILayout.MaxWidth(190), GUILayout.MinWidth(90));
				GUILayout.Label(pcdb.Get(i).CName, "box", GUILayout.MaxWidth(160), GUILayout.MinWidth(60));
				GUILayout.Label(pcdb.Get(i).CLevel.ToString(), "box", GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
				GUILayout.Label(pcdb.Get(i).CPieces.ToString(), "box", GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
				GUILayout.Label(pcdb.Get(i).GemSlotsCount.ToString(), "box", GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
				GUILayout.Label(pcdb.Get(i).Health.ToString(), "box", GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
				Texture2D editIcon = EditorGUIUtility.Load("Icons/EditIcon.png") as Texture2D;


				if (GUILayout.Button(editIcon, GUILayout.MinWidth(24), GUILayout.Height(24)))
				{
					tempSlots[0] = new GemSlot();
					tempSlots[1] = new GemSlot();
					selectedItem = new PlayCard();

					selectedItem = pcdb.Get(i);

					switch (selectedItem.CFaction)
					{
						case (Factions.Egyptian):
							for (int x = 0; x < _egyptianGods.Length; x++)
							{
								if (selectedItem.CName == _egyptianGods[x])
								{
									_cardNameIndex = x;
								}
							}
							break;
						case (Factions.Greek):
							for (int x = 0; x < _greekGods.Length; x++)
							{
								if (selectedItem.CName == _greekGods[x])
								{
									_cardNameIndex = x;
								}
							}
							break;
						case (Factions.Nors):
							for (int x = 0; x < _norsGods.Length; x++)
							{
								if (selectedItem.CName == _norsGods[x])
								{
									_cardNameIndex = x;
								}
							}
							break;
					}

					if (selectedItem.GemSlotsCount>0)
						tempSlots[0] = selectedItem.GetGemSlot(0);
					if (selectedItem.GemSlotsCount>1)
						tempSlots[1] = selectedItem.GetGemSlot(1);

					_editSwitch = true;
				}



				Texture2D deleteIcon = EditorGUIUtility.Load("Icons/DeleteIcon.png") as Texture2D;
				if (GUILayout.Button(deleteIcon, GUILayout.MinWidth(24), GUILayout.Height(24)))
				{
					if (EditorUtility.DisplayDialog("Delete Play Card", "Are you sure you want to delete " + pcdb.Get(i).CName + "!", "Delete", "Cancel"))
					{
						pcdb.DeleteCard(i);
						tempSlots[0] = new GemSlot();
						tempSlots[1] = new GemSlot();
						selectedItem = new PlayCard();
					}
				}
				GUILayout.EndHorizontal();
			}

		}
	}
}
