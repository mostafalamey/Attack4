using UnityEngine;
using System.Collections;


namespace Attack4.CardSystem
{
	public class AdjustInventoryScrollSize : MonoBehaviour 
	{
		float _minWidth;

		void Start()
		{
			_minWidth = this.transform.parent.GetComponent<RectTransform>().rect.width;
		}

		void Update () 
		{
			this.GetComponent<RectTransform>().sizeDelta = new Vector2 (Mathf.Max(this.transform.childCount * 100f, _minWidth), this.GetComponent<RectTransform>().sizeDelta.y);
		}
	}
}
