using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {
	
	public List<GameObject> cards;
	public float speed;
	public float scaleSpeed;
	public Card currentCard;
	public float offset;
	
	// Use this for initialization
	void Start () {
		cards = new List<GameObject>();
		speed = 5f;
		scaleSpeed = 5f;
		currentCard = null;
		offset = 2.1f;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0; i < cards.Count; i++)
		{
			cards[i].GetComponent<Card>().xPos = i-cards.Count/2;
			
			if(Vector3.Distance(cards[i].transform.position, new Vector3(offset*i-cards.Count/2f, -1.5f, -2)) > 0.1f 
				|| Vector3.Distance(cards[i].transform.localScale, new Vector3(2, 3, 0.1f)) > 0.1f)
			{
				cards[i].GetComponent<Card>().selectable = false;
				cards[i].transform.position = Vector3.MoveTowards(cards[i].transform.position, new Vector3(offset*i-cards.Count/2f, -1.5f, -2), speed * Time.deltaTime);
				cards[i].transform.localScale = Vector3.Lerp(cards[i].transform.localScale, new Vector3(2, 3, 0.1f), scaleSpeed * Time.deltaTime);
			}
			else
			{
				cards[i].GetComponent<Card>().selectable = true;
			}
		}
	}
}
