using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	RaycastHit hit;
	Card currentCard;
	bool rotate = false;
	
	// Use this for initialization
	void Start () {
		hit = new RaycastHit();
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
		
		if(Input.GetMouseButtonDown(0))
		{	
			rotate = false;
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
