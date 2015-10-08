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
		Transform parent;
		GameObject _placeHolder;

		public Transform expand;


		void Awake()
		{
			GetComponent<DropCard>().enabled = false;
            parent = this.transform.parent;
		}


        public void ContractExpand()
        {
            GameObject[] Hands = GameObject.FindGameObjectsWithTag("Hand");
            foreach (GameObject hand in Hands)
            {
               if(hand.GetComponent<HandScript>())
					hand.GetComponent<HandScript>().Contract();
            }
            Expand();
        }




		void Expand()
		{
			_placeHolder = new GameObject("PlaceHolder");
			_placeHolder.AddComponent<RectTransform>();
			LayoutElement le = _placeHolder.AddComponent<LayoutElement>();
			le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
			le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
			_placeHolder.AddComponent<CanvasGroup>();
			_placeHolder.transform.SetParent (this.transform.parent.transform);
			_placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

			this.transform.SetParent(expand);
			this.GetComponent<LayoutElement>().preferredWidth = expand.GetComponent<RectTransform>().rect.width;
			this.GetComponent<LayoutElement>().preferredHeight = expand.GetComponent<RectTransform>().rect.height;
			this.GetComponent<RectTransform>().localPosition = Vector3.zero;
			GetComponent<GridLayoutGroup>().enabled = true;
			GetComponent<DropCard>().enabled = true;
			for (int i = 0; i < this.transform.childCount; i++)
			{
				this.transform.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = true;
			}
		}


		void Contract()
		{
			GetComponent<GridLayoutGroup>().enabled = false;
			this.transform.SetParent(parent);
			if (_placeHolder)
				this.transform.SetSiblingIndex(_placeHolder.transform.GetSiblingIndex());
			Destroy(_placeHolder);
			this.GetComponent<RectTransform>().localPosition = Vector3.zero;
			GetComponent<DropCard>().enabled = false;
			for (int i = 0; i < this.transform.childCount; i++)
			{
				this.transform.GetChild(i).GetComponent<RectTransform>().localPosition = Vector3.zero;
				this.transform.GetChild(i).transform.position = this.transform.position + new Vector3((i*2f), (i*2f), 0f) + new Vector3 (40, -60, 0);
				this.transform.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
		}

	}
}
