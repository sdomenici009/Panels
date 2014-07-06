using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	RaycastHit hit;
	public Hand hand;
	public Deck deck;
	public InfiniteList buttonList;
	
	// Use this for initialization
	void Start () {
		hit = new RaycastHit();
		buttonList = GameObject.Find("List").GetComponent<InfiniteList>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit))
		{
			Card card = hit.transform.GetComponent<Card>();
			if(card != null)
			{
				if(hand.hoverCard != card)
				{
					if(hand.hoverCard != null)
						hand.hoverCard.hovered = false;
					
					if(card.selectable)
					{
						hand.hoverCard = card;
						card.hovered = true;
					}
				}
			}
			else
			{
				if(hand.hoverCard != null)
					hand.hoverCard.hovered = false;
					
				hand.hoverCard = null;
			}
		}
		else
		{
			if(hand.hoverCard != null)
				hand.hoverCard.hovered = false;
				
			hand.hoverCard = null;
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			buttonList.selected = false;
		}
		
		if(Input.GetMouseButtonDown(0))
		{	
			if(!buttonList.selected)
				buttonList.selected = true;
			
			if(Physics.Raycast(ray, out hit))
			{				
				
				InfiniteList iList = hit.transform.GetComponent<InfiniteList>();
				if(iList != null)
				{
					iList.selected = true;
				}
				
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
				
				if(hand.selectedCard == null)
				{
					CardUVMap map = hit.transform.GetComponent<CardUVMap>();
					
					if(map != null)
					{
						hand.selectedCard = hit.transform.GetComponent<Card>();
						hand.selectedCard.selected = true;
					}
				}
				else
				{
					hand.selectedCard.selected = false;
					hand.selectedCard = null;
				}
			}
			else
			{
				if(hand.selectedCard != null)
				{
					hand.selectedCard.selected = false;
					hand.selectedCard = null;
				}
			}
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			buttonList.AddButton((GameObject)Instantiate(Resources.Load("Button")));
		}
	}
}
