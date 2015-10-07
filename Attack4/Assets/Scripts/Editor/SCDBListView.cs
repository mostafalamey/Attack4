using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace Attack4.CardSystem.Editor
{
	public partial class CardDBEditor 
	{
		Vector2 _scrollPosSC;

		void SCListView()
		{
			
			GUI.enabled = (!_editSwitch);
			_scrollPosSC = EditorGUILayout.BeginScrollView( _scrollPosSC, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			DisplaySpellCards();
			EditorGUILayout.EndScrollView();

		}

		
		void DisplaySpellCards()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Faction", EditorStyles.boldLabel, GUILayout.MaxWidth(190), GUILayout.MinWidth(90));
			GUILayout.Label("Name", EditorStyles.boldLabel, GUILayout.MaxWidth(160), GUILayout.MinWidth(60));
			GUILayout.Label("Level", EditorStyles.boldLabel, GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
			GUILayout.Label("Pieces", EditorStyles.boldLabel, GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
			GUILayout.Label("Type", EditorStyles.boldLabel, GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
			GUILayout.Label("Power", EditorStyles.boldLabel, GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
			GUILayout.Label("", GUILayout.MinWidth(24));
			GUILayout.Label("", GUILayout.MinWidth(24));
			GUILayout.EndHorizontal();

			for ( int i = 0; i < scdb.Count; i++)
			{
				GUILayout.BeginHorizontal("Box");
				GUILayout.Label(scdb.Get(i).CFaction.ToString(), "Box", GUILayout.MaxWidth(190), GUILayout.MinWidth(90));
				GUILayout.Label(scdb.Get(i).CName, "box", GUILayout.MaxWidth(160), GUILayout.MinWidth(60));
				GUILayout.Label(scdb.Get(i).CLevel.ToString(), "box", GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
				GUILayout.Label(scdb.Get(i).CPieces.ToString(), "box", GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
				GUILayout.Label(scdb.Get(i).SCType.ToString(), "box", GUILayout.MaxWidth(140), GUILayout.MinWidth(40));
				GUILayout.Label(scdb.Get(i).SCPower.ToString(), "box", GUILayout.MaxWidth(150), GUILayout.MinWidth(50));
				Texture2D editIcon = EditorGUIUtility.Load("Icons/EditIcon.png") as Texture2D;


				if (GUILayout.Button(editIcon, GUILayout.MinWidth(24), GUILayout.Height(24)))
				{
					SCselectedItem = new SpellCard();
					
					SCselectedItem = scdb.Get(i);
					
					switch (SCselectedItem.CFaction)
					{
					case (Factions.Egyptian):
						for (int x = 0; x < _egyptianSpells.Length; x++)
						{
							if (SCselectedItem.CName == _egyptianSpells[x])
							{
								_cardNameIndex = x;
							}
						}
						break;
					case (Factions.Greek):
						for (int x = 0; x < _greekSpells.Length; x++)
						{
							if (SCselectedItem.CName == _greekSpells[x])
							{
								_cardNameIndex = x;
							}
						}
						break;
					case (Factions.Nors):
						for (int x = 0; x < _norsSpells.Length; x++)
						{
							if (SCselectedItem.CName == _norsSpells[x])
							{
								_cardNameIndex = x;
							}
						}
						break;
					}

					_editSwitch = true;
				}

				Texture2D deleteIcon = EditorGUIUtility.Load("Icons/DeleteIcon.png") as Texture2D;
				if (GUILayout.Button(deleteIcon, GUILayout.MinWidth(24), GUILayout.Height(24)))
				{
					if (EditorUtility.DisplayDialog("Delete Spell Card", "Are you sure you want to delete " + scdb.Get(i).CName + "!", "Delete", "Cancel"))
					{
						scdb.DeleteCard(i);
						SCselectedItem = new SpellCard();
					}
				}
				
				GUILayout.EndHorizontal();
			}

			
		}

	}
}
