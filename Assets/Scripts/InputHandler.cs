using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	RaycastHit hit;
	GameObject currentCard;
	bool rotate = false;
	public Hand hand;
	public Deck deck;
	
	// Use this for initialization
	void Start () {
		hit = new RaycastHit();
		hand = GameObject.Find ("Hand").GetComponent<Hand>();
		deck = GameObject.Find ("Deck").GetComponent<Deck>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						
		if(currentCard != null)
		{
			if(!rotate)
			{
				Vector3 test = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currentCard.transform.position.z + 10));
				currentCard.transform.position = new Vector3(test.x, test.y, currentCard.transform.position.z);
			}
			else
			{
				currentCard.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 555f);
			}
		}
		
		if(Physics.Raycast(ray, out hit))
		{
			Card card = hit.transform.GetComponent<Card>();
			if(card != null)
			{
				if(hand.currentCard != card)
				{
					if(hand.currentCard != null)
						hand.currentCard.hovered = false;
					
					if(card.selectable)
					{
						hand.currentCard = card;
						card.hovered = true;
					}
				}
			}
		}
		else
		{
			if(hand.currentCard != null)
					hand.currentCard.hovered = false;
				
			hand.currentCard = null;
		}
		
		
		if(Input.GetMouseButtonDown(0))
		{	
			rotate = false;
			if(Physics.Raycast(ray, out hit))
			{				
				
				Button button = hit.transform.GetComponent<Button>();
				
				if(button != null)
				{
					button.DrawCard(hand, deck);
				}
				
				Flip hitFlip = hit.transform.GetComponent<Flip>();
				
				if(hitFlip != null)
				{
					hitFlip.flip = true;
				}
				
				if(currentCard == null)
				{
					CardUVMap map = hit.transform.GetComponent<CardUVMap>();
					
					if(map != null)
					{
						currentCard = hit.transform.gameObject;
					}
				}
				else
				{
					currentCard = null;
				}
			}
		}
		
		if(Input.GetMouseButtonDown(1))
		{	
			if(currentCard != null && rotate != true)
			{
				rotate = true;
			}
			else
			{
				currentCard = null;
				rotate = false;
			}
		}
	}
}
