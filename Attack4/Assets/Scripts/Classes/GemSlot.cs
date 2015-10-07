using UnityEngine;
using System.Collections;

namespace Attack4.CardSystem
{


	[System.Serializable]
	public class GemSlot
	{
		public enum SlotShapes {Diamond, Square, Triangle, Hexagon}

		[SerializeField] SlotShapes _slotShape;
		[SerializeField] bool _equipped;



		public GemSlot()
		{
			_slotShape = SlotShapes.Diamond;
			_equipped = false;
		}



		public SlotShapes SlotShape
		{
			get { return _slotShape; }
			set { _slotShape = value;}
		}

		public bool Equipped
		{
			get { return _equipped; }
			set { _equipped = value; }
		}

	}
}
