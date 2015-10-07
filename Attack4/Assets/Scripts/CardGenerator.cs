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

		public CardsList _cardInventory;
		public List<GameObject> Cards = new List<GameObject>();
		public GameObject _genericPC;


		
		void Start()
		{
			_cardInventory = ScriptableObject.CreateInstance<CardsList>();

			if(!File.Exists(Application.dataPath + "/Resources/MyCards/" + this.name + ".json"))
				return;

//			WWW request = new WWW(Application.dataPath + @"/Resources/MyCards/" + this.name);
//
//			while (!request.isDone)
//			{
//				Debug.Log(request.progress);
//			}
//		
//			Debug.Log (request.text);

			_jsonString = File.ReadAllText(Application.dataPath + "/Resources/MyCards/" + this.name + ".json").ToString();

			_myCardsJson = JsonMapper.ToObject(_jsonString);
			
			if ( _myCardsJson.Count == 0)
				return;
			
			for (int i = 0; i < _myCardsJson.Count; i++)
			{
				_myCard = new PlayCard((int)_myCardsJson[i]["Health"], (int)_myCardsJson[i]["AttackTop"], (int)_myCardsJson[i]["AttackBottom"], 
				                       (int)_myCardsJson[i]["AttackLeft"], (int)_myCardsJson[i]["AttackRight"], (int)_myCardsJson[i]["GemSlotsCount"], 
				                       (int)_myCardsJson[i]["CID"], (int)_myCardsJson[i]["CFaction"], _myCardsJson[i]["CName"].ToString(), _myCardsJson[i]["CDesc"].ToString(), 
				                       (int)_myCardsJson[i]["CPieces"], (int)_myCardsJson[i]["CLevel"]);
				_cardInventory.AddNewCard(_myCard);
			}

			CreateCards(_cardInventory);
		}


		public void CreateCards(CardsList _cardsToGenerate)
		{
			for (int i = 0; i < _cardsToGenerate.Count; i++)
			{
				GameObject _tempCard = Instantiate(_genericPC) as GameObject;
				_tempCard.transform.SetParent(this.transform);
				_tempCard.transform.position = this.transform.position + new Vector3(i*1.5f, i*1.5f, 0f);
				_tempCard.transform.localScale = Vector3.one;
				_tempCard.GetComponent<GenericPlayCard>()._myCard = _cardsToGenerate.Get(i);
				_tempCard.name = _tempCard.GetComponent<GenericPlayCard>()._myCard.CName;
				Cards.Add(_tempCard);
			}
		}


		public void UpdateCardList()
		{
			Cards.Clear();
			_cardInventory.Clear();
			for (int i = 0; i < this.transform.childCount; i++)
			{
				if (this.transform.GetChild(i).tag == "Card")
				{
					Cards.Add(this.transform.GetChild(i).gameObject);
					_cardInventory.AddNewCard(this.transform.GetChild(i).GetComponent<GenericPlayCard>()._myCard);
				}
			}

			_myCardsJson = "[";
			for (int i = 0; i < _cardInventory.Count; i++)
			{
				_myCardsJson += JsonMapper.ToJson(_cardInventory.Get(i));
				if ( i < _cardInventory.Count -1)
					_myCardsJson += ",";
			}
			_myCardsJson += "]";
			File.WriteAllText(Application.dataPath + "/Resources/MyCards/" + gameObject.name + ".json", _myCardsJson.ToString());
		}

	}
}
