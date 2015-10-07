//using System.Collections;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//
//public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//	public int[] attacks = {0,0,0,0};
//	public Text leftNum;
//	public Text rightNum;
//	public Text topNum;
//	public Text botNum;
//	public Text cardHealth;
//	public int health;
//	public bool draggable = false;
//
//	public Transform parentToReturnTo = null;
//
//	public Transform cardPos;
//	public Hand myhand;
//
//    public float updateTime;
//
//
//	void Start()
//	{
//		myhand = transform.parent.GetComponent<Hand>();
//	}
//
//	public void OnBeginDrag(PointerEventData data)
//	{
//		draggable = transform.parent.GetComponent<Hand> ().myTurn;
//		if (draggable) {
//			parentToReturnTo = this.transform.parent;
//			this.transform.SetParent (this.transform.parent.parent);
//			GetComponent<CanvasGroup> ().blocksRaycasts = false;
//		}
//	}
//
//	public void OnDrag(PointerEventData data)
//	{
//		if (draggable)
//			this.transform.position = data.position;
//	}
//
//	public void OnEndDrag(PointerEventData data)
//	{
//        Move();
//	}
//
//
//    public void Move()
//    {
//        if (draggable)
//        {
//            this.transform.SetParent(parentToReturnTo);
//            GetComponent<CanvasGroup>().blocksRaycasts = true;
//            if (parentToReturnTo.tag == "Board")
//            {
//                myhand.myHand.Remove(this.gameObject);
//                this.transform.position = cardPos.position;
//                draggable = false;
//                parentToReturnTo.GetComponent<Slot>().Reserve();
//                StartCoroutine(UpdateNumbers(updateTime));
//            }
//        }
//    }
//	
//
//	// Update is called once per frame
//	void Update () 
//	{
//		leftNum.text = attacks[0].ToString();
//		rightNum.text = attacks[1].ToString();
//		topNum.text = attacks[2].ToString();
//		botNum.text = attacks[3].ToString();
//		cardHealth.text = health.ToString();
//	
//	}
//
//
//
//	IEnumerator UpdateNumbers( float seconds)
//	{
//		int cardPos = this.transform.parent.GetSiblingIndex ();
//		GameObject.Find ("Main Camera").GetComponent<GameManager> ().EndTurn ();
//
//        if ((cardPos) % 4 != 0)
//        {
//            Transform card = this.transform.parent.parent.GetChild(cardPos - 1);
//            Card leftCard = card.GetComponentInChildren<Card>();
//            if (leftCard != null && card.GetChild(0).tag != this.tag)
//            {
//                int x = Mathf.Min(leftCard.attacks[1], attacks[0]);
//                for (int i = 0; i < x; i++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    leftCard.attacks[1] -= 1;
//                    attacks[0] -= 1;
//                }
//                int rt = leftCard.attacks[1];
//                for (int r = 0; r < rt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    health -= 1;
//                    leftCard.attacks[1] -= 1;
//                }
//                int lt = attacks[0];
//                for (int l = 0; l < lt; l++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    leftCard.health -= 1;
//                    attacks[0] -= 1;
//                }
//            }
//        }
//
//        if ((cardPos + 1) % 4 != 0)
//        {
//            Transform card = this.transform.parent.parent.GetChild(cardPos + 1);
//            Card rightCard = card.GetComponentInChildren<Card>();
//            if (rightCard != null && card.GetChild(0).tag != this.tag)
//            {
//                int x = Mathf.Min(rightCard.attacks[0], attacks[1]);
//                for (int i = 0; i < x; i++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    rightCard.attacks[0] -= 1;
//                    attacks[1] -= 1;
//                }
//                int lt = rightCard.attacks[0];
//                for (int r = 0; r < lt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    health -= 1;
//                    rightCard.attacks[0] -= 1;
//                }
//                int rt = attacks[1];
//                for (int l = 0; l < rt; l++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    rightCard.health -= 1;
//                    attacks[1] -= 1;
//                }
//
//            }
//        }
//
//
//        if (cardPos - 4 >= 0)
//        {
//            Transform card = this.transform.parent.parent.GetChild(cardPos - 4);
//            Card topCard = card.GetComponentInChildren<Card>();
//            if (topCard != null && card.GetChild(0).tag != this.tag)
//            {
//                int x = Mathf.Min(topCard.attacks[3], attacks[2]);
//                for (int i = 0; i < x; i++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    topCard.attacks[3] -= 1;
//                    attacks[2] -= 1;
//                }
//                int bt = topCard.attacks[3];
//                for (int r = 0; r < bt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    health -= 1;
//                    topCard.attacks[3] -= 1;
//                }
//                int tt = attacks[2];
//                for (int r = 0; r < tt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    topCard.health -= 1;
//                    attacks[2] -= 1;
//                }
//            }
//        }
//
//        if (cardPos + 4 <= 11)
//        {
//            Transform card = this.transform.parent.parent.GetChild(cardPos + 4);
//            Card botCard = card.GetComponentInChildren<Card>();
//            if (botCard != null && card.GetChild(0).tag != this.tag)
//            {
//                int x = Mathf.Min(botCard.attacks[2], attacks[3]);
//                for (int i = 0; i < x; i++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    botCard.attacks[2] -= 1;
//                    attacks[3] -= 1;
//                }
//                int tt = botCard.attacks[2];
//                for (int r = 0; r < tt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    health -= 1;
//                    botCard.attacks[2] -= 1;
//                }
//                int bt = attacks[3];
//                for (int r = 0; r < bt; r++)
//                {
//                    yield return new WaitForSeconds(seconds);
//                    botCard.health -= 1;
//                    attacks[3] -= 1;
//                }
//
//            }
//        }
//
//		GameObject.Find ("Main Camera").GetComponent<GameManager> ().ChangeTurn ();
//	}
//}
