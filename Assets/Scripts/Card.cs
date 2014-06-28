using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public bool hovered;
	public float speed;
	public float scaleSpeed;
	public float xPos;
	public bool selectable;

	// Use this for initialization
	void Start () {
		speed = 5f;
		scaleSpeed = 5f;
		hovered = false;
		selectable = true;
		xPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(hovered)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, -.425f ,-3), speed * Time.deltaTime);
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4, 6, 0.1f), scaleSpeed * Time.deltaTime);
		}
	}
}
