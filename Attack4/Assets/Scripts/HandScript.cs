using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

namespace Attack4.CardSystem
{
	public class HandScript : MonoBehaviour
	{
		CardGenerator panel;

		Transform parent;
		public Transform expand;


		void Awake()
		{
			GetComponent<DropCard>().enabled = false;
			panel = this.GetComponent<CardGenerator>();
            parent = this.transform.parent;
		}


        public void ContractExpand()
        {
            GameObject[] Hands = GameObject.FindGameObjectsWithTag("Hand");
            foreach (GameObject hand in Hands)
            {
                hand.GetComponent<HandScript>().Contract();
            }
            Expand();
        }




		void Expand()
		{
			this.transform.SetParent(expand);
			this.GetComponent<LayoutElement>().preferredWidth = expand.GetComponent<RectTransform>().rect.width;
			this.GetComponent<LayoutElement>().preferredHeight = expand.GetComponent<RectTransform>().rect.height;
			this.GetComponent<RectTransform>().localPosition = Vector3.zero;
			GetComponent<GridLayoutGroup>().enabled = true;
			GetComponent<DropCard>().enabled = true;
			for (int i = 0; i < panel.Cards.Count; i++)
			{
				panel.Cards[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
			}
		}


		void Contract()
		{
			GetComponent<GridLayoutGroup>().enabled = false;
			this.transform.SetParent(parent);
			this.GetComponent<RectTransform>().localPosition = Vector3.zero;
			GetComponent<DropCard>().enabled = false;
			for (int i = 0; i < panel.Cards.Count; i++)
			{
				panel.Cards[i].GetComponent<RectTransform>().localPosition = this.GetComponent<RectTransform>().localPosition + new Vector3(Mathf.Round(i*1.5f), Mathf.Round(i*1.5f), 0f) + new Vector3 (40, -60, 0);
				panel.Cards[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
		}

	}
}
