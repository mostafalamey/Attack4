using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
//using Attack4.CardSystem.Editor;


namespace Attack4.CardSystem
{
	public class GetMyFirstCards : MonoBehaviour 
	{
//		PCDatabase _pcdb;
//		PlayCard _myCard;
//		JsonData _myCardsJson;
//		string _jsonString;
//
//		public CardsList _cardInventory;
//		
//		void Awake()
//		{
//			if (File.Exists(Application.dataPath + "/Resources/Database/MyCardsInventory.json"))
//				_jsonString = File.ReadAllText(Application.dataPath + "/Resources/Database/MyCardsInventory.json");
//
//			if (_jsonString == null)
//			{
//				_pcdb = Resources.Load("Database/Play Cards Database", typeof(PCDatabase)) as PCDatabase;
//				if (_pcdb != null)
//				{
//					for (int i = 0; i < _pcdb.Count; i++)
//					{
//						if (_pcdb.Get(i).CLevel <= 3)
//						{
//							_myCard = new PlayCard();
//							_myCard = _pcdb.Get(i).Copy(_myCard);
//							_cardInventory.AddNewCard(_myCard);
//							_myCardsJson += JsonMapper.ToJson(_myCard);
//						}
//					}
//					File.WriteAllText(Application.dataPath + "/Resources/Database/MyCardsInventory.json", _myCardsJson.ToString());
//				}
//			}
//		}

	}
}
