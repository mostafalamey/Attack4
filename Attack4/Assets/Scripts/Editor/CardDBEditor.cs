using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Attack4.CardSystem;

namespace Attack4.CardSystem.Editor
{
	public partial class CardDBEditor : EditorWindow 
	{
		PCDatabase pcdb;
		SCDatabase scdb;
		PlayCard selectedItem;
		SpellCard SCselectedItem;

		List<GemSlot> tempSlots;

		bool _editSwitch = false;

		bool _pcSwitch = true;
		bool _scSwitch = false;

		string[] _egyptianGods = {"Amun", "Osiris", "Seth", "Thoth", "Isis", "Hapi", "Hathor", "Sekhmet", "Horus", "Anubis", "Sobek", "Bastet" };
		string[] _egyptianSpells = {"ww", "ss", "xx", "cc"};
		string[] _greekGods = {"Zeus", "Poseidon", "Hera", "Athena", "Hades", "Hermes", "Hephaestus", "Aphrodite", "Dionysus", "Artemis", "Ares", "Apollo"};
		string[] _greekSpells = {"bb", "vv", "tt", "ee"};
		string[] _norsGods = {"Odin", "Loki", "Heimdall", "Freya", "Thor", "Angrboda", "Frigga", "Baldur", "Hela", "Hodur", "Sol", "Mani"};
		string[] _norsSpells = {"as", "df", "bn", "kl"};

		int _cardNameIndex;

		const int spriteButtonSize = 100;

		const string PCDATABASE_FILE_NAME = @"Play Cards Database.asset";
		const string SCDATABASE_FILE_NAME = @"Spell Cards Database.asset";
		const string DATABASE_FOLDER_NAME = @"Resources/Database";
		const string PCDATABASE_FULLPATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + PCDATABASE_FILE_NAME;
		const string SCDATABASE_FULLPATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + SCDATABASE_FILE_NAME;


		[MenuItem("Attack4/Cards/Card Editor %#c")]

		public static void init()
		{
			Texture2D icon = EditorGUIUtility.Load("Icons/CardEditorIcon.png") as Texture2D;
			CardDBEditor window = EditorWindow.GetWindow<CardDBEditor>();
			window.minSize = new Vector2 (930,420);
			window.titleContent.text = "Card Editor";
			window.titleContent.image = icon;
			window.Show();
		}

		void OnEnable()
		{
			pcdb = AssetDatabase.LoadAssetAtPath(PCDATABASE_FULLPATH, typeof (PCDatabase)) as PCDatabase;
			scdb = AssetDatabase.LoadAssetAtPath(SCDATABASE_FULLPATH, typeof (SCDatabase)) as SCDatabase;

			if (pcdb == null)
			{
				if (!AssetDatabase.IsValidFolder("Assets" + DATABASE_FOLDER_NAME))
				{
					AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
				}

				pcdb = ScriptableObject.CreateInstance<PCDatabase>();
				AssetDatabase.CreateAsset(pcdb, PCDATABASE_FULLPATH);

				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			if (scdb == null)
			{
				scdb = ScriptableObject.CreateInstance<SCDatabase>();
				AssetDatabase.CreateAsset(scdb, SCDATABASE_FULLPATH);

				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			selectedItem = new PlayCard();
			SCselectedItem = new SpellCard();
			_cardNameIndex = 0;

			tempSlots = new List<GemSlot> ();
			tempSlots.Add (new GemSlot());
			tempSlots.Add (new GemSlot());

		}


		void OnGUI()
		{
			GUILayout.BeginVertical();
			Tabs();
			GUILayout.EndVertical();
			if (_pcSwitch)
			{
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical("Box");
				ListView();
				GUILayout.EndVertical();
				GUI.enabled = true;
				GUILayout.BeginVertical("Box", GUILayout.MinWidth(450));
				AddCardToDatabase();
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
			if (_scSwitch)
			{
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical("Box");
				SCListView();
				GUILayout.EndVertical();
				GUI.enabled = true;
				GUILayout.BeginVertical("Box", GUILayout.MinWidth(450));
				AddSpellCardToDatabase();
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}

		}


		void Tabs()
		{
			GUILayout.BeginHorizontal("Box");
			if (GUILayout.Button("Play Cards", GUILayout.MinWidth(100)))
			{
				_pcSwitch = true;
				_scSwitch = false;
			}
			if (GUILayout.Button("Spell Cards", GUILayout.MinWidth(100)))
			{
				_pcSwitch = false;
				_scSwitch = true;
			}
			if (GUILayout.Button("Joker Cards", GUILayout.MinWidth(100)))
			{
				_pcSwitch = false;
				_scSwitch = false;
			}
			GUILayout.EndHorizontal();

		}
	}
}
