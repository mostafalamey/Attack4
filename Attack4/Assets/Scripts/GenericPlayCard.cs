using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace Attack4.CardSystem
{
	public class GenericPlayCard : DraggableObject
	{
		public PlayCard _myCard;
		public Image cardFace;
		public Image cardBack;
		public Text cardName;

		void Awake()
		{
			_myCard = new PlayCard();
		}
		

		void Start () 
		{
			if (_myCard != null)
			{
				cardName.text = _myCard.CName;
				cardFace.sprite = Resources.Load("Sprites/EC_" + _myCard.CName, typeof (Sprite)) as Sprite;
				cardBack.sprite = Resources.Load("Sprites/" + _myCard.CFaction.ToString() + "_Card_Back", typeof (Sprite)) as Sprite;
			}

			//        ************************Temporary Card Face***************************
			//        **********************************************************************
			cardFace.sprite = Resources.Load("Sprites/Egyptian_Card_Back", typeof (Sprite)) as Sprite;

			//        **********************************************************************

			if (this.transform.parent.name == "Hand")
				GetComponent<CanvasGroup>().blocksRaycasts = false;
			else
				GetComponent<CanvasGroup>().blocksRaycasts = true;

		}
	}
}

