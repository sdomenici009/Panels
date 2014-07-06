using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
	
	public List<GameObject> cards;
	
	// Use this for initialization
	void Start () {
		for(int i=0; i < 30; i++)
		{
			GameObject card = (GameObject)Instantiate(Resources.Load ("Card 1"), Vector3.zero, Quaternion.identity);
			card.transform.parent = transform;
			card.SetActive(false);
			cards.Add(card);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
