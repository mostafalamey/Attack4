using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Attack4.CardSystem
{
	public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		GameObject _placeHolder;
		Transform _originalParent;

		public Transform parentToReturnTo = null;

		public void OnBeginDrag(PointerEventData data)
		{
			_originalParent = this.transform.parent;
			parentToReturnTo = this.transform.parent;
			this.transform.SetParent (GameObject.Find("Canvas").transform);
			_placeHolder = new GameObject("PlaceHolder");
			_placeHolder.AddComponent<RectTransform>();
			LayoutElement le = _placeHolder.AddComponent<LayoutElement>();
			le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
			le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
			_placeHolder.transform.SetParent (parentToReturnTo);
			_placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
			_originalParent.GetComponent<CardGenerator>().UpdateCardList();
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}


		public void OnDrag(PointerEventData data)
		{
			this.transform.position = data.position;

			int newSiblingIndex = parentToReturnTo.childCount;

			for ( int i = 0; i < parentToReturnTo.childCount; i++)
			{
				if (this.transform.position.x < parentToReturnTo.GetChild(i).transform.position.x)
				{
					newSiblingIndex = i;

					if (_placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
						newSiblingIndex --;

					break;
				}

			}
			_placeHolder.transform.SetSiblingIndex(newSiblingIndex);
		}


		public void OnEndDrag(PointerEventData data)
		{
			this.transform.SetParent(parentToReturnTo);
			if (parentToReturnTo == _originalParent)
				this.transform.SetSiblingIndex(_placeHolder.transform.GetSiblingIndex());
			parentToReturnTo.GetComponent<CardGenerator>().UpdateCardList();
			GetComponent<CanvasGroup>().blocksRaycasts = true;
			Destroy(_placeHolder);
		}
		
	}
}
