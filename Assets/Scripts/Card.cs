using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public bool hovered = false;
	public float speed;
	public float scaleSpeed;
	public float xPos = 0;
	public bool selectable;

	// Use this for initialization
	void Start () {
		selectable = true;
		speed = 5f;
		scaleSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(hovered)
		{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4, 6, 0.1f), scaleSpeed * Time.deltaTime);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos, -.425f ,-3), speed * Time.deltaTime);
		}
	}
}
