using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Button : MonoBehaviour {
	
	bool pressed;
	bool held;
	public float listPos;
	public GameObject textParent;
	// Use this for initialization
	void Awake () {
		pressed = false;
		held = false;
		textParent = (GameObject)GameObject.Instantiate(Resources.Load ("posText"));
		textParent.transform.position = transform.position + new Vector3(1, .75f, 0);
		textParent.transform.parent = transform;
	}
	
	public void DrawCard(Hand hand, Deck deck)
	{
		if(deck.cards.Count > 0)
		{
			GameObject card = deck.cards.ElementAt(0);
			card.SetActive(true);
			hand.cards.Add(card);
			deck.cards.RemoveAt(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
