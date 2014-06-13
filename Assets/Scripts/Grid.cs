using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	
	Vector2 gridSize = Vector2.one*7;
	float spacing = 1.5f;
	
	// Use this for initialization
	void Start () {		
		float camHalfHeight = Camera.main.orthographicSize;
    	float camHalfWidth = Camera.main.aspect * camHalfHeight; 
		
		Vector3 topLeftPosition = new Vector3(-camHalfWidth, camHalfHeight, 0) + Camera.main.transform.position; 
		
		topLeftPosition += new Vector3(1 / 2, -1 / 2, 0);
				
		for(int i=0; i < gridSize.x; i++)
		{
			for(int j=0; j < gridSize.y; j++)
			{
				Instantiate(Resources.Load("Panel"), new Vector3(topLeftPosition.x + i*spacing, topLeftPosition.y - j*spacing, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
