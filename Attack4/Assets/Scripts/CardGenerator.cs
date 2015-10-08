using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

namespace Attack4.CardSystem
{
	public class CardGenerator : MonoBehaviour 
	{

		PlayCard _myCard;
		string _jsonString;
		JsonData _myCardsJson = new JsonData();

		GameObject[] Hands;
		public CardsList cardInventory;


		
		void Start()
		{
			Hands = GameObject.FindGameObjectsWithTag("Hand");

			cardInventory = ScriptableObject.CreateInstance<CardsList>();

			if(!File.Exists(Application.dataPath + "/Resources/MyCards/CardsInventory.json"))
				return;

			_jsonString = File.ReadAllText(Application.dataPath + "/Resources/MyCards/CardsInventory.json").ToString();

			_myCardsJson = JsonMapper.ToObject(_jsonString);
			
			if ( _myCardsJson.Count == 0)
				return;

			for (int i = 0; i < _myCardsJson.Count; i++)
			{
				_myCard = new PlayCard((int)_myCardsJson[i]["Health"], (int)_myCardsJson[i]["AttackTop"], (int)_myCardsJson[i]["AttackBottom"], 
				                       (int)_myCardsJson[i]["AttackLeft"], (int)_myCardsJson[i]["AttackRight"], (int)_myCardsJson[i]["GemSlotsCount"], (int)_myCardsJson[i]["Hand"], 
				                       (int)_myCardsJson[i]["CID"], (int)_myCardsJson[i]["CFaction"], _myCardsJson[i]["CName"].ToString(), _myCardsJson[i]["CDesc"].ToString(), 
				                       (int)_myCardsJson[i]["CPieces"], (int)_myCardsJson[i]["CLevel"]);
				cardInventory.AddNewCard(_myCard);
			}

			foreach (GameObject hand in Hands)
			{
				hand.GetComponent<CreateCards>().CreateSomeCards(cardInventory);
			}
		}


		public void UpdateCardList()
		{
			_myCardsJson = "[";
			for (int i = 0; i < cardInventory.Count; i++)
			{
				_myCardsJson += JsonMapper.ToJson(cardInventory.Get(i));
				if ( i < cardInventory.Count -1)
					_myCardsJson += ",";
			}
			_myCardsJson += "]";
			File.WriteAllText(Application.dataPath + "/Resources/MyCards/CardsInventory.json", _myCardsJson.ToString());
		}

	}
}
