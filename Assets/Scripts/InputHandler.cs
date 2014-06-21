using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	RaycastHit hit;
	Card currentCard;
	
	// Use this for initialization
	void Start () {
		hit = new RaycastHit();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						
		if(currentCard != null)
		{
			Vector3 test = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, currentCard.transform.position.z + 10));
			currentCard.transform.position = new Vector3(test.x, test.y, currentCard.transform.position.z);
		}
		
		if(Input.GetMouseButtonDown(0))
		{	
			if(Physics.Raycast(ray, out hit))
			{				
				
				Flip hitFlip = hit.transform.GetComponent<Flip>();
				
				if(hitFlip != null)
				{
					hitFlip.flip = true;
				}
				
				if(currentCard == null)
				{
					Card card = hit.transform.GetComponent<Card>();
					
					if(card != null)
					{
						currentCard = card;
					}
				}
				else
				{
					currentCard = null;
				}
			}
		}
	}
}
