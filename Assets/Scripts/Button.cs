using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Button : MonoBehaviour {
	
	bool pressed;
	bool held;
	// Use this for initialization
	void Start () {
		pressed = false;
		held = false;
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
